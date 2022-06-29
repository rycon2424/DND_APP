using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureInfo
{
    [SerializeField]
    private string creatureName;
    [SerializeField]
    private int creatureInitiative;
    private GameObject go;

    public string Name
    {
        get { return creatureName; }
        set { creatureName = value; }
    }

    public int Initiative
    {
        get { return creatureInitiative; }
        set { creatureInitiative = value; }
    }

    public GameObject Go
    {
        get { return go; }
        set { go = value; }
    }

    public CreatureInfo(string name, int initiative, GameObject go)
    {
        creatureName = name;
        creatureInitiative = initiative;
        this.go = go;
    }
}
