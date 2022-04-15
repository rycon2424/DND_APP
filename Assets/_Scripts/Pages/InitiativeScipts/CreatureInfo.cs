using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureInfo
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private int _initiative;

    private GameObject _go;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Initiative
    {
        get { return _initiative; }
        set { _initiative = value; }
    }

    public GameObject Go
    {
        get { return _go; }
        set { _go = value; }
    }

    public CreatureInfo(string name, int initiative, GameObject go)
    {
        _name = name;
        _initiative = initiative;
        _go = go;
    }
}
