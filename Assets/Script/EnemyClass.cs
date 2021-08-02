using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;

    void Start()
    {
        AddRb2D();
        Shot();
    }

    private void AddRb2D()
    {
        if (m_rigidbody == null)
        {
            m_rigidbody = this.gameObject.AddComponent<Rigidbody2D>();
        }

        m_rigidbody.GetComponent<Rigidbody2D>();
    }

    private void Shot()
    {
        Vector2 force = Angle();
        m_rigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    private Vector2 Angle()
    {
        Vector2 vector = Vector2.zero;

        int randomX = Random.Range(3, 10);
        int randomY = Random.Range(3, 5);

        vector = new Vector2(randomX * -1, randomY);

        return vector;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            Destroy(this.gameObject);
        }
    }
}
