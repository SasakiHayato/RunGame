using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldClass : MonoBehaviour
{
    private float m_time = 4;
    private float m_alfa = 1;

    private Transform m_playerPos;
    private PlayerManager m_playerManager;
    private SpriteRenderer m_sheldImage = null;

    void Start()
    {
        m_playerPos = GameObject.Find("Player").transform;
        m_playerManager = FindObjectOfType<PlayerManager>();
        m_playerManager.m_isShield = true;
        m_sheldImage = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = m_playerPos.position;
        m_sheldImage.color = new Color(m_sheldImage.color.r, m_sheldImage.color.g, m_sheldImage.color.b, m_alfa);
        m_time -= Time.deltaTime; 

        if (m_time < 0)
        {
            m_alfa -= 0.02f;
            if (m_alfa <= 0)
            {
                m_playerManager.m_isShield = false;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
    }
}
