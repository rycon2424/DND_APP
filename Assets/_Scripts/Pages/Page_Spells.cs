using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using TMPro;

public class Page_Spells : DND_Page
{
    [Header("SpellInfo")]
    [SerializeField] GameObject spellTab;
    [SerializeField] TMP_Text spellName;
    [SerializeField] TMP_Text spellComponents;
    [SerializeField] TMP_Text spellDuration;
    [SerializeField] TMP_Text spellCastingTime;
    [SerializeField] TMP_Text spellRitual;
    [SerializeField] TMP_Text spellRange;
    [SerializeField] TMP_Text spellSchool;
    [SerializeField] TMP_Text spellConcentration;
    [SerializeField] TMP_Text spellLevel;
    [SerializeField] TMP_Text spellDesc;
    [SerializeField] TMP_Text spellAtHigher;
    [Space]
    [SerializeField] RectTransform contentBox;
    [SerializeField] [ReadOnly] float defaultContentBoxHeight;
    [SerializeField] [ReadOnly] float defaultSpellDescBoxHeight;

    [SerializeField] List<SpellBlock> spells = new List<SpellBlock>();

    private void Start()
    {
        defaultContentBoxHeight = contentBox.sizeDelta.y;
        defaultSpellDescBoxHeight = spellDesc.GetComponent<RectTransform>().sizeDelta.y;
    }

    public override void LoadPage() // Called when page is opened
    {
        if (lastPage != this)
        {
            gameObject.SetActive(true);
            StartCoroutine(LoadSpells());
        }
        base.LoadPage();
    }

    IEnumerator LoadSpells()
    {
        yield return new WaitForSeconds(openPageAnimation.duration);
        for (int i = 0; i < ApiCallBacks.instance.spellNames.results.Length; i++)
        {
            spells[i].spellName.text = ApiCallBacks.instance.spellNames.results[i].name;
            spells[i].spellInfo.name = ApiCallBacks.instance.spellNames.results[i].name;
            spells[i].spellInfo.url = ApiCallBacks.instance.spellNames.results[i].url;
            spells[i].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -145 * i);
            yield return new WaitForEndOfFrame();
        }
    }

    public void LoadSpell(Results spell)
    {
        contentBox.sizeDelta = new Vector2(contentBox.sizeDelta.x, defaultContentBoxHeight);
        spellDesc.GetComponent<RectTransform>().sizeDelta = new Vector2(spellDesc.GetComponent<RectTransform>().sizeDelta.x, defaultSpellDescBoxHeight);

        spellTab.SetActive(true);
        InDepthSpellInfo spellInfo = ApiCallBacks.instance.GetSpellInfo("https://www.dnd5eapi.co" + spell.url);
        spellName.text = spellInfo.name;
        spellDuration.text = "Duration: " + spellInfo.duration;
        spellCastingTime.text = "Casting Time: " + spellInfo.casting_time;
        spellRitual.text = "Ritual: " + "" + spellInfo.ritual;
        spellRange.text = "Range: " + spellInfo.range;
        spellSchool.text = "School: " + spellInfo.school.name;
        spellConcentration.text = "Concentration: " + spellInfo.concentration;
        spellLevel.text = "Level: " + spellInfo.level;

        string descriptionTemp = "";
        foreach (string paragraph in spellInfo.desc)
        {
            descriptionTemp += paragraph;
        }
        spellDesc.text = descriptionTemp;

        int textLength = descriptionTemp.Length;
        Debug.Log(textLength);
        if (textLength > 500)
        {
            int extraLength = (textLength - 500) * 4;
            spellDesc.GetComponent<RectTransform>().sizeDelta += new Vector2(0, extraLength);
            contentBox.sizeDelta += new Vector2(0, extraLength);
        }

        descriptionTemp = "";
        foreach (string paragraph in spellInfo.higher_level)
        {
            descriptionTemp += paragraph;
        }
        spellAtHigher.text = descriptionTemp;

        descriptionTemp = "Component: ";
        foreach (string paragraph in spellInfo.components)
        {
            descriptionTemp += paragraph;
            descriptionTemp += ", ";
        }
        spellComponents.text = descriptionTemp;
    }

    public void CloseSpellTab()
    {
        spellTab.SetActive(false);
    }

    public override void ClosePage() // Called when another page is opened while this one is open
    {
        base.ClosePage();
    }

    public override void ResetPage() // Called on the corner button with the reset logo
    {

    }

}