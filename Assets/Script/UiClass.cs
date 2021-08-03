using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiClass : MonoBehaviour
{
    private GameObject m_rezult = null;
    private GameObject m_scoreOb = null;

    [SerializeField] private Text m_scoreText = null;

    public float m_rezultScore { get; set; }

    void Start()
    {
        m_rezult = GameObject.Find("Retry").gameObject;
        m_rezult.SetActive(false);

        m_scoreOb = GameObject.Find("Score").gameObject;
    }

    public void SetRezult()
    {
        m_scoreOb.SetActive(false);
        m_rezult.SetActive(true);
        m_scoreText.text = m_rezultScore.ToString("Score: " + "00000000");
    }
}
