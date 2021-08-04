using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClass : MonoBehaviour
{
    private Button[] m_buttons = new Button[2];
    private GameObject m_ob = null;

    private float m_selectNum = 0;
    private float m_seveNum { get; set; }

    void Start()
    {
        for (int i = 0; i < m_buttons.Length; i++)
        {
            m_ob = transform.GetChild(i).gameObject;
            m_buttons[i] = m_ob.GetComponent<Button>();
        }
    }

    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");

        Select(v);
        SelectedColor();

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log(m_buttons[(int)m_selectNum]);
            m_buttons[(int)m_selectNum].onClick.AddListener(Load);
        }
    }

    private void Select(float v)
    {
        if (v < 0 && m_seveNum != v)
        {
            m_seveNum = v;
            m_selectNum = 1;
        }
        else if (v > 0 && m_seveNum != v)
        {
            m_seveNum = v;
            m_selectNum = 0;
        }
    }

    private void SelectedColor()
    {
        for (int i = 0; i < m_buttons.Length; i++)
        {
            Image buttonImage = m_buttons[i].GetComponent<Image>();
            buttonImage.color = (i == m_selectNum ? Color.red : Color.white);
        }
    }

    private void Load()
    {
        if ((int)m_selectNum == 0)
        {
            GameManager.Instance.IsPlay();
        }
        else if ((int)m_selectNum == 1)
        {
            GameManager.Instance.OnLoadTitle();
        }
    }
}
