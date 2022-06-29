using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceManager : MonoBehaviour
{
    [SerializeField] TMP_Text outputText;

    int[] dieAmounts = new int[7] { 0, 0, 0, 0, 0, 0, 0};

    [SerializeField] TMP_Text modifierText;
    int modifier = 0;

    List<Die> dice = new List<Die>();

    bool hasRolled;

    public void AddDie(int dieIdentifier)
    {
        if (hasRolled)
        {
            outputText.text = "";
            hasRolled = false;
        }

        dice.Add(new Die(dieIdentifier));

        int index = 0;      //Link the correct text componenets and amounts to the clicked button
        string dieNumber = "";
        switch (dieIdentifier)
        {
            case 4:
                index = 0;
                dieNumber = "d4";
                break;
            case 6:
                index = 1;
                dieNumber = "d6";
                break;
            case 8:
                index = 2;
                dieNumber = "d8";
                break;
            case 10:
                index = 3;
                dieNumber = "d10";
                break;
            case 12:
                index = 4;
                dieNumber = "d12";
                break;
            case 20:
                index = 5;
                dieNumber = "d20";
                break;
            case 100:
                index = 6;
                dieNumber = "d100";
                break;
            default:
                index = 0;
                dieNumber = "??";
                break;
        }
        dieAmounts[index]++;
        if (outputText.text == "")
        {
            outputText.text = dieNumber;
        }
        else
        {
            outputText.text += " + " + dieNumber;
        }
    }

    public void RollAll()
    {
        if (dice.Count == 0)
        {
            hasRolled = true;
            outputText.text = "Select the dices to use!";
            return;
        }
        int totalRoll = 0;
        string displayedText = "";
        for (int i = 0; i < dice.Count; i++)
        {
            int roll = dice[i].Roll();
            totalRoll += roll;
            displayedText += roll;
            if (i != dice.Count - 1)
            {
                displayedText += " + ";
            }
        }
        totalRoll += modifier;
        displayedText += AddModifierText();
        outputText.text = displayedText + " = " + totalRoll.ToString();
        hasRolled = true;
        dice.Clear();
        dice = new List<Die>();
    }

    public void AdjustModifier(bool addUp)
    {
        modifierText.text = "";
        if (addUp)
        {
            modifier++;
        }
        else
        {
            modifier--;
        }

        if (modifier > 0)
        {
            modifierText.text += "+";
        }
        modifierText.text += modifier.ToString();
    }

    public void RollStaight()
    {
        string output = "";
        int roll = new Die(20).Roll();
        output += roll.ToString() + AddModifierText();
        roll += modifier;
        output += " = " + roll;
        outputText.text = output;
    }

    public void RollAdvantage()
    {
        string output = "";
        int roll1 = new Die(20).Roll();
        int roll2 = new Die(20).Roll();
        int highest = Mathf.Max(roll1, roll2);
        output += "(" + roll1.ToString() + " + " + roll2.ToString() + ")" + AddModifierText();
        highest += modifier;
        output += " = " + highest;
        outputText.text = output;
    }

    public void RollDisadvantage()
    {
        string output = "";
        int roll1 = new Die(20).Roll();
        int roll2 = new Die(20).Roll();
        int lowest = Mathf.Min(roll1, roll2);
        output += "(" + roll1.ToString() + " + " + roll2.ToString() + ")" + AddModifierText();
        lowest += modifier;
        output += " = " + lowest;
        outputText.text = output;
    }

    public void ResetPage()
    {
        modifier = 0;
        modifierText.text = modifier.ToString();
        outputText.text = "";
        dice.Clear();
        dice = new List<Die>();
    }

    private string AddModifierText()
    {
        string displayedText = "";
        if (modifier > 0)
        {
            displayedText += " + (+" + modifier + ")";
        }
        else if (modifier < 0)
        {
            displayedText += " - (-" + Mathf.Abs(modifier) + ")";

        }
        return displayedText;
    }
}
