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

    [SerializeField]
    private AudioSource m_audioFxSrc;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayFx(int soundIndex)
    {
        if (m_audioFxSrc.isPlaying)
            return;
        m_audioSrc.Play();

    }
    public void Play(int soundIndex)
    {
        if (m_audioSrc.isPlaying)
            return;
        switch (soundIndex)
        {
            case SoundConst.Run:
                m_clip = m_soundList[SoundConst.Run];
                break;
            case SoundConst.Explosion:
                m_clip = m_soundList[SoundConst.Explosion];
                break;
        }
        Debug.Log("Play " + m_soundList[soundIndex].name);
        m_audioSrc.clip = m_soundList[soundIndex];
        m_audioSrc.PlayOneShot(m_clip);
    }
    public void Stop()
    {
        m_audioSrc.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
