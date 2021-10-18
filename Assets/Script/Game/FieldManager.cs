using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Field;
using System.Linq;

public class FieldManager :MonoBehaviour
{
    [SerializeField] float m_createTime;
    [SerializeField] float m_scrollSpeed;

    [SerializeField] Transform[] m_spawnPoses = new Transform[0];
    [SerializeField] GameObject[] m_groundPrefabs = new GameObject[0];
    [SerializeField] Transform[] m_obstaclePoses = new Transform[0];
    [SerializeField] GameObject[] m_obstaclePrefabs = new GameObject[0];

    CreateGround m_ground = new CreateGround();
    ScrollGorund m_scroll = new ScrollGorund();
    CreateObstacle m_obstacle = new CreateObstacle();

    GameObject m_groundObj;

    void Start()
    {
        m_groundObj = GameObject.Find("FieldGround");
        m_scroll.Add(m_groundObj);
    }
    void Update()
    {
        if (!GameManager.Instance.Cureated()) return;

        if (m_ground.Check(m_createTime))
            m_ground.Instantiate(m_groundPrefabs, m_spawnPoses, m_scroll);

        if (m_obstacle.Check(3))
            m_obstacle.Instantiate(m_obstaclePrefabs, m_obstaclePoses);

        m_scroll.Update(m_scrollSpeed * -1);
    }
}

namespace Field
{
    class CreateGround
    {
        float m_timer = 0;

        public bool Check(float thisTime)
        {
            bool check = false;
            m_timer += GameManager.Instance.Timer();
            
            if (m_timer >= thisTime)
            {
                m_timer = 0;
                check = true;
            }
            
            return check;
        }

        public void Instantiate(GameObject[] objects, Transform[] targets, ScrollGorund scroll)
        {
            int oRandom = Random.Range(0, objects.Length);
            int tRandom = Random.Range(0, targets.Length);
            
            GameObject set = MonoBehaviour.Instantiate(objects[oRandom], targets[tRandom]);
            scroll.Add(set);
        }
    }

    class ScrollGorund
    {
        List<GameObject> m_objList = new List<GameObject>();

        public void Add(GameObject target) => m_objList.Add(target);

        public void Update(float speed)
        {
            if (m_objList.Count == 0) return;
            
            foreach (GameObject target in m_objList)
                target.transform.Translate(speed * Time.deltaTime, 0, 0);

            if (m_objList.Count > 6)
            {
                GameObject target = m_objList.First();
                m_objList.Remove(target);
                MonoBehaviour.Destroy(target);
            }   
        }
    }

    class CreateObstacle
    {
        float m_timer = 0;

        public bool Check(float thisTime)
        {
            bool check = false;
            m_timer += GameManager.Instance.Timer();

            if (m_timer >= thisTime)
            {
                m_timer = 0;
                check = true;
            }

            return check;
        }

        public void Instantiate(GameObject[] objects, Transform[] targets)
        {
            int oRandom = Random.Range(0, objects.Length);
            int tRandom = Random.Range(0, targets.Length);

            MonoBehaviour.Instantiate(objects[oRandom], targets[tRandom]);
        }
    }
}

