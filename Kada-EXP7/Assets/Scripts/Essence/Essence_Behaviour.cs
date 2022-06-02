using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence_Behaviour : MonoBehaviour
{
    [SerializeField] private float _amplitude = 1f;
    [SerializeField] private float _frequency = 0.1f;

    private float _startY;
    void Start()
    {
        _startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float sinY = Mathf.Sin(Time.time * _frequency) * _amplitude;
        
        transform.position = new Vector2(transform.position.x, _startY + sinY);
    }
}
