using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEffect : MonoBehaviour
{
    [SerializeField] private SubEffectScriptableObject _data;
    [SerializeField] private Rarity _currentRarity;
    [SerializeField] private Rarity _currentModuleRarity;
    [SerializeField] private bool _isEquipped = false;

    public string Name { get { return _data.Name; } }
    //public string Tooltip { get { return _data.Tooltip; } }
    public Rarity Rarity { get { return _currentRarity; } }
    public Rarity BaseRarity { get { return _data.Rarity; } }
    public Rarity ModuleRarity { get { return _currentModuleRarity; } }
    public StringFormatType Format { get { return _data.FormatType; } }
    public ModuleType ModuleType { get { return _data.ModuleType; } }
    public int DecimalPlaces { get { return _data.DecimalPlaces; } }
    public bool IsEquipped { get { return _isEquipped; } }

    private void Awake()
    {
        _currentRarity = BaseRarity;
    }

    public float GetValue()
    {
        return _data.GetValue((int)_currentRarity);
    }

    public string GetDescription()
    {
        return StringFormating.Format(_data.GetValue((int)_currentRarity), Format, DecimalPlaces);
    }

    public void SetEquipped(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }

    public void SetModuleRarity(Rarity rarity)
    {
        _currentModuleRarity = rarity;
    }

    public void ChangeRarity(Rarity rarity)
    {
        if (rarity < BaseRarity) return;
        if (rarity > _currentModuleRarity) return;
        _currentRarity = rarity;
    }

    //private string GetStringFormat(float value, StringFormatType formatType, int decimalPlaces)
    //{
    //    return StringFormating.Format(value, formatType, decimalPlaces);
    //}
}
