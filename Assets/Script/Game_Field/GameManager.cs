using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = new GameManager();
    private static bool m_cureated = false;

    private static bool m_isPlay = false;
    [SerializeField] private UiManager m_ui = null;
    [SerializeField] private AudioClass m_audio = null;

    private static float m_timer;

    public void IsPlay()
    {
        m_isPlay = true;
        m_audio = FindObjectOfType<AudioClass>();
        m_audio.Game();
        m_timer = 0;
    }

    public bool Cureated()
    {
        return m_isPlay;
    }

    public void EndPlay()
    {
        m_ui = FindObjectOfType<UiManager>();
        m_ui.SetRezult();
        m_isPlay = false;
    }

    public void OnLoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnLoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public float Timer()
    {
        m_timer = Time.deltaTime;
        return m_timer;
    }

    private void Awake()
    {
        if (!m_cureated)
        {
            DontDestroyOnLoad(Instance);
            m_cureated = true;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void DiedPlayer()
    {
        RankingManager ranking = FindObjectOfType<RankingManager>();
        float result = m_ui.m_rezultScore;
        ranking.SetUp(result);
    }
}
