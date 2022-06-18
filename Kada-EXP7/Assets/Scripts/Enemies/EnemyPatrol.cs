using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float speed;
    
    private bool right;

    private SpriteRenderer _sr;
    private Rigidbody2D _rb2d;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (right)
        {
            _sr.flipX = true;
        }
        else
        {
            _sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        if (right)
        {
            _rb2d.velocity = new Vector2(speed * (1), _rb2d.velocity.y);
        }
        else
        {
            _rb2d.velocity = new Vector2(speed * (-1), _rb2d.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PointA"))
        {
            right = true;
        }
        
        if (col.CompareTag("PointB"))
        {
            right = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Stop());
        }
    }

    private IEnumerator Stop()
    {
        float startSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(1f);
        speed = startSpeed;

    }
}
