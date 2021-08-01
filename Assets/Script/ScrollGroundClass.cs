using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScrollGroundClass : MonoBehaviour
{
    private float m_speed = -5f;
    private float m_time = 0;
    private float m_up = 10;

    void Update()
    {
        if (!GameManager.Instance.Cureated()) return;
        //m_time += Time.deltaTime;
        //if (m_time > m_up)
        //{
        //    m_speed -= 0.04f;
        //    m_up += 10;
        //    Debug.Log(m_speed);
        //}
        transform.Translate(m_speed * Time.deltaTime, 0 ,0);
    }
}
