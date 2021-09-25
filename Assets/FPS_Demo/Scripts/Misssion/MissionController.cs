using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissionController : SingletonMonoBehaviour<MissionController>
{
    private int m_waterBottles;

    [SerializeField]
    private TextMeshProUGUI m_txtWaterBottles;

    private void Start()
    {
        m_waterBottles = 0;
        m_txtWaterBottles.text = "X " + m_waterBottles;
    }

    public void Collect()
    {
        m_waterBottles++;

        m_txtWaterBottles.text = "X " + m_waterBottles;
    }
}