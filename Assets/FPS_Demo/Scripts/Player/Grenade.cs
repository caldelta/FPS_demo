using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private GameObject m_explosiveVfx;

    [SerializeField]
    private Rigidbody m_rigidBody;

    private const int LIFE_TIME = 1;

    private float m_lifeTime;

    [SerializeField]
    private AudioSource m_audioSource;

    [SerializeField]
    private AudioClip m_audioClip;

    // Start is called before the first frame update
    void Start()
    {
        m_lifeTime = 0;
        m_rigidBody.AddForce(transform.forward * 10, ForceMode.Impulse);
    }
    
    private void Update()
    {
        m_lifeTime += Time.deltaTime;

        if(m_lifeTime > LIFE_TIME)
        {          
            m_audioSource.Play();
            m_lifeTime = -LIFE_TIME;
            Instantiate(m_explosiveVfx, transform.position, transform.rotation);
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5, EnvironmentConst.DAMAGE_LAYER | EnvironmentConst.BARREL_LAYER | EnvironmentConst.ENEMY_LAYER);
            foreach (Collider col in colliders)
            {
                var hitEnemy = col.GetComponent<EnemyHealth>();
                if (hitEnemy != null)
                {
                    hitEnemy.Damage(PlayerConst.GRENADE_DAMAGE);
                    continue;
                }
                    
                var hitBarrel = col.GetComponent<ExplosiveBarrel>();
                if (hitBarrel != null)
                {
                    hitBarrel.SetHitType(HitType.BARREL);

                    if (hitBarrel.GetComponent<Rigidbody>() != null)
                    {
                        GameObject.Instantiate(PlayerController.Instance.ExplosiveVfx, hitBarrel.transform.position, hitBarrel.transform.rotation);
                    }
                }
            }
            Destroy(gameObject, 0.4f);
        }
    }
}
