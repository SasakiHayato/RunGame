using System.Collections;
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
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameManager.Instance.Cureated()) return;

        Move();
        GroundCheck();

        if (Input.GetButtonDown("JoystickJump") || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        if (!m_isBullet)
        {
            if (Input.GetButtonDown("JoystickShot") || Input.GetMouseButtonDown(0))
            {
                SetBullet();
            }
        }
        
        if (Input.GetButton("JoystickShot") || Input.GetMouseButton(0))
        {
            m_animator.Play("HouseShotReady");
        }
        if (Input.GetButtonUp("JoystickShot") || Input.GetMouseButtonUp(0))
        {
            m_animator.Play("HouseShot");
        }

        if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("JoystickShield") && !m_isShield && m_shieldmeter.m_setShield)
        {
            SetShield();
            m_shieldmeter.m_setShield = false;
            m_shieldmeter.ResetMeterImage();
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h < 0) { h = h / 2; }
        if (h < 0) 
        { 
            m_shieldmeter.m_meterTime += Time.deltaTime;
            if (m_shieldmeter.m_meterTime > 2)
            {
                m_shieldmeter.SetMeterImage();
                m_shieldmeter.m_meterTime = 0;
            }
        }

        m_rigidbody.velocity = new Vector2(m_speed * h, m_rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (m_cureatedJumpCount == 0) return;
        
        m_rigidbody.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
        m_cureatedJumpCount--;
    }
}
