using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissionController : SingletonMonoBehaviour<MissionController>
{
    private int m_waterBottles;

    [SerializeField]
    private GameObject m_missionStart;

    [SerializeField]
    private GameObject m_missionEnd;

    [SerializeField]
    private GameObject m_blackScreen;

    [SerializeField]
    private TextMeshProUGUI m_txtWaterBottles;

    private void Start()
    {
        m_waterBottles = 0;
        m_txtWaterBottles.text = "X " + m_waterBottles;
        StartCoroutine(m_missionStart.GetComponent<FadeOut>().StartFade());
    }

    public void Collect()
    {
        m_waterBottles++;
        if(m_waterBottles == MissionConst.WATER_BOTTLES_MISSION_AMOUNT)        
        {
            StartCoroutine(Win());
        }
        m_txtWaterBottles.text = "X " + m_waterBottles;
    }

    private IEnumerator Win()
    {
        yield return m_missionEnd.GetComponent<FadeOut>().StartFade();        
        yield return m_blackScreen.GetComponent<FadeOut>().StartFade();
        SceneLoader.Instance.LoadWin();
    }
}
