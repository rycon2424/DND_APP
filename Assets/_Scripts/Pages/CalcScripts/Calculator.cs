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

    [SerializeField]
    private TMP_Text _display;
    private float _numInput1 = 0;
    private float _numInput2 = 0;
    private Operator _opInput = Operator.None;
    private Operator _oldOpInput = Operator.None;

    private Operator OpInput
    {
        get
        {
            return _opInput;
        }
        set
        {
            _oldOpInput = OpInput;
            _opInput = value;
        }
    }

    public void InputNumber(int input)
    {
        if (_numInput1 == 0 && OpInput == Operator.None)
        {
            _numInput1 = input;
        }
        else if(OpInput == Operator.None)
        {
            _numInput1 = float.Parse(_numInput1.ToString() + input.ToString());
        }
        else
        {
            _numInput2 = float.Parse(_numInput2.ToString() + input.ToString());
        }
        UpdateUI();
    }

    public void InputOperator(int input)
    {
        OpInput = (Operator)input;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (OpInput == Operator.None)
        {
            _display.text = _numInput1.ToString();
        }
        else
        {
            string output = _numInput1.ToString();
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

            if (_numInput2 != 0)
            {
                output += " " + _numInput2.ToString();
            }

            _display.text = output;
        }
    }

    public void Clear()
    {
        _numInput1 = 0;
        _numInput2 = 0;
        OpInput = Operator.None;
    }

    float GetSum()
    {
        float sum = 0;
        if (_numInput2 == 0)
        {
            sum = _numInput1;
        }
        else if (_oldOpInput == Operator.None)
        {
            sum = _numInput1;
        }
        else
        {
            switch (_oldOpInput)
            {
                case Operator.None:
                    sum = 0;
                    break;
                case Operator.Divide:
                    sum = _numInput1 / _numInput2;
                    break;
                case Operator.Multiply:
                    sum = _numInput1 * _numInput2;
                    break;
                case Operator.Subtract:
                    sum = _numInput1 - _numInput2;
                    break;
                case Operator.AddUp:
                    sum = _numInput1 + _numInput2;
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

        _numInput1 = sum;
        _numInput2 = 0;
        _opInput = Operator.None;
        return sum;
    }
}
