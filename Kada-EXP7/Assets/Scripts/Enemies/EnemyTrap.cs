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
        yield return new WaitForSeconds(_timeToActive);

        _trap.DOMove(transform.position, _timeToUp);
    }
}
