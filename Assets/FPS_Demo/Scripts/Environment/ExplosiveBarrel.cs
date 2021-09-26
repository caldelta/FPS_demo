using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    private int m_hitType = HitType.NA;

    [SerializeField]
    private AudioSource m_audioSource;
    // Update is called once per frame
    void Update()
    {
        if(m_hitType == HitType.BARREL)
        {
            m_hitType = HitType.NA;
            m_audioSource.Play();
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5);
            foreach (Collider col in colliders)
            {
                var hitObject = col.GetComponent<EnemyHealth>();
                if(hitObject != null)
                    hitObject.Damage(EnvironmentConst.BARREL_DAMAGE);
            }
            Destroy(gameObject, 1);
        }            
    }    

    public void SetHitType(int type)
    {
        m_hitType = type;
    }
}
