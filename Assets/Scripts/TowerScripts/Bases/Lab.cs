using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{
    [SerializeField] private LabScriptableObject _data;
    [SerializeField] private int _currentLevel = 0;

    public string Name { get { return _data.Name; } }
    //public string TooltipMessage { get { return _data.Tooltip; } }
    public string DisplayValue { get { return GetStringFormat(_data.Value(_currentLevel), _data.FormatType, _data.DecimalPlaces); } }
    public float Value { get { return _data.Value(_currentLevel); } }
    public float BaseValue { get { return _data.Value(0); } }
    public StringFormatType Format { get { return _data.FormatType; } }
    public int DecimalPlaces { get { return _data.DecimalPlaces; } }
    public int Level { get { return _currentLevel; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public int BaseLevel { get { return _data.BaseLevel; } }
    public bool IsMaxLevel { get { return (_currentLevel == MaxLevel); } }

    public void NewLevel(int level)
    {
        ChangeLevel(level);
        EventManager.LabChanged(this);
    }

    //public void Reset()
    //{
    //    ChangeLevel(BaseLevel);
    //}

    private void ChangeLevel(int level)
    {
        if (level > MaxLevel) level = MaxLevel;     // check new level is not above max level
        if (level < BaseLevel) level = BaseLevel;    // check new level is not below base level
        _currentLevel = level;
    }

    private string GetStringFormat(float value, StringFormatType format, int decimalPlaces)
    {
        return StringFormating.Format(value, format, decimalPlaces);
    }
}
