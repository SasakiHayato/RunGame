using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    private float m_angleSin = 0;

    private bool m_shotCheck = false;
    
    private Vector2 m_vector = Vector2.zero;
    private Vector2 m_bulletVec = Vector2.zero;

    private Rigidbody2D m_rigidbody;
    private PlayerManager m_player;
    private LineRenderer m_line;

    private Transform m_playerPos;

    void Start()
    {
        m_player = FindObjectOfType<PlayerManager>();
        m_playerPos = GameObject.Find("Player").transform;

        AddLineRenderer();
        SetLine();
    }

    void Update()
    {
        if (m_shotCheck) return;
        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector2(m_playerPos.position.x - 0.8f, m_playerPos.position.y + 0.5f);
            m_angleSin += Time.deltaTime;

            float angle = Mathf.Sin(m_angleSin) * (180 / Mathf.PI);
            float rad = angle * Mathf.Deg2Rad;

            DrawLine(rad);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 angleVec = SetAngle(m_angleSin) * 15;
            Shot(angleVec);
        }
    }

    private void Shot(Vector2 force)
    {
        AddRb2D();

        m_rigidbody.AddForce(force, ForceMode2D.Impulse);
        
        m_shotCheck = true;
    }

    private Vector2 SetAngle(float sin)
    {
        float angle = Mathf.Sin(sin) * (180 / Mathf.PI);
        float rad = angle * Mathf.Deg2Rad;

        m_vector = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

        return m_vector;
    }

    private void SetLine()
    {
        m_line.startWidth = 0.1f;
        m_line.endWidth = 0.1f;

        m_line.startColor = Color.white;
        m_line.endColor = Color.white;
    }

    private void DrawLine(float rad)
    {
        m_bulletVec = transform.position;

        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);

        m_line.SetPosition(0, new Vector3(transform.position.x, transform.position.y, m_playerPos.position.z));
        m_line.SetPosition(1, new Vector3(cos + m_bulletVec.x, sin + m_bulletVec.y, m_playerPos.position.z));
    }

    private void AddRb2D()
    {
        if (m_rigidbody == null)
        {
            m_rigidbody = this.gameObject.AddComponent<Rigidbody2D>();
        }

        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void AddLineRenderer()
    {
        if (m_line == null)
        {
            m_line = this.gameObject.AddComponent<LineRenderer>();
        }

        m_line = gameObject.GetComponent<LineRenderer>();
    }

    private void DesBullet()
    {
        m_shotCheck = false;
        m_player.m_isBullet = false;

        Destroy(this.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            DesBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            UiManager score = FindObjectOfType<UiManager>();
            score.ScoreUp();

            DesBullet();
            Destroy(collision.gameObject);
        }
    }
}
