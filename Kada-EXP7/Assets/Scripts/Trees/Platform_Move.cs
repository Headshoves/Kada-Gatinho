using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Platform_Move : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    private Transform _pointAB_BC;

    [SerializeField] private float _duration;
    [SerializeField] private int _qtdEssence;

    [SerializeField] private bool go;
    private bool active;
    private bool _canActive;
    private bool playerInPlatform;

    private Player_Essence _playerEssence;
    private Player_Manager _playerManager;
    private Fairy_ChangeColor _fairyChangeColor;
    
    void Start()
    {
        _pointAB_BC = transform;
        
        _playerEssence = FindObjectOfType<Player_Essence>();
        _playerManager = FindObjectOfType<Player_Manager>();
        _fairyChangeColor = FindObjectOfType<Fairy_ChangeColor>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)  && _canActive && _playerManager.CanDoAnything())
        {
            if (active)
            {
                _playerEssence.AddTreeEssence(_qtdEssence);
                active = false;
            }
            else
            {
                if (_playerEssence.CanUseTreeEssence(_qtdEssence))
                {
                    _playerEssence.UseTreeEssence(_qtdEssence);
                    go = !go;
                    active = true; 
                }
            }
            
            
        }
        else if (Input.GetKeyDown(KeyCode.J)  && _canActive && active)
        {
            
        }
    }

    
    void FixedUpdate()
    {
        if (active)
        {

            if (go)
            {
                go = false;
                _pointAB_BC.DOMove(_pointB.transform.position, _duration).OnComplete(() =>
                    _pointAB_BC.DOMove(_pointA.transform.position, _duration).OnComplete(()=> go = true));
            }
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _canActive = true;
            _fairyChangeColor.InTreeRange();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canActive = false;
            _fairyChangeColor.OutRange();
        }
    }
}
