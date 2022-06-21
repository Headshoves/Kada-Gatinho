using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Call_Tutorial : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string info;

    [SerializeField] private bool fim;

    private bool _active;
    

    private Tutorial_Control _tutorialControl;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !_active)
        {
            _tutorialControl = GameObject.Find("GameCanvas").GetComponent<Tutorial_Control>();
            _tutorialControl.OpenTutorial(info);
            _active = true;
            if (fim)
            {
                StartCoroutine(Fim());
            }
        }
    }

    private IEnumerator Fim()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}
