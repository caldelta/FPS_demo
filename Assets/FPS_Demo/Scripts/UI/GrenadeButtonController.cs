using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrenadeButtonController : SingletonMonoBehaviour<GrenadeButtonController>
{
    [SerializeField]
    private Button m_btn;

    public bool IsPressed { get; set; }
    private void Start()
    {
        m_btn.onClick.AddListener(Grenade);
    }

    private void Grenade()
    {
        IsPressed = true;
    }
}
