using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Control : MonoBehaviour
{

    [SerializeField] private GameObject _popUpTutorial;
    private Animator _animatorPopUp;

   
    private bool _tutorialOpen;

    void Start()
    {
        _animatorPopUp = _popUpTutorial.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Action") && _tutorialOpen)
        {
            CloseTutorial();
            _tutorialOpen = false;
        }
    }

    public void OpenTutorial(string info)
    {
        Player_Manager _playerManager;

        _playerManager = FindObjectOfType<Player_Manager>();
        
        _playerManager.DisablePlayerMovement();
        _popUpTutorial.transform.GetChild(0).GetComponent<Text>().text = info;
        _animatorPopUp.SetTrigger("Open");
        _tutorialOpen = true;
    }

    private void CloseTutorial()
    {
        Player_Manager _playerManager;

        _playerManager = FindObjectOfType<Player_Manager>();
        _playerManager.EnablePlayerMovement();
        _animatorPopUp.SetTrigger("Close");
    }
    
    
}
