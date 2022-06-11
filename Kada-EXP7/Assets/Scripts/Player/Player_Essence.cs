using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Essence: MonoBehaviour
{
    
    [SerializeField] private Text _treeEssenceText;
    [SerializeField] private Text _stoneEssenceText;
    [SerializeField] private Text _enemyEssenceText;
    
    private int _stoneEssence;
    private int _treeEssence;
    private int _enemyEssence;

    private void Start()
    {
        
        _treeEssenceText.text = "0";
        _stoneEssenceText.text = "0";
        _enemyEssenceText.text = "0";
    }

    public bool CanUseStoneEssence(int qtd)
    {
        if (_stoneEssence >= qtd)
        {
            return true;
        }

        return false;
    }

    public bool CanUseTreeEssence(int qtd)
    {
        if (_treeEssence >= qtd)
        {
            return true;
        }

        return false;
    }
    
    public bool CanUseEnemyEssence(int qtd)
    {
        if (_enemyEssence >= qtd)
        {
            return true;
        }

        return false;
    }

    public void UseStoneEssence(int qtd)
    {
        _stoneEssence -= qtd;
        _stoneEssenceText.text = _stoneEssence.ToString();
    }
    
    public void UseEnemyEssence(int qtd)
    {
        _enemyEssence -= qtd;
        _enemyEssenceText.text = _enemyEssence.ToString();
    }
    
    public void UseTreeEssence(int qtd)
    {
        _treeEssence -= qtd;
        _treeEssenceText.text = _treeEssence.ToString();
    }

    public void AddStoneEssence(int qtd)
    {
        _stoneEssence+= qtd;
        _stoneEssenceText.text = _stoneEssence.ToString();
    }

    public void AddTreeEssence(int qtd)
    {
        _treeEssence+= qtd;
        _treeEssenceText.text = _treeEssence.ToString();
    }
    
    public void AddEnemyEssence(int qtd)
    {
        _enemyEssence+= qtd;
        _enemyEssenceText.text = _enemyEssence.ToString();
    }
}
