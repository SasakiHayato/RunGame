using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomObstacle : MonoBehaviour
{
    [SerializeField] private Transform[] m_pos;
    [SerializeField] private GameObject m_obstacle;

    private float m_timer = 0;

    void Update()
    {
        if (!GameManager.Instance.Cureated()) return;

        m_timer += Time.deltaTime;

        if (m_timer > 3)
        {
            Transform pos = SelectPos();
            Instantiate(m_obstacle, pos);

            m_timer = 0;
        }
    }

    private Transform SelectPos()
    {
        int random = Random.Range(0, m_pos.Length);

        return m_pos[random];
    }
}
