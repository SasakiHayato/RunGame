using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = new GameManager();
    private static bool m_cureated = false;

    private static bool m_isPlay = false;
    [SerializeField] private UiClass m_ui = null;

    private static float m_timer;

    public void IsPlay()
    {
        m_isPlay = true;
        m_timer = 0;
        SceneManager.LoadScene("Game");
    }

    public bool Cureated()
    {
        return m_isPlay;
    }

    public void EndPlay()
    {
        m_ui = FindObjectOfType<UiClass>();
        m_ui.SetRezult();
        m_isPlay = false;
    }

    public void OnLoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public float Timer()
    {
        m_timer += Time.deltaTime;
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
}
