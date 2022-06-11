using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call_Tutorial : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string info;

    private bool _active;
    
    public enum CallTutorialOptions
    {
        Disable, Collision
    }

    public CallTutorialOptions callTutorialOptions;

    private Tutorial_Control _tutorialControl;
    
    void Start()
    {
        _tutorialControl = FindObjectOfType<Tutorial_Control>();
    }

    private void OnDisable()
    {
        if (Application.isPlaying == false)
        {
            return;
        }
        if (callTutorialOptions == CallTutorialOptions.Disable)
        {
            if (TryGetComponent(out _tutorialControl))
            {
                _tutorialControl.OpenTutorial(info);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && callTutorialOptions == CallTutorialOptions.Collision && !_active)
        {
            _tutorialControl.OpenTutorial(info);
            _active = true;
        }
    }
}
