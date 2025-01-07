using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Perk", menuName = "ScriptableObjects/Perk")]
public class PerkScriptableObject : ScriptableObject
{
    [SerializeField] private string _perkName;
    [TextArea(3, 10)][SerializeField] private string _tooltipMessage;
    [SerializeField] private string _prefix;
    [SerializeField] private string _middle;
    [SerializeField] private string _suffix;
    [SerializeField] private PerkType _perkType;
    [SerializeField] private float _baseValue = 0;      // all perks
    [SerializeField] private float _increment = 0;      // common only perks
    [SerializeField] private float _negativeValue = 0;  // trade off only
    [SerializeField] private int _maxStacks = 1;        // only common can have > 1
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _showValue = true;
    [SerializeField] private bool _showNegValue = true;
    [SerializeField] private bool _isRangedTradeOff = false;

    [SerializeField] private StringFormatType _valueOneFormat;
    [SerializeField] private int _valueOneDecimalPlaces = 0;

    [SerializeField] private StringFormatType _valueTwoFormat;
    [SerializeField] private int _valueTwoDecimalPlaces = 0;

    public string Name { get { return _perkName; } }
    public string Tooltip { get { return _tooltipMessage; } }
    public string Prefix { get { return _prefix; } }
    public string Middle { get { return _middle; } }
    public string Suffix { get { return _suffix; } }
    public PerkType PerkType { get { return _perkType; } }
    public float BaseValue { get { return _baseValue; } }
    public float Increment { get { return _increment; } }
    public float NegativeValue { get { return _negativeValue; } }
    public int MaxStacks { get { return _maxStacks; } }
    public Sprite Icon { get { return _icon; } }
    public StringFormatType ValueOneFormat { get { return _valueOneFormat; } }
    public StringFormatType ValueTwoFormat { get { return _valueTwoFormat; } }
    public int ValueOneDecimalPlaces { get { return _valueOneDecimalPlaces; } }
    public int ValueTwoDecimalPlaces { get { return _valueTwoDecimalPlaces; } }
    public bool ShowValue { get { return _showValue; } }
    public bool ShowNegValue { get { return _showNegValue; } }
    public bool IsRangedTradeOff { get { return _isRangedTradeOff; } }
}
