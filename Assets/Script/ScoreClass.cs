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
        
        m_score += Time.deltaTime;
        m_scoreText.text = (m_score * 1000).ToString("Score: " + "00000000");

        m_ui.m_rezultScore = m_score * 1000;
    }
}
