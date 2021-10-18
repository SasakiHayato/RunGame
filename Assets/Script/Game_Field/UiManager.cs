using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    static float m_score;

    static GameObject m_rezult;
    static GameObject m_scoreOb;
    static GameObject m_ranking;

    [SerializeField] Text m_resultScoreText;
    Text m_scoreText;
    Text m_rankingText;
    
    public float m_rezultScore { get => m_score; }

    void Start()
    {
        m_rezult = GameObject.Find("Retry");
        m_rezult.SetActive(false);

        m_scoreOb = GameObject.Find("Score");
        GameObject child = m_scoreOb.transform.GetChild(0).gameObject;
        m_scoreText = child.GetComponent<Text>();

        m_ranking = GameObject.Find("Ranking");
        GameObject rChild = m_ranking.transform.GetChild(0).gameObject;
        m_rankingText = rChild.GetComponent<Text>();
        m_ranking.SetActive(false);
    }
    void Update()
    {
        if (!GameManager.Instance.Cureated()) return;
        m_score += GameManager.Instance.Timer() * 100;

        SetScore(m_score);
    }

    void SetScore(float score) => m_scoreText.text = score.ToString("Score: " + "00000000");

    public void SetRezult()
    {
        m_scoreOb.SetActive(false);
        m_rezult.SetActive(true);
        m_ranking.SetActive(true);
        m_resultScoreText.text = m_score.ToString("Score: " + "00000000");
    }

    public void ScoreUp()
    {
        m_score += 3000;
        SetScore(m_score);
    }
}
