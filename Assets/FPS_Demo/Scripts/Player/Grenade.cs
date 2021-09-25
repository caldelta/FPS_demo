using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private GameObject m_explosiveVfx;

    [SerializeField]
    private Rigidbody m_rigidBody;

    private const int LIFE_TIME = 2000;

    private float m_lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        m_lifeTime = 0;
        m_rigidBody.AddForce(transform.forward * 10, ForceMode.Impulse);
    }

    private void Update()
    {
        m_lifeTime += Time.realtimeSinceStartup;

        if(m_lifeTime >= LIFE_TIME)
        {
            Instantiate(m_explosiveVfx, transform.position, transform.rotation);
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5);
            foreach (Collider col in colliders)
            {
                var hitObject = col.GetComponent<EnemyHealth>();
                if (hitObject != null)
                    hitObject.Damage(PlayerConst.GRENADE_DAMAGE);
            }
            Destroy(gameObject);
        }
    }
}
