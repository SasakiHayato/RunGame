using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StratCountClass : MonoBehaviour
{
    private float m_time = 4;
    private bool m_active = false;
    private GameObject m_startImage = default;
    [SerializeField] Text m_timeText = null;

    void Start()
    {
        m_startImage = GameObject.Find("StartImage").gameObject;
        gameObject.SetActive(m_active);
    }

    void Update()
    {
        if (!m_active) return;
        
        m_time -= Time.deltaTime;
        SetCount(m_time);
    }

    public void SetActive()
    {
        m_active = true;
        m_startImage.SetActive(false);
        gameObject.SetActive(m_active);
    }

    private void SetCount(float time)
    {
        if (time > 3) return;
        
        if ((int)time == 0)
        {
            m_timeText.text = "Go!!";

            if (time < 0)
            {
                m_active = false;

                GameManager.Instance.IsPlay();
                Destroy(this.gameObject);
            }
        }
        else
        {
            m_timeText.text = time.ToString("0");
        }
    }
}
