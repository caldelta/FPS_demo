using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    private const float VisibleDuration = 2f;
    private const float FadeInDuration = 0.5f;
    private const float FadeOutDuration = 2f;

    private float m_InitTime;

    public float TotalRunTime => VisibleDuration + FadeInDuration + FadeOutDuration;
    public bool Initialized { get; private set; }

    public void Start()
    {
        Initialized = false;        
    }
    public void StartFade()
    {
        m_InitTime = Time.time;
        Initialized = true;
    }

    void Update()
    {
        if(Initialized)
        {
            float timeSinceInit = Time.time - m_InitTime;
            if (timeSinceInit < FadeInDuration)
            {
                // fade in
                CanvasGroup.alpha = timeSinceInit / FadeInDuration;
            }
            else if (timeSinceInit < FadeInDuration + VisibleDuration)
            {
                // stay visible
                CanvasGroup.alpha = 1f;
            }
            else if (timeSinceInit < FadeInDuration + VisibleDuration + FadeOutDuration)
            {
                // fade out
                CanvasGroup.alpha = 1 - (timeSinceInit - FadeInDuration - VisibleDuration) / FadeOutDuration;
            }
            else
            {
                CanvasGroup.alpha = 0f;

                // fade out over, destroy the object
                Destroy(gameObject);
            }
        }        
    }
}
