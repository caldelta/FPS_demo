using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    // Update is called once per frame
    void Update()
    {
        if (m_rigidBody.rotation != Quaternion.identity)
            Destroy(gameObject);
    }
}
