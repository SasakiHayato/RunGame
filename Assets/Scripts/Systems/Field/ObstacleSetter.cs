using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 障害物の生成クラス
/// </summary>

public class ObstacleSetter : MonoBehaviour
{
    enum ActiveType
    {
        Random,
        Order,
    }

    [SerializeField] ActiveType _type;
    [SerializeField] float _activeDelayTime;

    List<ObstacleOption> _obstacles;

    float _timer = 0;
    bool _isSetUp = false;

    int _id = 0;

    void Update()
    {
        if (!_isSetUp) return;

        _timer += Time.deltaTime;
        if (_timer > _activeDelayTime)
        {
            _timer = 0;

            if (_id >= _obstacles.Count)
            {
                Delete();
                return;
            }

            ObstacleOption obstacle = _obstacles[_id];
            obstacle.gameObject.SetActive(true);
            obstacle.Use();

            _id++;
        }
    }

    public void SetUp()
    {
        _obstacles = new List<ObstacleOption>();

        ObstacleOption[] objects = transform.GetComponentsInChildren<ObstacleOption>();
        for (int i = 0; i < objects.Length; i++)
        {
            _obstacles.Add(objects[i]);
            objects[i].gameObject.SetActive(false);
        }

        _isSetUp = true;
    }

    void Delete()
    {
        if (!_obstacles.All(o => o.IsUse)) return;
        
        Destroy(gameObject);
    }
}
