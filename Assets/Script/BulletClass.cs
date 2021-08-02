using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    private float m_angleSin = 0;

    private bool m_shotCheck = false;
    
    private Vector2 vector = Vector2.zero;

    private Rigidbody2D m_rigidbody;
    private PlayerManager m_player;

    void Start()
    {
        m_player = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            m_angleSin += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (m_shotCheck) return;

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

        vector = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

        return vector;
    }

    private void AddRb2D()
    {
        if (m_rigidbody == null)
        {
            m_rigidbody = this.gameObject.AddComponent<Rigidbody2D>();
        }

        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void DesBullet()
    {
        Destroy(this.gameObject);

        m_shotCheck = false;
        m_player.m_isBullet = false;
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
            
            ScoreClass score = FindObjectOfType<ScoreClass>();
            score.ScoreUp();

            DesBullet();
            Destroy(collision.gameObject);
        }
    }
}
