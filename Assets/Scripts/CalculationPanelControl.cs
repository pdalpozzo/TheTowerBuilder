using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculationPanelControl : MonoBehaviour
{
    [SerializeField] private GameObject _baseCalculations;
    [SerializeField] private GameObject _inRoundCalculations;
    [SerializeField] private GameObject _conditionalCalculations;
    [SerializeField] private Toggle _baseButton;
    [SerializeField] private Toggle _inRoundButton;
    [SerializeField] private Toggle _conditionalButton;

    private void Start()
    {
        ToggleCalculations();
    }

    public void ToggleCalculations()
    {
        _baseCalculations.SetActive(_baseButton.isOn);
        _inRoundCalculations.SetActive(_inRoundButton.isOn);
        _conditionalCalculations.SetActive(_conditionalButton.isOn);
    }

}
