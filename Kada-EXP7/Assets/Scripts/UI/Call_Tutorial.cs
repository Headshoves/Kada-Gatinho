using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call_Tutorial : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string info;

    private bool _active;
    

    private Tutorial_Control _tutorialControl;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !_active)
        {
            _tutorialControl = GameObject.Find("GameCanvas").GetComponent<Tutorial_Control>();
            _tutorialControl.OpenTutorial(info);
            _active = true;
        }
    }
}
