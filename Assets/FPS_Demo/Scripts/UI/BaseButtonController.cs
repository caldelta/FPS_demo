using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseButtonController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool IsPressed { get; set; }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " " + "down");
        IsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " " + "up");
        IsPressed = false;
    }
}
