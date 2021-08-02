using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScrollGroundClass : MonoBehaviour
{
    private static float m_speed = -5f;
    private float m_desTime = 0;

    void Update()
    {
        if (GameManager.Instance.Cureated())
        {
            m_desTime += GameManager.Instance.Timer();

            if (m_desTime > 4)
            {
                Destroy(this.gameObject);
                m_desTime = 0;
            }
            transform.Translate(m_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            m_speed = -5f;
        }
    }

    public void SpeedUp()
    {
        if (m_speed > 10) return;
        m_speed -= 1f;
    }
}
