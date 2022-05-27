using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody2D _rb2d;
    private SpriteRenderer _sr;
    
    
    
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float temp = Input.GetAxisRaw("Horizontal");
        _rb2d.velocity = new Vector2(speed*temp, _rb2d.velocity.y);

    }
}
