using UnityEngine;

/// <summary>
/// UI全体の管理クラス
/// </summary>

public class UIManager : SingletonAttribute<UIManager>
{
    GameObject _currentPanel = null;
    Canvas _canvas;

    public override void SetUp()
    {
        base.SetUp();
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void SetPanel(GameState state)
    {
        if (_currentPanel != null) Object.Destroy(_currentPanel);

        GameObject panel = Object.Instantiate((GameObject)Resources.Load($"UI/{state.ToString()}Panel"));
        _currentPanel = panel;

        panel.transform.SetParent(_canvas.transform);
        panel.transform.localScale = Vector2.one;
        panel.transform.position = _canvas.transform.position;
    }
}
