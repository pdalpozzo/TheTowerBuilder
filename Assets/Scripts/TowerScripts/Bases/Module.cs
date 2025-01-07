using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class Module : MonoBehaviour
{
    [SerializeField] private ModuleScriptableObject _data;
    [SerializeField] private bool _isEquipped = false;

    public string Name { get { return _data.Name; } }
    //public string Tooltip { get { return _data.Tooltip; } }
    public string Prefix { get { return _data.Prefix; } }
    public string Suffix { get { return _data.Suffix; } }
    public Rarity BaseRarity { get { return _data.Rarity; } }
    public StringFormatType Format { get { return _data.FormatType; } }
    public int DecimalPlaces { get { return _data.DecimalPlaces; } }
    public bool IsNone { get { return _data.IsNone; } }
    public Sprite Icon { get { return _data.Icon; } }
    public bool IsEquipped { get { return _isEquipped; } }

    public float GetValue(Rarity rarity)
    {
        return _data.Value((int)rarity);
    }

    public void ChangeEquipped(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }

    public string CreateDescription(Rarity rarity)
    {
        if (_data.IsNonEpic || _data.IsNone) return "";

        string description = string.Empty;
        description += _data.Prefix;
        description += _data.ValueDisplay((int)rarity);
        description += _data.Suffix;

        return description;
    }
}
