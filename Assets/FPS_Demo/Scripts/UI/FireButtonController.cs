using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButtonController : SingletonMonoBehaviour<FireButtonController>, IPointerUpHandler, IPointerDownHandler
{
    public bool IsFire { get; set; }
    public void OnPointerDown(PointerEventData eventData)
    {
        IsFire = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsFire = false;
    }
}
