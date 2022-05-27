using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{

    private Player_Essence _playerEssence;

    private void Start()
    {
        _playerEssence = Player_Essence.instance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("StoneEssence"))
        {
            _playerEssence.AddStoneEssence();
            col.gameObject.SetActive(false);
        }
        
        if (col.gameObject.CompareTag("TreeEssence"))
        {
            _playerEssence.AddTreeEssence();
            col.gameObject.SetActive(false);
        }
    }
}
