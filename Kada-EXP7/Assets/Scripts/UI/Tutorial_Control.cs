using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Control : MonoBehaviour
{
    public static Tutorial_Control instance;

    [SerializeField] private GameObject _popUpTutorial;
    private Animator _animatorPopUp;

    private Player_Manager _playerManager;
    private bool _tutorialOpen;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _animatorPopUp = _popUpTutorial.GetComponent<Animator>();
        _playerManager = Player_Manager.instance;
    }

    // Update is called once per frame
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
        _playerManager.DisablePlayerMovement();
        _popUpTutorial.transform.GetChild(0).GetComponent<Text>().text = info;
        _animatorPopUp.SetTrigger("Open");
        _tutorialOpen = true;
    }

    private void CloseTutorial()
    {
        _playerManager.EnablePlayerMovement();
        _animatorPopUp.SetTrigger("Close");
    }
    
    
}
