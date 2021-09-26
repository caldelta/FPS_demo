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

    public bool IsGameEnding { get; set; }

    private float m_fadeTime;

    private bool isWin;

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

    public IEnumerator Win()
    {
        isWin = true;
        m_missionEnd.GetComponent<FadeOut>().StartFade();
        yield return new WaitForSeconds(2);
        IsGameEnding = true;
    }
    public IEnumerator Lose()
    {
        isWin = false;
        yield return new WaitForSeconds(1);
        IsGameEnding = true;
    }
    void Update()
    {
        if (IsGameEnding)
        {
            m_fadeTime += Time.deltaTime * 0.01f;
            m_blackScreen.GetComponent<CanvasGroup>().alpha += m_fadeTime;

            if (m_blackScreen.GetComponent<CanvasGroup>().alpha == 1)
            {
                if(isWin)
                    SceneLoader.Instance.LoadWin();
                else
                    SceneLoader.Instance.LoadLose();
                IsGameEnding = false;
            }
        }
    }
}
