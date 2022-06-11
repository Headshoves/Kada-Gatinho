using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Platform : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(col.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            other.transform.DetachChildren();
        }
    }
}
