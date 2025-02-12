using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Card : MonoBehaviour
{
    [SerializeField] private CardScriptableObject _data;
    [SerializeField] private int _currentLevel = 0;
    [SerializeField] private bool _isEquipped = false;
    [SerializeField] private int _slotNumber = -1;  // -1 means not assigned
    [SerializeField] private Stat _stat;
    [SerializeField] private bool _isSuperTower;

    public string Name { get { return _data.Name; } }
    public float Value { get { return CalculateValue(_currentLevel); } }
    public float BaseValue { get { return CalculateValue(0); } }
    public int Level { get { return _currentLevel; } }
    public int Slot { get { return _slotNumber; } }
    public bool IsEquipped { get { return _isEquipped; } }
    public Rarity Rarity { get { return _data.Rarity; } }
    public Sprite Icon { get { return _data.Icon; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public int BaseLevel { get { return _data.BaseLevel; } }
    public string ValueDisplay { get { return CreateValueDisplay(_currentLevel); } }
    public string Description { get { return CreateDescription(); } }

    public void NewLevel(int level)
    {
        ChangeLevel(level);
        EventManager.CardChanged(this);
    }

    public void AssignSlot(int slot)
    {
        _isEquipped = slot != -1;
        _slotNumber = slot;
        EventManager.CardChanged(this);
    }

    public void ResetSlot()
    {
        _isEquipped = false;
        _slotNumber = -1;
        EventManager.CardChanged(this);
    }

    private void ChangeLevel(int level)
    {
        _currentLevel = level;
    }

    private string CreateDescription()
    {
        float value = _data.Value(_currentLevel);
        if (_stat != null) value = _stat.Value;

        string description = string.Empty;
        description += _data.Prefix;
        description += CreateValueDisplay(value);
        description += _data.Suffix;

        if (_isSuperTower)
        {
            description = string.Empty;
            description += _data.Prefix;
            description += CreateValueDisplay(_data.Value(_currentLevel));
            description += ". ";
            description += CreateValueDisplay(value, true);
            description += _data.Suffix;
        }

        return description;
    }

    private float CalculateValue(int level)
    {
        float value = _data.Value(level);
        return value;
    }

    private string CreateValueDisplay(float value, bool isStat = false)
    {
        StringFormatType format = (isStat) ? _stat.FormatType : _data.FormatType;
        int decimalPlaces = (isStat) ? _stat.DecimalPlaces : _data.DecimalPlaces;
        bool noSymbol = (isStat) ? _stat.NoSymbol : _data.NoSymbol;

        string valueDisplay = string.Empty;
        valueDisplay = StringFormating.Format(value, format, decimalPlaces, noSymbol);
        return valueDisplay;
    }
}
