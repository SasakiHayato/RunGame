using UnityEngine;

/// <summary>
/// ゲーム開始時のSetupクラス
/// </summary>

public class GamePresenter : MonoBehaviour
{
    [SerializeField] GameState _setGameState;
  
    void Awake()
    {
        Inputter inputter = new Inputter();
        Inputter.SetInstance(inputter, inputter);

        GameManager gameManager = new GameManager();
        GameManager.SetInstance(gameManager, gameManager);

        UIManager uIManager = new UIManager();
        UIManager.SetInstance(uIManager, uIManager);
    }

    void Start()
    {
        GameManager.Access.ChangeGameState(_setGameState);
    }
}
