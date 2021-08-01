using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = new GameManager();
    private static bool m_cureated = false;

    private static bool m_isPlay = false;
    [SerializeField] UiClass m_ui = null;

    public void IsPlay()
    {
        m_isPlay = true;
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
