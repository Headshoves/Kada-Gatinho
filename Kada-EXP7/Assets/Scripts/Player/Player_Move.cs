using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody2D _rb2d;
    private SpriteRenderer _sr;

    private float _tempAxis;
    
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _tempAxis = Input.GetAxisRaw("Horizontal");
    }
    
    void FixedUpdate()
    {

        _rb2d.velocity = new Vector2(speed*_tempAxis*Time.fixedDeltaTime, _rb2d.velocity.y);

    }
}
