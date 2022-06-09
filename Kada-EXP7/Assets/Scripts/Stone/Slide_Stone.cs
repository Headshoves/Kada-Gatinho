using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Slide_Stone : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _stone;
    [SerializeField] private int _qtdEssence;
    [SerializeField] private float _timeToAction;
    

    
    private bool _canActive;

    private Player_Essence _playerEssence;
    private Player_Manager _playerManager;
    
    void Start()
    {
        _playerEssence = Player_Essence.instance;
        _playerManager = Player_Manager.instance;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && _canActive && _playerManager.CanDoAnything())
        {
            _stone.DOMove(_target.position, _timeToAction);
            _playerEssence.UseStoneEssence(_qtdEssence);
            this.enabled = false;
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
