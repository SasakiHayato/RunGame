using UnityEngine;

public enum InputType
{
    
}

/// <summary>
/// InputSystemの管理クラス
/// </summary>

public class Inputter : SingletonAttribute<Inputter>, ISingleton
{
    public InputData Inputs { get; private set; }

    public void SetUp()
    {
        Inputs = new InputData();
        Inputs.Enable();
    }

    public object Type() => this;

    // 今後、必要な時に追加
    public object GetValue(InputType type)
    {
        object val = null;

        switch (type)
        {
            default:
                break;
        }
        return val;
    }
}
