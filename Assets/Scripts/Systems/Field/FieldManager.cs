using UnityEngine;

/// <summary>
/// Field全体の管理クラス
/// </summary>

public class FieldManager : SingletonAttribute<FieldManager>
{
    public enum ExecuteType
    {
        Start,
        End,
    }

    public override void SetUp()
    {
        base.SetUp();
    }

    public void Execute(ExecuteType type)
    {
        FieldCreater creater = Object.FindObjectOfType<FieldCreater>();

        if (type == ExecuteType.Start)
        {
            creater.SetUp();
        }
        else
        {
            creater.End();
        }
    }
}
