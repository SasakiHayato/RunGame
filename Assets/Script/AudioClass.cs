using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClass : MonoBehaviour
{
    private enum AudioEnum
    {
        Title = 0,
        Game = 1,
        Operation = 2,
    }

    private AudioSource m_source = null;
    [SerializeField] private AudioEnum m_audioEnum;
    [SerializeField] private AudioClip[] m_bgmClips;


    void Start()
    {
        AddAudioSource();
    }

    void Update()
    {
        
    }

    private void SetAudio()
    {

    }

    private void AddAudioSource()
    {
        if (m_source == null)
        {
            gameObject.AddComponent<AudioSource>();
        }

        m_source = gameObject.GetComponent<AudioSource>();
    }
}
