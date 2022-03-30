using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _outputText;

    [SerializeField]
    private List<TMP_Text> _dieAmountText;
    private int[] _dieAmounts = new int[7] { 0, 0, 0, 0, 0, 0, 0};

    private List<Die> _dice = new List<Die>();

    public void AddDie(int dieIdentifier)
    {
        _dice.Add(new Die(dieIdentifier));

        int index = 0;      //Link the correct text componenets and amounts to the clicked button
        switch (dieIdentifier)
        {
            case 4:
                index = 0;
                break;
            case 6:
                index = 1;
                break;
            case 8:
                index = 2;
                break;
            case 10:
                index = 3;
                break;
            case 12:
                index = 4;
                break;
            case 20:
                index = 5;
                break;
            case 100:
                index = 6;
                break;
            default:
                index = 0;
                break;
        }
        _dieAmounts[index]++;
        _dieAmountText[index].text = _dieAmounts[index].ToString();
    }

    public void RollAll()
    {
        int totalRoll = 0;
        foreach (Die die in _dice)
        {
            totalRoll+= die.Roll();
        }
        _outputText.text = totalRoll.ToString();
        ResetAll();

        //ADD VISABLE DICE RESULTS
        //ADD DICE SPRITES
        //ADD A MODIFIER THAT YOU CAN SET
    }

    private void ResetAll()
    {
        _dice = new List<Die>();
        for (int i = 0; i < _dieAmountText.Count; i++)
        {
            _dieAmounts[i] = 0;
            _dieAmountText[i].text = "";
        }
    }
}
