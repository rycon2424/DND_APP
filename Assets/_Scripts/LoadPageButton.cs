using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPageButton : DND_Button
{
    [SerializeField] DND_Page pageToLoad;

    public override void ButtonPressed()
    {
        base.ButtonPressed();
        pageToLoad.LoadPage();
    }
}
