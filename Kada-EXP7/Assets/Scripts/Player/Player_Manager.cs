using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public static Player_Manager instance;
    
    private Player_Move _playerMove;
    private Player_Jump _playerJump;

    private bool canDoAnything;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _playerMove = GetComponent<Player_Move>();
        _playerJump = GetComponent<Player_Jump>();
        canDoAnything = true;
    }

    public void DisablePlayerMovement()
    {
        _playerJump.enabled = false;
        _playerMove.enabled = false;
        canDoAnything = false;
    }
    
    public void EnablePlayerMovement()
    {
        _playerJump.enabled = true;
        _playerMove.enabled = true;
        canDoAnything = true;
    }

    public bool CanDoAnything()
    {
        return canDoAnything;
    }
}
