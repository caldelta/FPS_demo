using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float m_health = EnemyConst.ENEMY_HEALTH;

    public void Damage()
    {
        m_health -= 10;
    }

    private void Update()
    {
        if(m_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
