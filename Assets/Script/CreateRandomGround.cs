using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomGround : MonoBehaviour
{
    [SerializeField] private Transform[] m_pos;
    [SerializeField] private GameObject[] m_ground;

    private float m_timer = 0;

    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_timer > 1.5f)
        {
            Transform pos = SelectPos();
            GameObject ground = SelectGround();

            Instantiate(ground, pos);

            m_timer = 0;
        }
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
}
