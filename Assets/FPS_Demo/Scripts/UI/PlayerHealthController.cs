using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : SingletonMonoBehaviour<PlayerHealthController>
{
    [SerializeField]
    private Image m_imgHealth;

    public void Hurt(float damage)
    {
        m_imgHealth.fillAmount -= damage / PlayerConst.HEALH_POINT;
    }
}
