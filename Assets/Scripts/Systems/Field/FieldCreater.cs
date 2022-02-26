using UnityEngine;

/// <summary>
/// 障害物の管理クラス
/// </summary>

public class FieldCreater : MonoBehaviour
{
    [SerializeField] ObstacleDataBase _obstacleData;
    [SerializeField] Vector2 _offSet;

    bool _isSet = false;
    float _timer = 0;
    float _createTimer = 0;

    void Update()
    {
        if (!_isSet) return;

        _timer += Time.deltaTime;
        if (_timer > _createTimer) Request();
    }

    void Request()
    {
        _timer = 0;
        _createTimer = Random.Range(1.0f, 3.0f);

        int randomID = Random.Range(1, _obstacleData.DataCount + 1);
        Create(_obstacleData.GetData(randomID));
    }

    void Create(ObstacleData data)
    {
        GameObject obj = Instantiate(data.Prefabs);
        obj.transform.position = _offSet;
    }

    public void SetUp()
    {   
        _isSet = true;
        _createTimer = Random.Range(1.0f, 3.0f);
    }

    public void End()
    {
        _isSet = false;
    }
}
