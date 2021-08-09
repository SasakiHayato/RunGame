using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerClass : PlayerManager
{
    [SerializeField] private float m_speed = 0;
    [SerializeField] private float m_jumpPower = 0;

    private BulletClass m_bullet;
    void Start()
    {
        m_bullet = FindObjectOfType<BulletClass>();

        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameManager.Instance.Cureated()) return;

        Move();
        GroundCheck();

        if (Input.GetButtonDown("JoystickJump") )
        {
            Jump();
        }

        if (!m_isBullet)
        {
            if (Input.GetButtonDown("JoystickShot"))
            {
                SetBullet();
            }
        }
        
        if (Input.GetButton("JoystickShot"))
        {
            m_animator.Play("HouseShotReady");
        }
        if (Input.GetButtonUp("JoystickShot"))
        {
            m_animator.Play("HouseShot");
        }

        if (Input.GetButtonDown("JoystickShield") && !m_isShield)
        {
            SetShield();
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
        if (m_cureatedJumpCount == 0) return;
        
        m_rigidbody.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
        m_cureatedJumpCount--;
    }
}
