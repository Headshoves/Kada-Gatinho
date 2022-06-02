using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{

    [SerializeField] private float impulseJump;
    
    private Rigidbody2D _rb2d;
    private Player_Collision _playerCollision;
    private Player_Manager _playerManager;
    
    
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerCollision = Player_Collision.instance;
        _playerManager = Player_Manager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && _playerManager.CanDoAnything())
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (!_playerCollision.IsInAir())
        {
            //_rb2d.velocity = new Vector2(_rb2d.velocity.x, impulseJump);
            _rb2d.AddForce(new Vector2(0,impulseJump),ForceMode2D.Impulse);
        }
    }
}
