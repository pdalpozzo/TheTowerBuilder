using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public enum CalculationType : byte { BASE, IN_ROUND, CONDITIONAL }

public class ModifiedStat : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private ValueCalculation _data;
    [SerializeField] private ModifiedStat _limitStat;

    [SerializeField] private List<ModifiedStat> _additionalModifiers;
    [SerializeField] private List<ModifiedStat> _multiplicativeModifiers;
    [SerializeField] private List<ModifiedStat> _base0MultiplicativeModifiers;

    [SerializeField] private int _currentLevel = 0; // deserialize
    [SerializeField] private float _value = 0f;     // deserialize
    private float _additional = 0;
    private float _multiplier = 1;

    [SerializeField] private CalculationType _type = CalculationType.BASE;
    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;
    [SerializeField] private bool _noSymbol = false;
    [SerializeField] private bool _isInUse = false;     // deserialize

    public CalculationType Type { get { return _type; } }
    public string Name { get { return _name; } }
    public int Level { get { return _currentLevel; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public float Value { get { return _value; } }
    public bool IsMaxLevel { get { return (_currentLevel == _data.MaxLevel); } }
    public bool IsInUse { get { return _isInUse; } }

    private void Awake()
    {
        CheckForModifierLoops(_additionalModifiers);
        CheckForModifierLoops(_multiplicativeModifiers);
        CheckForModifierLoops(_base0MultiplicativeModifiers);
    }

    private void CheckForModifierLoops(List<ModifiedStat> modifiers)
    {
        for (int i = modifiers.Count-1 ; i >= 0; i--)
        {
            // remove from the array is modifier in the list matches this modifier
            if (modifiers[i] == this)
            {
                modifiers.RemoveAt(i);
            }
        }
    }

    private void Update()
    {
        // make sure we have a base stat to calculate with
        if (_data == null) return;

        CalculateAdditional();
        CalculateMultiplicative();
        CalculateBaseZeroMultiplicative();
        _value = _multiplier * (_data.Value(_currentLevel) + _additional);
        if (_limitStat != null)
        {
            if (_value > _limitStat.Value)
                _value = _limitStat.Value;
        }
    }

    public void SetLevel(int level)
    {
        // check new level is not above max level
        if (level > _data.MaxLevel) level = _data.MaxLevel;
        // check new level is not below base level
        if (level < 0) level = 0;
        _currentLevel = level;
    }

    public void SetInUse(bool inUse)
    {
        this._isInUse = inUse;
        if (!inUse) _currentLevel = 0;
    }

    public void SetToMaxLevel()
    {
        _currentLevel = _data.MaxLevel;
        this._isInUse = true;
    }

    public void ResetStat()
    {
        _currentLevel = 0;
        this._isInUse = false;
    }

    public override string ToString()
    {
        string text = StringFormating.Format(_value, _formatType, _decimalPlaces, _noSymbol);
        return text;
    }

    private void CalculateAdditional()
    {
        _additional = 0;
        if (_additionalModifiers.Count <= 0) return;
        if (!this._isInUse) return;

        foreach (var item in _additionalModifiers)
        {
            if (!item.IsInUse) continue;
            // change this to reference a global value of what to display
            // then copy to all calculation functions in this file
            if (item.Type != CalculationType.BASE) continue;
            _additional += item.Value;
        }
    }

    private void CalculateMultiplicative()
    {
        _multiplier = 1;
        if (_multiplicativeModifiers.Count <= 0) return;
        if (!this._isInUse) return;

        foreach (var item in _multiplicativeModifiers)
        {
            if (!item.IsInUse) continue;
            _multiplier *= item.Value;
        }
    }

    private void CalculateBaseZeroMultiplicative()
    {
        if (_base0MultiplicativeModifiers.Count <= 0) return;
        if (!this._isInUse) return;

        foreach (var item in _base0MultiplicativeModifiers)
        {
            if (!item.IsInUse) continue;
            _multiplier *= 1 + item.Value;
        }
    }
}
