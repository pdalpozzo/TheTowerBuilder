using TMPro;
using UnityEngine;

public enum DisplayCalc { BASIC, IN_ROUND, CONDITIONAL }

public class Calculation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private Stat _stat;

    private DisplayCalc _displayCalc = DisplayCalc.BASIC;

    private void Start()
    {
        _name.text = "";
        _value.text = "";
        if (_stat != null ) _name.text = _stat.Name + ": ";
        DisplayData();
    }

    // Update is called once per frame
    private void Update()
    {
        DisplayData();
    }

    private void DisplayData()
    {   
        if (_stat == null) return;

        string temp = string.Empty;
        temp = _displayCalc switch
        {
            DisplayCalc.CONDITIONAL => _stat.ConditionalDisplay,
            DisplayCalc.IN_ROUND => _stat.InRoundDisplay,
            _ => _stat.ValueDisplay,
        };
        _value.text = temp;
    }

    public void SetDisplayCalc(DisplayCalc displayCalc)
    {
        _displayCalc = displayCalc;
    }
}
