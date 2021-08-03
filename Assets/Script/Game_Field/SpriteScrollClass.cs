using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteScrollClass : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_sprite;
    private SpriteRenderer m_clone;

    [SerializeField] private float m_scrollSpeed = 0;
    private float m_xPos;

    void Start()
    {
        m_xPos = m_sprite.transform.position.x;

        m_clone = Instantiate(m_sprite);
        m_clone.transform.Translate(m_sprite.bounds.size.x, 0, 0);
    }

    void Update()
    {
        m_sprite.transform.Translate(-m_scrollSpeed * Time.deltaTime, 0, 0);
        m_clone.transform.Translate(-m_scrollSpeed * Time.deltaTime, 0, 0);

        if (m_xPos - m_sprite.transform.position.x >  m_sprite.bounds.size.x)
        {
            m_sprite.transform.Translate(m_sprite.bounds.size.x * 2, 0, 0);
        }
        if (m_xPos - m_clone.transform.position.x >  m_clone.bounds.size.x)
        {
            m_clone.transform.Translate(m_clone.bounds.size.x * 2, 0, 0);
        }
    }
}
