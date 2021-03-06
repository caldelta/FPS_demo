using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : SingletonMonoBehaviour<PlayerController>
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    [SerializeField]
    private Animator m_animator;

    private float m_speed;

    [SerializeField]
    private GameObject m_casingBullet;
    [SerializeField]
    private Transform m_casingPoint;

    [SerializeField]
    private GameObject m_impactHole;

    [SerializeField]
    private GameObject m_grenade;
    [SerializeField]
    private Transform m_grenadePoint;

    public GameObject ExplosiveVfx;

    [SerializeField]
    private GameObject m_bloodSplash;


    private float m_rotationX;
    private float m_rotationY;

    private Quaternion m_originalRot;

    private Touch m_touch;
    private bool m_isTouch = false;

    private Vector3 m_movementDir;
    private Vector3 m_rotateDir;

    [SerializeField]
    private AudioSource m_audioSource;

    [SerializeField]
    private AudioClip m_runFx;

    [SerializeField]
    private AudioClip m_shotFx;

    [SerializeField]
    private AudioClip m_greandeFx;

    // Start is called before the first frame update
    void Start()
    {
        m_originalRot = transform.localRotation;
        m_timeShot = Time.realtimeSinceStartup;
    }

    private bool IsCurrentAnimationEnd
    {
        get
        {
            return m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMovement();
    }

    private void Update()
    {
        UpdateTouch();
        UpdateAnimation();
        UpdateAction();
        UpdateSound();
    }
    private void UpdateTouch()
    {
        if (Input.touchCount == 1)
        {
            m_touch = Input.touches[0];
            switch (m_touch.phase)
            {
                case TouchPhase.Began:
                    m_isTouch = true;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
                    m_isTouch = false;
                    break;
            }
        }
    }

    private void UpdateMovement()
    {
        var charForward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
#if UNITY_EDITOR
        m_movementDir = charForward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        m_rotateDir = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
#else
        if (Dpad.Instance.IsTouch)
        {
            m_movementDir = charForward * Dpad.Instance.InputVector.y + transform.right * Dpad.Instance.InputVector.x;            
        }
        else
        {
            m_movementDir = Vector3.zero;        
        }
        if(m_isTouch)
        {
            m_rotateDir = new Vector3(m_touch.deltaPosition.x, m_touch.deltaPosition.y, 0);
        }
        else
        {
            m_rotateDir = Vector3.zero;
        }
#endif
        m_speed = m_movementDir.magnitude;

        m_rigidBody.MovePosition(m_rigidBody.position + m_movementDir * Time.deltaTime * PlayerConst.MOVEMENT_SPEED);

        m_rigidBody.MoveRotation(GetCameraRotation(m_rotateDir));
    }

    private float m_timeShot;
    private void UpdateAction()
    {

#if UNITY_EDITOR
        //if (Input.GetKeyDown(KeyCode.Space))
            if (FireButtonController.Instance.IsPressed && IsCurrentAnimationEnd && ObjectPooler.SharedInstance.IsAvailable(PoolConst.CASINGBULLET))
#else
            if (FireButtonController.Instance.IsPressed && IsCurrentAnimationEnd && ObjectPooler.SharedInstance.IsAvailable(PoolConst.CASINGBULLET))
#endif
            {
            if (Time.realtimeSinceStartup - m_timeShot >= PlayerConst.FIRE_RATE)
            {
                m_audioSource.PlayOneShot(m_shotFx);
                m_timeShot = Time.realtimeSinceStartup + PlayerConst.FIRE_RATE;
                SpawnCasingBullet();
                Fire();
            }
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.G))
#else
        if (GrenadeButtonController.Instance.IsPressed)
#endif
        {
            GrenadeButtonController.Instance.IsPressed = false;
            Grenade();
        }
    }

    private void UpdateAnimation()
    {
        m_animator.SetFloat(PlayerConst.RunStateHash, m_speed);

        m_animator.SetBool(PlayerConst.FireStateHash, FireButtonController.Instance.IsPressed);

        if (GrenadeButtonController.Instance.IsPressed)
        {
            m_animator.SetTrigger(PlayerConst.GrenadeStateHash);
        }
    }

    private void UpdateSound()
    {
        if (m_speed != 0)
        {
            SoundManager.Instance.Play(SoundConst.Run);
        }
        else
        {
            SoundManager.Instance.Stop();
        }
    }

    private void SpawnCasingBullet()
    {
        var go = ObjectPooler.SharedInstance.GetPooledObject(PoolConst.CASINGBULLET);

        go.SetActive(true);
        go.GetComponent<CasingBullet>().Setup();

        go.transform.position = m_casingPoint.position;
        go.transform.SetParent(m_casingPoint);
    }

    private void Fire()
    {

        var ray = Camera.main.ScreenPointToRay(PlayerConst.CrossHairPos);
        HitObject hitObject;
        if (Physics.Raycast(ray, out RaycastHit hitBarrel, PlayerConst.ATTACK_RANGE, EnvironmentConst.BARREL_LAYER | EnvironmentConst.ENVIRONMENT_LAYER))
        {
            hitObject = new HitBarrel
            {
                HitType = HitType.BARREL,
                RaycastHit = hitBarrel,
                ImpactHole = m_impactHole,
                ExplosiveVfx = ExplosiveVfx
            };
            hitObject.Hit();
        }

        if (Physics.Raycast(ray, out RaycastHit hitEnemy, PlayerConst.ATTACK_RANGE, EnvironmentConst.ENEMY_LAYER))
        {
            hitObject = new HitEnemy
            {
                HitType = HitType.ENEMY,
                RaycastHit = hitEnemy,
                BloodSplash = m_bloodSplash
            };
            hitObject.Hit();
        }
    }

    public void Grenade()
    {
        m_audioSource.PlayOneShot(m_greandeFx);

        Instantiate(m_grenade, m_grenadePoint);
    }

    private Quaternion GetCameraRotation(Vector3 rotateDir)
    {
        if (Dpad.Instance.IsTouch)
        {            
            return transform.localRotation;
        }

        m_rotationX += rotateDir.x * PlayerConst.CAMERA_ROT_SENSITIVITY;
        m_rotationY += rotateDir.y * PlayerConst.CAMERA_ROT_SENSITIVITY;
        m_rotationX = ClampAngle(m_rotationX, PlayerConst.CAMERA_ROT_MIN_X, PlayerConst.CAMERA_ROT_MAX_X);
        m_rotationY = ClampAngle(m_rotationY, PlayerConst.CAMERA_ROT_MIN_Y, PlayerConst.CAMERA_ROT_MAX_Y);
        Quaternion xQuaternion = Quaternion.AngleAxis(m_rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(m_rotationY, -Vector3.right);

        return m_originalRot * xQuaternion * yQuaternion;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360F;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            PlayerHealthController.Instance.Hurt(EnemyConst.ENEMY_DAMAGE);
        }
    }
}