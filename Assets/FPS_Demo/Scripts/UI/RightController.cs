using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightController : SingletonMonoBehaviour<RightController>
{
    [SerializeField]
    private Button m_btnGrenade;

    private void Start()
    {
        m_btnGrenade.onClick.AddListener(Grenade);
    }

    private void Grenade()
    {
        Debug.Log("grenade");
    }
}
