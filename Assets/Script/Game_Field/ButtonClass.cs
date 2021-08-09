using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonClass : MonoBehaviour
{
    private uint m_selectNum = 0;

    [SerializeField] UnityEvent[] m_event;
    private List<GameObject> m_buttonObs = new List<GameObject>();

    private bool m_down = false;
    
    void Start()
    { 
        for (int i = 0; i < m_event.Length; i++)
        {
            GameObject set = transform.GetChild(i).gameObject;
            m_buttonObs.Add(set);
        }
    }

    void Update()
    {
        Select();
        SelectColor();

        if (Input.GetButtonDown("JoystickSelect"))
        {
            m_event[m_selectNum].Invoke();
        }
    }

    private void Select()
    {
        float v = Input.GetAxisRaw("Vertical");

        if (v == 0) { m_down = false; }
        if (v > 0 && !m_down)
        {
            m_down = true;
            //　上
            if (m_selectNum <= 0) return;
            m_selectNum--;
        }
        else if(v < 0 && !m_down)
        {
            m_down = true;
            // 下
            if (m_event.Length - 1 <= m_selectNum) return;
            m_selectNum++;
        }
    }

    private void SelectColor()
    {
        for (int i = 0; i < m_event.Length; i++)
        {
            Image imageColor = m_buttonObs[i].GetComponent<Image>();
            imageColor.color = (i == m_selectNum ? Color.red : Color.white);
        }
    }
}
