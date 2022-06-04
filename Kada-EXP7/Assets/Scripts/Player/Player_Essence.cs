using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Essence: MonoBehaviour
{
    public static Player_Essence instance;

    [SerializeField] private Text _treeEssenceText;
    [SerializeField] private Text _stoneEssenceText;
    
    private int _stoneEssence;
    private int _treeEssence;

    private void Awake()
    {
        instance = this;
        _treeEssenceText.text = "0";
        _stoneEssenceText.text = "0";
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

    public void UseStoneEssence(int qtd)
    {
        _stoneEssence -= qtd;
        _stoneEssenceText.text = _stoneEssence.ToString();
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
}
