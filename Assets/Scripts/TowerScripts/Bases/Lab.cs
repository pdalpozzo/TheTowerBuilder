using UnityEngine;

public class Lab : MonoBehaviour
{
    [SerializeField] private LabScriptableObject _data;
    [SerializeField] private int _currentLevel = 0;

    public string Name { get { return _data.Name; } }
    public string DisplayValue { get { return GetStringFormat(_data.Value(_currentLevel), _data.FormatType, _data.DecimalPlaces, _data.NoSymbol); } }
    public float Value { get { return _data.Value(_currentLevel); } }
    public int Level { get { return _currentLevel; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public int BaseLevel { get { return _data.BaseLevel; } }
    public bool IsMaxLevel { get { return (_currentLevel == MaxLevel); } }

    public void NewLevel(int level)
    {
        ChangeLevel(level);
        EventManager.LabChanged(this);
    }

    private void ChangeLevel(int level)
    {
        if (level > _data.MaxLevel) level = _data.MaxLevel;     // check new level is not above max level
        if (level < _data.BaseLevel) level = _data.BaseLevel;    // check new level is not below base level
        _currentLevel = level;
    }

    private string GetStringFormat(float value, StringFormatType format, int decimalPlaces, bool noSymbol = false)
    {
        if (_data.IsUnlockedLab) return (IsMaxLevel) ? "Unlocked" : ""; 
        return StringFormating.Format(value, format, decimalPlaces, noSymbol);
    }
}
