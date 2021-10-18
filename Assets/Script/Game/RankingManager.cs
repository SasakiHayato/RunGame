﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class RankingManager : MonoBehaviour
{
    [SerializeField] Text m_setText;
    [SerializeField] InputField m_name;
    [SerializeField] GameObject m_entryButton;
    float m_getScore;
    List<NCMBObject> m_ncmbList;

    public void SetUp(float score)
    {
        if (true) return;
        m_name.gameObject.SetActive(false);
        m_entryButton.SetActive(false);
        GetRanking(score);
    }

    public void GetRanking(float score)
    {
        m_getScore = score;
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("HighScore");
        query.OrderByDescending("Score");
        query.Limit = 7;

        query.FindAsync((List<NCMBObject> list, NCMBException e) =>
        {
            if (e != null)
                Debug.Log(e.ToString());
            else
            {
                m_ncmbList = list;

                if (m_ncmbList.Count < 7 && score != 0 || 
                    score > int.Parse(m_ncmbList[m_ncmbList.Count - 1]["Score"].ToString()))
                {
                    m_name.gameObject.SetActive(true);
                    m_entryButton.SetActive(true);
                }
                
                SetCanvas();
            }
        });
    }

    void SetCanvas()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        for (int i = 0; i < m_ncmbList.Count; i++)
        {
            builder.Append((i + 1).ToString());
            builder.Append(" : ");
            builder.Append(m_ncmbList[i]["Name"].ToString());
            builder.Append(" : ");
            builder.Append(m_ncmbList[i]["Score"].ToString());
            builder.Append("\n");
        }
        Debug.Log("Ranking Text:\r\n" + builder.ToString());
        m_setText.text = builder.ToString();
    }

    public void Save()
    {
        if (true) return;
        NCMBObject ncmb = new NCMBObject("HighScore");
        ncmb["Name"] = m_name.text;
        ncmb["Score"] = m_getScore;

        ncmb.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log(e.ToString());
            }
            else
            {
                Debug.Log("a");
                m_name.gameObject.SetActive(false);
                m_entryButton.SetActive(false);
                GetRanking(0);
            }
        });

    }
}
