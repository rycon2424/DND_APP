using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateModifier : MonoBehaviour
{
    TMP_InputField statField;
    TMP_Text modifierText;

    private void Start()
    {
        statField = GetComponent<TMP_InputField>();
        modifierText = statField.transform.parent.GetChild(1).GetComponent<TMP_Text>();
    }

    public void UpdateText()
    {
        float floatValue = 0;
        float.TryParse(statField.text, out floatValue);

        floatValue = (floatValue / 2) - 5;
        floatValue = Mathf.FloorToInt(floatValue);

        if (floatValue > -1)
            modifierText.text = "+" + floatValue.ToString();
        else
            modifierText.text = floatValue.ToString();
    }
}
