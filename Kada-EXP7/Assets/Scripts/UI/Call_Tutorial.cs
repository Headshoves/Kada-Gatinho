using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call_Tutorial : MonoBehaviour
{
    [SerializeField] private string info;
    
    public enum CallTutorialOptions
    {
        Disable, Collision
    }

    public CallTutorialOptions callTutorialOptions;

    private Tutorial_Control _tutorialControl;
    
    void Start()
    {
        _tutorialControl = Tutorial_Control.instance;
    }

    private void OnDisable()
    {

        switch (callTutorialOptions)
        {
            case CallTutorialOptions.Disable:
                _tutorialControl.OpenTutorial(info);
                break;
        }
    }
}
