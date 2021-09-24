using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    [SerializeField]
    private const float SPEED = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dir = new Vector3(0, 0, Dpad.Instance.InputVector.y);

        m_rigidBody.MovePosition(transform.position + dir * Time.deltaTime * SPEED);
    }
}
