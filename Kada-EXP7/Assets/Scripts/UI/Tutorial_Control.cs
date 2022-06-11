using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Control : MonoBehaviour
{

    [SerializeField] private GameObject _popUpTutorial;
    private Animator _animatorPopUp;

    private Player_Manager _playerManager;
    private bool _tutorialOpen;

    void Start()
    {
        _animatorPopUp = _popUpTutorial.GetComponent<Animator>();
        _playerManager = FindObjectOfType<Player_Manager>();
    }

    void Update()
    {
        if (Input.GetButton("Jump") && _tutorialOpen)
        {
            CloseTutorial();
            _tutorialOpen = false;
        }
    }

    public void OpenTutorial(string info)
    {
        if (TryGetComponent(out _playerManager))
        {
            _playerManager.DisablePlayerMovement();
            _popUpTutorial.transform.GetChild(0).GetComponent<Text>().text = info;
            _animatorPopUp.SetTrigger("Open");
            _tutorialOpen = true;
        }
    }

    private void CloseTutorial()
    {
        _playerManager.EnablePlayerMovement();
        _animatorPopUp.SetTrigger("Close");
    }
    
    
}
