using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerClass : MonoBehaviour
{
    [SerializeField] private float m_speed = 0;
    [SerializeField] private float m_jumpPower = 0;

    private Rigidbody2D m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            Debug.Log("Dead");
        }
    }
}
