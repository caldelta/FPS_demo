using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingBullet : MonoBehaviour
{
    private float m_lifeTime;

    private const float LIFETIME = 200f;

    [SerializeField]
    private Rigidbody m_rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        m_lifeTime = 0;
        m_rigidBody.AddForce(Random.onUnitSphere, ForceMode.Impulse);
        m_rigidBody.AddTorque(Random.onUnitSphere, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        m_lifeTime += Time.realtimeSinceStartup;
        if(m_lifeTime >= LIFETIME)
        {
            gameObject.SetActive(false);
        }        
    }
}
