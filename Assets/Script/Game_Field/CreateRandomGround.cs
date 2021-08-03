using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomGround : MonoBehaviour
{
    [SerializeField] private Transform[] m_pos;
    [SerializeField] private GameObject[] m_ground;

    private float m_timer = 0;
    private float m_gameTime = 0;
    private float m_speedUpCount = 10;

    ScrollGroundClass m_groundClass;

    void Start()
    {
        m_groundClass = FindObjectOfType<ScrollGroundClass>();
    }

    void Update()
    {
        if (!GameManager.Instance.Cureated()) return;

        m_timer += GameManager.Instance.Timer();

        if (m_timer > 1.5f)
        {
            Transform pos = SelectPos();
            GameObject ground = SelectGround();

            Instantiate(ground, pos);

            m_timer = 0;
        }

        ScrollSpeed();
    }

    private Transform SelectPos()
    {
        int random = Random.Range(0, m_pos.Length);

        return m_pos[random];
    }

    private GameObject SelectGround()
    {
        int random = Random.Range(0, m_ground.Length);
        return m_ground[random];
    }

    private void ScrollSpeed()
    {
        m_gameTime += Time.deltaTime;
        
        if (m_gameTime >= m_speedUpCount)
        {
            m_groundClass.SpeedUp();
            m_speedUpCount += 10;
        }
    }
}
