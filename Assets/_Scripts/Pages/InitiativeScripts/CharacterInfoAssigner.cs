using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInfoAssigner : MonoBehaviour
{
    [SerializeField]
    private TMP_Text characterName;
    [SerializeField]
    private TMP_Text initiative;

    public void ApplyCreatureInfo(CreatureInfo creatureInfo)
    {
        characterName.text = creatureInfo.Name;
        initiative.text = creatureInfo.Initiative.ToString();
    }

    public void RemoveCreature()
    {
        Destroy(gameObject);
    }
}
