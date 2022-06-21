using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Slide_Stone : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _stone;
    [SerializeField] private int _qtdEssence;
    [SerializeField] private float _timeToAction;
    
    [SerializeField] private Light2D _light2D;

    
    private bool _canActive;

    private Player_Essence _playerEssence;
    private Player_Manager _playerManager;
    
    void Start()
    {
        _playerEssence = FindObjectOfType<Player_Essence>();
        _playerManager = FindObjectOfType<Player_Manager>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("ActiveStone") && _canActive && _playerManager.CanDoAnything())
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
            _light2D.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canActive = false;
            _light2D.enabled = false;
        }
    }
}
