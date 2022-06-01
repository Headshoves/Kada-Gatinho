using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence_Behaviour : MonoBehaviour
{
    [SerializeField] private float _oscilation;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float sinY = Mathf.Sin(Time.time);
        
        transform.position = new Vector2(transform.position.x, sinY*_oscilation);
    }
}
