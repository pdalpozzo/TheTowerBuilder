using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public enum PerkType { COMMON, UWPERK, TRADEOFF };

public class Perk : MonoBehaviour
{
    [SerializeField] private PerkScriptableObject _data;
    [SerializeField] private float _standardMultiplier = 1f;
    [SerializeField] private float _tradeOffMultiplier = 1f;
    [SerializeField] private float _currentValue;
    [SerializeField] private string _currentDescription = "";

    [SerializeField] private bool _isBanned = false;
    [SerializeField] private bool _isPriority = false;
    [SerializeField] private bool _isInteractive = true;

    [SerializeField] private Stat _standardPerkBonus;      // lab
    [SerializeField] private Stat _tradeOffPerkBonus;      // lab

    public float Value { get { return _currentValue; } }

    public string Name { get { return _data.Name; } }
    public string Tooltip { get { return _data.Tooltip; } }
    public string Prefix { get { return _data.Prefix; } }
    public string Middle { get { return _data.Middle; } }
    public string Suffix { get { return _data.Suffix; } }
    public PerkType PerkType { get {  return _data.PerkType; } }
    public float BaseValue { get { return _data.BaseValue; } }
    public float Increment { get { return _data.Increment; } }
    public float NegativeValue { get { return _data.NegativeValue; } }
    public int MaxStacks { get { return _data.MaxStacks; } }
    public Sprite Icon { get { return _data.Icon; } }
    public StringFormatType ValueOneFormat { get { return _data.ValueOneFormat; } }
    public StringFormatType ValueTwoFormat { get { return _data.ValueTwoFormat; } }
    public int ValueOneDecimalPlaces { get { return _data.ValueOneDecimalPlaces; } }
    public int ValueTwoDecimalPlaces { get { return _data.ValueTwoDecimalPlaces; } }
    public bool ShowValue { get { return _data.ShowValue; } }
    public bool ShowNegValue { get { return _data.ShowNegValue; } }
    public bool IsRangedTradeOff { get { return _data.IsRangedTradeOff; } }

    public bool IsBanned { get { return _isBanned; } }
    public bool IsPriority { get { return _isPriority; } }
    public bool IsInteractive { get { return _isInteractive; } }

    private void Awake()
    {

    }

    private void Start()
    {
        EventManager.OnAnyStatChange += StatChanged;

        CalculatingValues();
        CreateDescription();
    }

    private void StatChanged(Stat stat)
    {
        if (stat == _standardPerkBonus) SetStandardMultiplier(stat.Value);
        if (stat == _tradeOffPerkBonus) SetTradeOffMultiplier(stat.Value);
    }

    public float GetValue()
    {
        return _currentValue;
    }

    public string GetStacksInfo()
    {
        if (MaxStacks <= 1) return string.Empty;
        string stackValue = GetStringFormat(Increment, ValueOneFormat, ValueOneDecimalPlaces);
        //string value = _currentValue.ToString("N0");
        string text = MaxStacks.ToString("N0") + " Stacks. Each: " + stackValue;
        return text;
    }

    public string GetDescription()
    {
        CalculatingValues();
        CreateDescription();
        return _currentDescription;
    }

    public void ResetBanPriority()
    {
        _isBanned = false; 
        _isPriority = false;
        Trigger_PerkStatusChange();
    }

    public void SetPriority(bool toPriority)
    {
        _isPriority = toPriority;
        if (toPriority) _isBanned = false;
        Trigger_PerkStatusChange();
    }

    public void SetBan(bool toBan)
    {
        _isBanned = toBan;
        if (toBan) _isPriority = false;
        Trigger_PerkStatusChange();
    }

    public void SetStandardMultiplier(float multi)
    {
        _standardMultiplier = multi;
        Trigger_PerkStatusChange();
    }

    public void SetTradeOffMultiplier(float multi)
    {
        _tradeOffMultiplier = multi;
        Trigger_PerkStatusChange();
    }

    public void SetInteractive(bool toInteract)
    {
        _isInteractive = toInteract;
        if (!toInteract)
        {
            _isPriority = toInteract;
            _isBanned = toInteract;
        }
        Trigger_PerkStatusChange();
    }

    // trigger visual update
    private void Trigger_PerkStatusChange()
    {
        EventManager.PerkStatusChange(this);
    }

    private void CalculatingValues()
    {
        if (PerkType == PerkType.UWPERK) _currentValue = BaseValue;
        if (PerkType == PerkType.TRADEOFF)
        {
            _currentValue = (BaseValue * MaxStacks) * (1f + _tradeOffMultiplier);
            return;
        }

        _currentValue = (BaseValue + (Increment * MaxStacks)) * (1f + _standardMultiplier);
    }

    private void CreateDescription()
    {
        string value = "";
        string text = Prefix;

        if (ShowValue)
        {
            value = GetStringFormat(_currentValue, ValueOneFormat, ValueOneDecimalPlaces);
            text += value;
        }
        text += Middle;

        if (PerkType == PerkType.TRADEOFF)
        {
            if (ShowNegValue)
            {
                value = GetStringFormat(NegativeValue, ValueTwoFormat, ValueTwoDecimalPlaces);
                text += value;
            }
            text += Suffix;
        }
        _currentDescription = text;
    }

    private string GetStringFormat(float value, StringFormatType formatType, int decimalPlaces )
    {
        return StringFormating.Format(value, formatType, decimalPlaces);
    }

}
