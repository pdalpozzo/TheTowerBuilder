using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculationPanelControl : MonoBehaviour
{
    [SerializeField] private DisplayCalc _displayCalc = DisplayCalc.BASIC;

    //[SerializeField] private GameObject _baseCalculations;
    //[SerializeField] private GameObject _inRoundCalculations;
    //[SerializeField] private GameObject _conditionalCalculations;

    [SerializeField] private CalcaltionDisplayLayout _calculationDisplay;

    [SerializeField] private Toggle _baseButton;
    [SerializeField] private Toggle _inRoundButton;
    [SerializeField] private Toggle _conditionalButton;

    private void Start()
    {
        //ToggleCalculations();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _calculationDisplay.SetDisplayCalc(_displayCalc);
    }

    public void SetBaseDisplay()
    {
        _displayCalc = DisplayCalc.BASIC;
        UpdateDisplay();
    }

    public void SetInRoundDisplay()
    {
        _displayCalc = DisplayCalc.IN_ROUND;
        UpdateDisplay();
    }

    public void SetConditionalDisplay()
    {
        _displayCalc = DisplayCalc.CONDITIONAL;
        UpdateDisplay();
    }



    //public void ToggleCalculations()
    //{
    //    if (_baseButton.isOn) _displayCalc = DisplayCalc.BASIC;
    //    if (_inRoundButton.isOn) _displayCalc = DisplayCalc.IN_ROUND;
    //    if (_conditionalButton.isOn) _displayCalc = DisplayCalc.CONDITIONAL;


    //    //_baseCalculations.SetActive(_baseButton.isOn);
    //    //_inRoundCalculations.SetActive(_inRoundButton.isOn);
    //    //_conditionalCalculations.SetActive(_conditionalButton.isOn);
    //}

}
