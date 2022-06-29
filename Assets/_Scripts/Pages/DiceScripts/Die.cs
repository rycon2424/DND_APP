using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Die
{
    public Die(int identifier)
    {
        this.identifier = identifier;
    }

    [SerializeField] int identifier;

    public int Roll()
    {
        return UnityEngine.Random.Range(1, identifier + 1);
    }
}
