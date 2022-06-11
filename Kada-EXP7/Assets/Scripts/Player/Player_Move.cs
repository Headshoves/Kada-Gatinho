using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField] private float speedInGround;
    
    private Rigidbody2D _rb2d;
    private SpriteRenderer _sr;
    private Player_Manager _playerManager;

    private float _tempAxis;
    
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _playerManager = GetComponent<Player_Manager>();
    }

    private void Update()
    {
        _tempAxis = Input.GetAxisRaw("Horizontal");
        
        if (_tempAxis<0)
        {
            _sr.flipX = true;
        }
        else if (_tempAxis>0)
        {
            _sr.flipX = false;
        }
    }
    
    void FixedUpdate()
    {
        if (_playerManager.CanDoAnything())
        {
            _rb2d.velocity = new Vector2(speedInGround*_tempAxis*Time.fixedDeltaTime, _rb2d.velocity.y);
        }
    }

    private void OnDisable()
    {
        _rb2d.velocity = Vector2.zero;
    }
}
