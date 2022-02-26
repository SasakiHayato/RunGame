using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        Inputter inputter = (Inputter)Inputter.GetInstance.Access();
        inputter.Inputs.Player.Fire.started += context => Jump();
    }

    void Update()
    {
        
    }

    void Jump()
    {
        Debug.Log("aaaaaaaaa");
    }
}
