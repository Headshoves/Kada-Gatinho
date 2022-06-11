using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Fairy_ChangeColor : MonoBehaviour
{
    
    [SerializeField] private Color _treeRange;
    [SerializeField] private Color _stoneRange;
    [SerializeField] private Color _enemyRange;
    [SerializeField] private Color _passiveRange;

    private Light2D _light2D;

    private void Start()
    {
        _light2D = transform.GetChild(1).GetComponent<Light2D>();
        _light2D.color = _passiveRange;
    }

    public void InTreeRange()
    {
        _light2D.color = _treeRange;
    }

    public void OutRange()
    {
        _light2D.color = _passiveRange;
    }

    public void InStoneRange()
    {
        _light2D.color = _stoneRange;
    }

    public void InEnemyRange()
    {
        _light2D.color = _enemyRange;
    }

}
