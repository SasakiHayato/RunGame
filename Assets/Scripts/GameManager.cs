
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
    public GameState CurrentState { get; private set; } = GameState.Title;

    public override void SetUp()
    {

    }

    public void ChangeGameState(GameState state)
    {
        CurrentState = state;

        switch (state)
        {
            case GameState.Title:
                break;
            case GameState.InGame:
                break;
            case GameState.EndGame:
                break;
        }

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
                break;
            case GameState.EndGame:
                break;
        }
    }
}
