using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    public static Player_Collision instance;

    private Player_Essence _playerEssence;

    [SerializeField] private LayerMask layer;
    
    private bool _inAir;
    private Transform groundCheck;

    private void Awake()
    {
        instance = this;
        groundCheck = transform.GetChild(0);
    }

    private void Start()
    {
        _playerEssence = Player_Essence.instance;
    }
    
    private void FixedUpdate()
    {
        _inAir = Physics2D.OverlapCircle(groundCheck.position, 0.2f, layer);
    }

    public bool IsInAir()
    {
        return !_inAir;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("StoneEssence"))
        {
            _playerEssence.AddStoneEssence(1);
            col.gameObject.SetActive(false);
        }
        
        if (col.gameObject.CompareTag("TreeEssence"))
        {
            _playerEssence.AddTreeEssence(1);
            col.gameObject.SetActive(false);
        }
    }
}
