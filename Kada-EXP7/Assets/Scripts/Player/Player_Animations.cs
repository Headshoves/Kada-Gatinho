using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("Jump");
        }

        if (Input.GetButtonDown("Attack") || Input.GetButtonDown("ActiveTree") || Input.GetButtonDown("ActiveStone"))
        {
            _animator.SetTrigger("Attack");
        }

        float move = Input.GetAxisRaw("Horizontal");
        
        if (move != 0)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }

    public void DeathAnim()
    {
        _animator.SetTrigger("Death");
    }
}
