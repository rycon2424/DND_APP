using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class InitiativeManager : MonoBehaviour
{
    [SerializeField] GameObject infoSpawnable;
    [SerializeField] TMP_InputField nameField;
    [SerializeField] TMP_InputField numbField;
    [SerializeField] RectTransform container;
    [SerializeField] const int componentHeight = 110;
    [SerializeField] List<CreatureInfo> allCreatures = new List<CreatureInfo>();

    public void ConfirmButton()
    {
        if (nameField.text == "" || numbField.text == "" || numbField.text == "-")
        {
            ClearCreationWindow();
            return;
        }

        SpawnInfo();
    }

    private void SpawnInfo()
    {
        container.sizeDelta = new Vector2(container.sizeDelta.x, container.sizeDelta.y + componentHeight);
        GameObject go = Instantiate(infoSpawnable, container);
        CreatureInfo info = new CreatureInfo(nameField.text, int.Parse(numbField.text), go);
        allCreatures.Add(info);
        go.GetComponent<CharacterInfoAssigner>().ApplyCreatureInfo(info);
        UpdateList();
    }

    public void UpdateList()
    {
        List<CreatureInfo> newList = new List<CreatureInfo>();
        for (int i = 0; i < allCreatures.Count; i++)
        {
            if (allCreatures[i].Go != null)
            {
                newList.Add(allCreatures[i]);
            }
            else
            {
                container.sizeDelta = new Vector2(container.sizeDelta.x, container.sizeDelta.y - componentHeight);
            }
        }
        var orderedList = newList.OrderBy(x => x.Initiative).ToList();
        allCreatures = orderedList;

        for (int i = 0; i < allCreatures.Count; i++)
        {
            allCreatures[i].Go.transform.SetSiblingIndex(i);
        }
    }

    public void ResetPage()
    {
        for (int i = 0; i < allCreatures.Count; i++)
        {
            allCreatures[i].Go.GetComponent<CharacterInfoAssigner>().RemoveCreature();
        }
        allCreatures = new List<CreatureInfo>();
        container.sizeDelta = Vector2.zero;
    }

    private void ClearCreationWindow()
    {
        nameField.text = "";
        numbField.text = "";
    }
}
