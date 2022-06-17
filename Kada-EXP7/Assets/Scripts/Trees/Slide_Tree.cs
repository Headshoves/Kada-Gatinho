using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Slide_Tree : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _tree;
    [SerializeField] private int _qtdEssence;
    [SerializeField] private float _timeToAction;
    [SerializeField] private bool _grownUp;
    
    private Vector3 _treeStartPos;

    
    private bool _canActive;

    private Player_Essence _playerEssence;
    private Player_Manager _playerManager;
    private Fairy_ChangeColor _fairyChangeColor;
    
    void Start()
    {
        _treeStartPos = _tree.position;
        _playerEssence = FindObjectOfType<Player_Essence>();
        _playerManager = FindObjectOfType<Player_Manager>();
        _fairyChangeColor = FindObjectOfType<Fairy_ChangeColor>();

        if (_grownUp)
        {
            _tree.position = _target.position;
        }
        else
        {
            _tree.position = _treeStartPos;
        }
    }

    
    void Update()
    {
        if (Input.GetButtonDown("ActiveTree") && _canActive && _playerManager.CanDoAnything())
        {
            if (_grownUp)
            {
                _tree.DOMove(_treeStartPos, _timeToAction);
                _playerEssence.AddTreeEssence(_qtdEssence);
                _grownUp = !_grownUp;
            }
            else if (!_grownUp && _playerEssence.CanUseTreeEssence(_qtdEssence))
            {
                _tree.DOMove(_target.position, _timeToAction);
                _playerEssence.UseTreeEssence(_qtdEssence);
                _grownUp = !_grownUp;
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
