using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightController : SingletonMonoBehaviour<RightController>
{
    [SerializeField]
    private Button m_btnShot;

    [SerializeField]
    private Button m_btnGrenade;

    private void Start()
    {
        //m_btnShot.onClick.AddListener(Shot);
        m_btnGrenade.onClick.AddListener(Grenade);
    }

    //private void Shot()
    //{
    //    Debug.Log("shot");
    //}
    private void Grenade()
    {
        Debug.Log("grenade");
    }
}
