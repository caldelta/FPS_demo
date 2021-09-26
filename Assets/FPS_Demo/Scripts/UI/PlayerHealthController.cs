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
        if (m_imgHealth.fillAmount <= 0)
        {
            StartCoroutine(MissionController.Instance.Lose());            
        }

        float dmgAmount = m_imgHealth.fillAmount;

        dmgAmount-= damage / PlayerConst.HEALH_POINT;

        m_imgHealth.fillAmount = Mathf.Lerp(m_imgHealth.fillAmount, dmgAmount, Time.deltaTime * 2);
    }
}
