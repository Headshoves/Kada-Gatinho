using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{

    [SerializeField] private float impulseJump;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layer;
    
    private bool canJump;
    private Rigidbody2D _rb2d;
    
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    
    private void FixedUpdate()
    {
        canJump = Physics2D.OverlapCircle(groundCheck.position, 0.2f, layer);
    }
    
    public void Jump()
    {
        if (canJump)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, impulseJump);
            canJump = false;
        }
    }
}
