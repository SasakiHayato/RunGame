using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    private float m_desTime = 0;
    private float m_angleSin = 0;

    private bool m_shotCheck = false;

    private Vector2 vector = Vector2.zero;
    public Rigidbody2D m_rigidbody { get; set; }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            m_angleSin += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Vector2 angleVec = SetAngle(m_angleSin) * 15;
            Shot(angleVec);
        }

        if (!m_shotCheck) return;

        m_desTime += Time.deltaTime;
        if (m_desTime > 2)
        {
            Destroy(this.gameObject);
            m_desTime = 0;

            m_shotCheck = false;
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

    public void AddRb2D()
    {
        if (m_rigidbody == null)
        {
            m_rigidbody = this.gameObject.AddComponent<Rigidbody2D>();
        }

        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
}
