using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager :MonoBehaviour
{
    
    private Player_Move _playerMove;
    private Player_Jump _playerJump;

    private bool canDoAnything;

    public Vector3 _playerStartPos;

    private void Start()
    {
        _playerJump = GetComponent<Player_Jump>();
        _playerMove = GetComponent<Player_Move>();
        canDoAnything = true;
        _playerStartPos = transform.position;
    }

    public void DisablePlayerMovement()
    {
        if (TryGetComponent(out _playerJump))
        {
            _playerJump.enabled = false;
        }

        if (TryGetComponent(out _playerMove))
        {
            _playerMove.enabled = false;  
        }
        
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
