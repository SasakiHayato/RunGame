using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreClass : MonoBehaviour
{
    [SerializeField] private Text m_scoreText = null;
    private float m_score = 0;

    private UiClass m_ui;

    void Start()
    {
        m_ui = FindObjectOfType<UiClass>();
    }

    void Update()
    {
        if (!GameManager.Instance.Cureated()) return; 
        m_score += GameManager.Instance.Timer() * 100;

        SetScore(m_score);
    }

    public void ScoreUp()
    {
        m_score += 3000;
        SetScore(m_score);
    }

    private void SetScore(float score)
    {
        m_scoreText.text = score.ToString("Score: " + "00000000");

        m_ui.m_rezultScore = score;
    }
}
