using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    [SerializeField]
    private Animator m_animator;

    private float m_speed;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMovement();
    }

    private void Update()
    {
        UpdateAction();
        UpdateAnimation();
    }

    private void UpdateMovement()
    {
        var dir = Dpad.Instance.InputVector.y * transform.forward;

        m_speed = dir.magnitude;

        m_rigidBody.MovePosition(m_rigidBody.position + dir * Time.deltaTime * PlayerConst.MOVEMENT_SPEED);

        var rot = Quaternion.Euler(0, Dpad.Instance.InputVector.x * Time.deltaTime * PlayerConst.ROTATION_SPEED, 0);
        m_rigidBody.MoveRotation(m_rigidBody.rotation * rot);
    }
    private void UpdateAction()
    {
        m_animator.SetBool(PlayerConst.FireStateHash, FireButtonController.Instance.IsFire);
    }

    private void UpdateAnimation()
    {
        m_animator.SetFloat(PlayerConst.RunStateHash, m_speed);
    }
}
