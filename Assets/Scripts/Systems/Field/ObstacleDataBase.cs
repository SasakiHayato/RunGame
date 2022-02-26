using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 障害物のデータクラス
/// </summary>

[CreateAssetMenu (fileName = "ObstacleData")]
public class ObstacleDataBase : ScriptableObject
{
    [SerializeField] List<ObstacleData> _datas;
    public int DataCount => _datas.Count;

    public ObstacleData GetData(int id)
    {
        foreach (var data in _datas)
            if (data.ID == id) return data;

        return null;
    }
}

[System.Serializable]
public class ObstacleData
{
    public int ID;
    public GameObject Prefabs;
}

