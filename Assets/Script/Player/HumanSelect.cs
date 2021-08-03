using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSelect : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] m_sprite = null;
    
    private GameObject m_parent;

    void Start()
    {
        int random = Random.Range(0, m_sprite.Length);
        m_parent = transform.root.gameObject;

        Instantiate(m_sprite[random].gameObject, m_parent.transform);
    }
}
