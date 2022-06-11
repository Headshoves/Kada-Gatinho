using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour
{

    private Player_Manager _playerManager;
    
    void Start()
    {
        _playerManager = GetComponent<Player_Manager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("DeathZone"))
        {
            StartCoroutine(Death());
        }
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        _playerManager.DisablePlayerMovement();

        yield return new WaitForSeconds(1f);

        transform.position = _playerManager._playerStartPos;
        _playerManager.EnablePlayerMovement();
    }
}
