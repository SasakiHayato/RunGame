using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class RankingManager : MonoBehaviour
{
    [SerializeField] Text m_setText;
    float m_getScore;
    List<NCMBObject> m_ncmbList;

    public void SetUp(float score)
    {
        GetRanking(score);
    }

    public void GetRanking(float score)
    {
        m_getScore = score;
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("HighScore");
        query.OrderByDescending("Score");
        query.Limit = 5;

        query.FindAsync((List<NCMBObject> list, NCMBException e) =>
        {
            if (e != null)
                Debug.Log(e.ToString());
            else
            {
                m_ncmbList = list;
                if (m_ncmbList.Count < 5 || score != 0)
                {
                    Debug.Log("ランクイン");
                    Save(m_getScore);
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

    public void Save(float score)
    {
        NCMBObject ncmb = new NCMBObject("HighScore");
        ncmb["Name"] = "v";
        ncmb["Score"] = score;

        ncmb.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log(e.ToString());
            }
            else
            {

            }
        });

    }
}
