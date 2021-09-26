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

    private bool IsGameEnding;

    private float m_fadeTime;

    private void Start()
    {
        m_waterBottles = 0;
        m_txtWaterBottles.text = "X " + m_waterBottles;
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        m_missionStart.GetComponent<FadeOut>().StartFade();
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
        m_missionEnd.GetComponent<FadeOut>().StartFade();
        yield return new WaitForSeconds(2);
        IsGameEnding = true;
    }

    void Update()
    {
        if (IsGameEnding)
        {
            m_fadeTime += Time.deltaTime * 0.01f;
            m_blackScreen.GetComponent<CanvasGroup>().alpha += m_fadeTime;

            //AudioUtility.SetMasterVolume(1 - timeRatio);

            if (m_blackScreen.GetComponent<CanvasGroup>().alpha == 1)
            {
                SceneLoader.Instance.LoadWin();
                IsGameEnding = false;
            }
        }
    }
}
