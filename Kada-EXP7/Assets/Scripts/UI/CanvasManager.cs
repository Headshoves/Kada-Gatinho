using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Animator _animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoCreditos()
    {
        _animator.SetTrigger("Creditos");
    }

    public void GoToHome()
    {
        _animator.SetTrigger("Home");
    }
}
