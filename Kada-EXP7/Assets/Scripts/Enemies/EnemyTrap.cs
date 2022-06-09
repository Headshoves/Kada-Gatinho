using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyTrap : MonoBehaviour
{
    [SerializeField] private Transform _trap;
    [SerializeField] private float _timeToActive;
    [SerializeField] private float _timeToUp;
    [SerializeField] private float _resetTrap;
    [SerializeField] private float _timeToDown;

    private Vector2 _startPos;
    private Collider2D _col;

    private void Start()
    {
        _startPos = _trap.position;
        _col = GetComponent<Collider2D>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine("ActiveTrap");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine("ActiveTrap");
        }
    }

    private IEnumerator ActiveTrap()
    {
        _col.enabled = false;
        
        yield return new WaitForSeconds(_timeToActive);

        _trap.DOMove(transform.position, _timeToUp);

        yield return new WaitForSeconds(_resetTrap);

        _trap.DOMove(_startPos, _timeToDown).OnComplete(() => _col.enabled = true);
    }

    
    
}
