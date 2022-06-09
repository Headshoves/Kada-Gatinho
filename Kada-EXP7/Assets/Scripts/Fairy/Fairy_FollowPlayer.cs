using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy_FollowPlayer : MonoBehaviour
{
    
    [SerializeField] private Vector2 _offsetPlayer;
    [SerializeField] private float _interpolateAmount = 1;
    
    [SerializeField] private float _amplitude = 0.2f;
    [SerializeField] private float _frequency = 1f;

    private float _startY;

    private Transform _player;
    private SpriteRenderer _playerSR;
    
    private Transform _staffPos;
    private Transform _fairy;

    private bool _inRange;
    private bool idle;
    private float sinY;

    void Start()
    {
        _player = FindObjectOfType<Player_Manager>().transform;
        _playerSR = FindObjectOfType<Player_Manager>().gameObject.GetComponent<SpriteRenderer>();
        _fairy = transform.GetChild(0);

        _startY = _fairy.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        sinY = Mathf.Sin(Time.time * _frequency) * _amplitude;
        
    }

    private void FixedUpdate()
    {
        _fairy.localPosition = new Vector2(_fairy.localPosition.x, _startY + sinY);

        if (_playerSR.flipX)
        {
            if (!_inRange)
            {
                transform.position = Vector2.Lerp(transform.position, 
                    new Vector2(_player.position.x - _offsetPlayer.x, _player.position.y + _offsetPlayer.y), _interpolateAmount);
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position,_fairy.position, 1);
            }
        }
        else
        {
            if (!_inRange)
            {
                transform.position = Vector2.Lerp(transform.position, 
                    new Vector2(_player.position.x + _offsetPlayer.x, _player.position.y + _offsetPlayer.y), _interpolateAmount);
            }
        }
    }
}
