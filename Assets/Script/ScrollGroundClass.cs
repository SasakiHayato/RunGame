using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScrollGroundClass : MonoBehaviour
{
    private float m_speed = -5f;

    private float m_desTime = 0;

    void Update()
    {
        if (!GameManager.Instance.Cureated()) return;
        m_desTime += Time.deltaTime;
        transform.Translate(m_speed * Time.deltaTime, 0 ,0);

        if (m_desTime > 4)
        {
            Destroy(this.gameObject);
            m_desTime = 0;
        }
    }
}
