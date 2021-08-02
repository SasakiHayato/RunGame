using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject m_bullet = null;
    public Rigidbody2D m_rigidbody { get; set; }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            GameManager.Instance.EndPlay();
        }
    }

    public void SetBullet()
    {
        GameObject bullet = Instantiate(m_bullet);
        bullet.transform.position = this.transform.position;
    }
}
