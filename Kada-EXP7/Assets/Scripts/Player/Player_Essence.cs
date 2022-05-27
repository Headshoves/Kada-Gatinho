using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Essence: MonoBehaviour
{
    public static Player_Essence instance;

    private int _stoneEssence;
    private int _treeEssence;

    private void Awake()
    {
        instance = this;
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
    }
    
    public void UseTreeEssence(int qtd)
    {
        _treeEssence -= qtd;
    }

    public void AddStoneEssence()
    {
        _stoneEssence++;
    }

    public void AddTreeEssence()
    {
        _treeEssence++;
    }
}
