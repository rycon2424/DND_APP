using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_Calculator : DND_Page
{
    [SerializeField] Calculator calculator;

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
        calculator.Clear();
        calculator.UpdateUI();
    }
}
