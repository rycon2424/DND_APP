using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellBlock : MonoBehaviour
{
    public TMP_Text spellName;
    public Results spellInfo;
    [Space]
    public Page_Spells spellPage;

    public void OpenSpell()
    {
        spellPage.LoadSpell(spellInfo);
    }
} 
