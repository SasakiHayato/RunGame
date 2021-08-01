using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScrollGroundClass : MonoBehaviour
{
    private float m_speed = -5;

    void Update()
    {
        if (!GameManager.Instance.Cureated()) return;

        transform.Translate(m_speed * Time.deltaTime, 0 ,0);
    }
}
