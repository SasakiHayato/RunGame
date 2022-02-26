/// <summary>
/// ゲーム全体を管理するクラス
/// </summary>

public enum GameState
{
    Title,
    InGame,
    End,
    Pause,
}

public class GameManager : SingletonAttribute<GameManager>
{
    
}
