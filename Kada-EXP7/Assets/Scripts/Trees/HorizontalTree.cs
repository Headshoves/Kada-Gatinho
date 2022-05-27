using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HorizontalTree : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _tree;
    [SerializeField] private int _qtdEssence;
    [SerializeField] private float _timeToAction;

    private Vector3 _treeStartPos;

    private bool _grownUp;
    private bool _canActive;

    private Player_Essence _playerEssence;
    
    void Start()
    {
        _treeStartPos = _tree.position;
        _playerEssence = Player_Essence.instance;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && _canActive && _playerEssence.CanUseTreeEssence(_qtdEssence))
        {
            if (_grownUp)
            {
                _tree.DOMove(_treeStartPos, _timeToAction);
                _playerEssence.UseTreeEssence(_qtdEssence);
            }
            else
            {
                _tree.DOMove(_target.position, _timeToAction);
                _playerEssence.UseTreeEssence(_qtdEssence);
            }
            _grownUp = !_grownUp;
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
