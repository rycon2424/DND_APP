using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Die
{
    public Die(int identifier)
    {
        _identifier = identifier;
    }

    [SerializeField]
    private int _identifier;

    public int Roll()
    {
        return UnityEngine.Random.Range(1, _identifier + 1);
    }
}
