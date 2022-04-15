using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _outputText;

    private int[] _dieAmounts = new int[7] { 0, 0, 0, 0, 0, 0, 0};

    [SerializeField]
    private TMP_Text _modifierText;
    private int _modifier = 0;

    private List<Die> _dice = new List<Die>();

    private bool _hasRolled;

    public void AddDie(int dieIdentifier)
    {
        if (_hasRolled)
        {
            _outputText.text = "";
            _hasRolled = false;
        }

        _dice.Add(new Die(dieIdentifier));

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
        _dieAmounts[index]++;
        if (_outputText.text == "")
        {
            _outputText.text = dieNumber;
        }
        else
        {
            _outputText.text += " + " + dieNumber;
        }
    }

    public void RollAll()
    {
        if (_dice.Count == 0)
        {
            _hasRolled = true;
            _outputText.text = "Select the dices to use!";
            return;
        }
        int totalRoll = 0;
        string displayedText = "";
        for (int i = 0; i < _dice.Count; i++)
        {
            int roll = _dice[i].Roll();
            totalRoll += roll;
            displayedText += roll;
            if (i != _dice.Count - 1)
            {
                displayedText += " + ";
            }
        }
        totalRoll += _modifier;
        displayedText += AddModifierText();
        _outputText.text = displayedText + " = " + totalRoll.ToString();
        _hasRolled = true;
    }

    public void AdjustModifier(bool addUp)
    {
        _modifierText.text = "";
        if (addUp)
        {
            _modifier++;
        }
        else
        {
            _modifier--;
        }

        if (_modifier > 0)
        {
            _modifierText.text += "+";
        }
        _modifierText.text += _modifier.ToString();
    }

    public void RollStaight()
    {
        string output = "";
        int roll = new Die(20).Roll();
        output += roll.ToString() + AddModifierText();
        roll += _modifier;
        output += " = " + roll;
        _outputText.text = output;
    }

    public void RollAdvantage()
    {
        string output = "";
        int roll1 = new Die(20).Roll();
        int roll2 = new Die(20).Roll();
        int highest = Mathf.Max(roll1, roll2);
        output += "(" + roll1.ToString() + " + " + roll2.ToString() + ")" + AddModifierText();
        highest += _modifier;
        output += " = " + highest;
        _outputText.text = output;
    }

    public void RollDisadvantage()
    {
        string output = "";
        int roll1 = new Die(20).Roll();
        int roll2 = new Die(20).Roll();
        int lowest = Mathf.Min(roll1, roll2);
        output += "(" + roll1.ToString() + " + " + roll2.ToString() + ")" + AddModifierText();
        lowest += _modifier;
        output += " = " + lowest;
        _outputText.text = output;
    }

    public void ResetPage()
    {
        _modifier = 0;
        _modifierText.text = _modifier.ToString();
        _outputText.text = "";
    }

    private string AddModifierText()
    {
        string displayedText = "";
        if (_modifier > 0)
        {
            displayedText += " + (+" + _modifier + ")";
        }
        else if (_modifier < 0)
        {
            displayedText += " - (-" + Mathf.Abs(_modifier) + ")";

        }
        return displayedText;
    }
}
