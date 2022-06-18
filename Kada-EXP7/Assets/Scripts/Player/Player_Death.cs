using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour
{

    private Player_Manager _playerManager;
    private Player_Animations _animations;

    private bool die;
    
    void Start()
    {
        _playerManager = GetComponent<Player_Manager>();
        _animations = GetComponent<Player_Animations>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("DeathZone") && !die)
        {
            StartCoroutine(Death());
            die = true;
        }
        
        if (col.gameObject.CompareTag("Enemy") && !die)
        {
            StartCoroutine(Death());
            die = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy") && !die)
        {
            StartCoroutine(Death());
            die = true;
        }
    }

    private IEnumerator Death()
    {
        _playerManager.DisablePlayerMovement();
        _animations.DeathAnim();

        yield return new WaitForSeconds(1f);

        transform.position = _playerManager._playerStartPos;
        _playerManager.EnablePlayerMovement();
        die = false;
    }
}
