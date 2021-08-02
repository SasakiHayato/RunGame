﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerClass : PlayerManager
{
    [SerializeField] private float m_speed = 0;
    [SerializeField] private float m_jumpPower = 0;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if (!GameManager.Instance.Cureated()) return;

        Move();
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (m_isBullet) return;
            SetBullet();
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h < 0) { h = h / 2; }

        m_rigidbody.velocity = new Vector2(m_speed * h, m_rigidbody.velocity.y);
    }

    private void Jump()
    {
        m_rigidbody.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
    }
}
