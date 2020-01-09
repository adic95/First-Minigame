using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static  AudioManager Instance;
    public List<AudioClip> m_AllAudioClips;
    public AudioSource m_audioSource;


    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }

        else
        {
            Instance = this;
        }
    }

    public void PlaySelectedSound ( int SoundID)
    {
        m_audioSource.clip = m_AllAudioClips[SoundID];
        m_audioSource.Play();
    }
}
