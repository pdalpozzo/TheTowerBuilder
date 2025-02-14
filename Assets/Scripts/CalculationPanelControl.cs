using UnityEngine;
using UnityEngine.UI;

public class CalculationPanelControl : MonoBehaviour
{
    [SerializeField] private DisplayCalc _displayCalc = DisplayCalc.BASIC;

    [SerializeField] private CalcaltionDisplayLayout _calculationDisplay;

    [SerializeField] private Toggle _baseButton;
    [SerializeField] private Toggle _inRoundButton;
    [SerializeField] private Toggle _conditionalButton;

    private void Update()
    {
        _calculationDisplay.SetDisplayCalc(_displayCalc);
    }

    public void SetBaseDisplay()
    {
        _displayCalc = DisplayCalc.BASIC;
    }

    public void SetInRoundDisplay()
    {
        _displayCalc = DisplayCalc.IN_ROUND;
    }

    public void SetConditionalDisplay()
    {
        _displayCalc = DisplayCalc.CONDITIONAL;
    }
}
