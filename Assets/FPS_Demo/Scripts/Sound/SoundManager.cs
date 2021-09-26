using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField]
    private AudioClip[] m_soundList;

    [SerializeField]
    private AudioSource m_audioSrc;
    private AudioClip m_clip;

    public void Play(int soundIndex)
    {
        if (m_audioSrc.isPlaying)
            return;
        switch (soundIndex)
        {
            case SoundConst.Run:
                m_clip = m_soundList[SoundConst.Run];
                break;
        }
        m_audioSrc.clip = m_soundList[soundIndex];
        m_audioSrc.PlayOneShot(m_clip);
    }
    public void Stop()
    {
        m_audioSrc.Stop();
    }
}
