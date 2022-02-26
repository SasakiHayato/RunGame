using UnityEngine;

/// <summary>
/// ゲーム全体を管理するクラス
/// </summary>

public enum GameState
{
    Title,
    InGame,
    EndGame,
}

public class GameManager : SingletonAttribute<GameManager>
{
    public GameState CurrentState { get; private set; }

    public override void SetUp()
    {
        CurrentState = GameState.Title;
        Object.Instantiate((GameObject)Resources.Load("Systems/SoundMaster"));
    }

    public void ChangeGameState(GameState state)
    {
        CurrentState = state;
        GameStateEvents(state);
    }

    void GameStateEvents(GameState state)
    {
        UIManager.Access.SetPanel(state);

        switch (state)
        {
            case GameState.Title:
                break;
            case GameState.InGame:
                Object.Instantiate((GameObject)Resources.Load("Systems/FieldCreater"));
                FieldManager.Access.Execute(FieldManager.ExecuteType.Start);
                break;
            case GameState.EndGame:
                FieldManager.Access.Execute(FieldManager.ExecuteType.End);
                break;
        }
    }
}
