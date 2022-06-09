using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Platform_Move : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _pointC;
    private Transform _pointAB_BC;

    [SerializeField] private float _duration;
    [SerializeField] private int _qtdEssence;

    [SerializeField] private bool go;
    private bool active;
    private bool _canActive;
    private bool playerInPlatform;

    private Player_Essence _playerEssence;
    private Player_Manager _playerManager;
    
    void Start()
    {
        _pointAB_BC = transform;
        
        _playerEssence = Player_Essence.instance;
        _playerManager = Player_Manager.instance;

        if (!go)
        {
            _pointAB_BC.transform.position = _pointA.transform.position;
        }
        else
        {
            _pointAB_BC.transform.position = _pointC.transform.position;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)  && _canActive && _playerManager.CanDoAnything())
        {
            if (_playerEssence.CanUseTreeEssence(_qtdEssence))
            {
                _playerEssence.UseTreeEssence(_qtdEssence);
                go = !go;
                active = true; 
            }
        }

    }

    
    void FixedUpdate()
    {
        if (active)
        {

            if (go)
            {
                active = false;
                _pointAB_BC.DOMove(_pointB.transform.position, _duration).OnComplete(() =>
                    _pointAB_BC.DOMove(_pointC.transform.position, _duration));
                
            }
            else
            {
                active = false;
                _pointAB_BC.DOMove(_pointB.transform.position, _duration).OnComplete(() =>
                    _pointAB_BC.DOMove(_pointA.transform.position, _duration));
                
            }
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _canActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canActive = false;
        }
    }
}
