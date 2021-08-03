using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject m_bullet = null;
    public Rigidbody2D m_rigidbody { get; set; }

    public bool m_isBullet { get; set; }

    [SerializeField] private int m_maxJumpCount = 0;
    public int m_cureatedJumpCount { get; set; }

    [SerializeField] Vector2 m_groundRay = Vector2.zero;
    [SerializeField] LayerMask m_layer = 0;

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, m_groundRay, m_groundRay.magnitude, m_layer);
        if (hit.collider)
        {
            m_cureatedJumpCount = m_maxJumpCount;
        }
        
    }

    public void SetBullet()
    {
        m_isBullet = true;

        GameObject bullet = Instantiate(m_bullet);
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            GameManager.Instance.EndPlay();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
    }
}
