using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_Stats : DND_Page
{
    [SerializeField] Vector3 defaultSpawnPos;
    [SerializeField] int spaceBetweenBlocks;
    [SerializeField] List<GameObject> currentStatBlocks = new List<GameObject>();
    [SerializeField] List<GameObject> availableStatBlocks = new List<GameObject>();
    [Space]
    [SerializeField] Button spawnButton;

    public override void LoadPage() // Called when page is opened
    {
        base.LoadPage();
    }

    public override void ClosePage() // Called when another page is opened while this one is open
    {
        base.ClosePage();
    }

    public override void ResetPage() // Called on the corner button with the reset logo
    {
        foreach (GameObject statBlock in currentStatBlocks)
        {
            statBlock.SetActive(false);
        }

        currentStatBlocks.Clear();
        spawnButton.interactable = true;
    }

    public void SpawnBlock()
    {
        int count = currentStatBlocks.Count;
        availableStatBlocks[count].SetActive(true);
        availableStatBlocks[count].GetComponent<RectTransform>().anchoredPosition = defaultSpawnPos + new Vector3(0, (spaceBetweenBlocks * currentStatBlocks.Count), 0);
        currentStatBlocks.Add(availableStatBlocks[count]);
        Debug.Log(count);
        if (count == 3)
        {
            spawnButton.interactable = false;
        }
    }
}