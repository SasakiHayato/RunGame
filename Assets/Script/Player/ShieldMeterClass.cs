using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMeterClass : MonoBehaviour
{
    [SerializeField] private int m_meter;
    private int m_count = 0;
    private int m_maxCount = 0;
    public bool m_setShield { get; set; }

    public float m_meterTime { get; set; }

    private GameObject[] m_imageObs;

    void Start()
    {
        m_setShield = false;
        m_maxCount = m_meter;
        m_imageObs = new GameObject[m_meter];

        for (int i = 0; i < m_meter; i++)
        {
            m_imageObs[i] = this.gameObject.transform.GetChild(i).gameObject;
            m_imageObs[i].SetActive(false);
        }
    }

    public void SetMeterImage()
    {
        if (m_count == m_maxCount)
        {
            m_setShield = true;
        }
        else
        {
            m_imageObs[m_count].SetActive(true);
            m_count++;
        }
    }

    public void ResetMeterImage()
    {
        for (int i = 0; i < m_maxCount; i++)
        {
            m_imageObs[i].SetActive(false);
        }

        m_count = 0;
    }

    public bool GetShieldBool()
    {
        return m_setShield;
    }
}
