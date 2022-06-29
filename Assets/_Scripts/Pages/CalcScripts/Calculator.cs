using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Calculator : MonoBehaviour
{
    public enum Operator
    {
        None = -1,
        Divide = 0,
        Multiply = 1,
        Subtract = 2,
        AddUp = 3,
        Sum = 4,
        Clear = 5
    }

    [SerializeField] TMP_Text display;
    float numInput1 = 0;
    float numInput2 = 0;
    Operator opInput = Operator.None;
    Operator oldOpInput = Operator.None;

    private Operator OpInput
    {
        get
        {
            return opInput;
        }
        set
        {
            oldOpInput = OpInput;
            opInput = value;
        }
    }

    public void InputNumber(int input)
    {
        if (numInput1 == 0 && OpInput == Operator.None)
        {
            numInput1 = input;
        }
        else if(OpInput == Operator.None)
        {
            numInput1 = float.Parse(numInput1.ToString() + input.ToString());
        }
        else
        {
            numInput2 = float.Parse(numInput2.ToString() + input.ToString());
        }
        UpdateUI();
    }

    public void InputOperator(int input)
    {
        if (numInput2 == 0)
        {
            OpInput = (Operator)input;
        }
        else
        {
            OpInput = (Operator)input;
            GetSum();
            OpInput = (Operator)input;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (OpInput == Operator.None)
        {
            display.text = numInput1.ToString();
        }
        else
        {
            string output = numInput1.ToString();
            switch (OpInput)
            {
                case Operator.None:
                    output = "ERROR";
                    break;
                case Operator.Divide:
                    output += " /";
                    break;
                case Operator.Multiply:
                    output += " x";
                    break;
                case Operator.Subtract:
                    output += " -";
                    break;
                case Operator.AddUp:
                    output += " +";
                    break;
                case Operator.Sum:
                    output = GetSum().ToString();
                    break;
                case Operator.Clear:
                    output = "0";
                    Clear();
                    break;
                default:
                    output = "ERROR";
                    break;
            }

            if (numInput2 != 0)
            {
                output += " " + numInput2.ToString();
            }

            display.text = output;
        }
    }

    public void Clear()
    {
        numInput1 = 0;
        numInput2 = 0;
        OpInput = Operator.None;
    }

    float GetSum()
    {
        float sum = 0;
        if (numInput2 == 0)
        {
            sum = numInput1;
        }
        else if (oldOpInput == Operator.None)
        {
            sum = numInput1;
        }
        else
        {
            switch (oldOpInput)
            {
                case Operator.None:
                    sum = 0;
                    break;
                case Operator.Divide:
                    sum = numInput1 / numInput2;
                    break;
                case Operator.Multiply:
                    sum = numInput1 * numInput2;
                    break;
                case Operator.Subtract:
                    sum = numInput1 - numInput2;
                    break;
                case Operator.AddUp:
                    sum = numInput1 + numInput2;
                    break;
                case Operator.Sum:
                    break;
                case Operator.Clear:
                    sum = 0;
                    break;
                default:
                    sum = 0;
                    break;
            }
        }

        numInput1 = sum;
        numInput2 = 0;
        opInput = Operator.None;
        return sum;
    }
}
