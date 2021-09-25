using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    private int m_hitType = HitType.NA;

    // Update is called once per frame
    void Update()
    {
        if(m_hitType == HitType.BARREL)
        {
            Destroy(gameObject);
        }
            
    }    

    public void SetHitType(int type)
    {
        m_hitType = type;
    }
}
