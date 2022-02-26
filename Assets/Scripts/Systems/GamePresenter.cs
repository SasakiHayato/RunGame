using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    void Awake()
    {
        Inputter inputter = new Inputter();
        Inputter.SetInstance(inputter);

        GameManager gameManager = new GameManager();
        GameManager.SetInstance(gameManager);
    }
}
