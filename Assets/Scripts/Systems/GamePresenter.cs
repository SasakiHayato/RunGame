using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    void Awake()
    {
        Inputter inputter = new Inputter();
        Inputter.SetInstance(inputter);
    }
}
