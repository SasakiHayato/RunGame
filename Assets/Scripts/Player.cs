﻿using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        Inputter.Access.Inputs.Player.Fire.started += context => Jump();
    }

    void Update()
    {
        
    }

    void Jump()
    {
        
    }
}
