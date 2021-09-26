using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_audioSource.Play();
            MissionController.Instance.Collect();
            Destroy(gameObject, 1);
        }
    }    
}
