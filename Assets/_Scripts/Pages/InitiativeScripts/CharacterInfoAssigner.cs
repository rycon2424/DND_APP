using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInfoAssigner : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _name;
    [SerializeField]
    private TMP_Text _initiative;

    public void ApplyCreatureInfo(CreatureInfo creatureInfo)
    {
        _name.text = creatureInfo.Name;
        _initiative.text = creatureInfo.Initiative.ToString();
    }

    public void RemoveCreature()
    {
        Destroy(gameObject);
    }
}
