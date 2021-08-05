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

    [SerializeField] private AudioClip[] m_countClips;

    void Start()
    {
        AddAudioSource();
        SetAudio(m_source);

        PlayAudio();
    }

    private AudioSource SetAudio(AudioSource source)
    {
        if (m_audioEnum == AudioEnum.Title)
        {
            source.clip = m_bgmClips[0];
            source.volume = 0.4f;
        }
        else if (m_audioEnum == AudioEnum.Game)
        {
            source.clip = m_bgmClips[1];
            source.volume = 0.2f;
        }
        else if (m_audioEnum == AudioEnum.Operation)
        {
            source.clip = m_bgmClips[2];
            source.volume = 0.4f;
        }

        return source;
    }

    private void PlayAudio()
    {
        m_source.Play();
    }

    public void OnClickAudio()
    {
        m_source.Stop();
    }

    public void Game()
    {
        m_source.clip = m_bgmClips[1];
        m_source.volume = 0.2f;

        PlayAudio();
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
