using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _lenght;
    private float _startPosX;
    private float _startPosY;
    private Camera _cam;
    [SerializeField] private float parallaxEffectX;
    [SerializeField] private float parallaxEffectY;
    
    void Start()
    {
        _cam = Camera.main;
        _startPosX = transform.position.x;
        _startPosY = transform.position.y;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float tempX = (_cam.transform.position.x * (1-parallaxEffectX));
        float distX = (_cam.transform.position.x * parallaxEffectX);
        float tempY = (_cam.transform.position.y * (1-parallaxEffectY));
        float distY = (_cam.transform.position.y * parallaxEffectY);
        transform.position = new Vector3(_startPosX + distX, _startPosY + distY, transform.position.z);

        if (tempX > _startPosX + _lenght)
        {
            _startPosX += _lenght;
        }
        if (tempX < _startPosX - _lenght)
        {
            _startPosX -= _lenght;
        }
    }
}
