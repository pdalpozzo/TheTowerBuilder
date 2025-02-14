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
    public PerkType PerkType { get {  return _data.PerkType; } }
    public float NegativeValue { get { return _data.NegativeValue; } }
    public Sprite Icon { get { return _data.Icon; } }
    public StringFormatType ValueOneFormat { get { return _data.ValueOneFormat; } }
    public int ValueOneDecimalPlaces { get { return _data.ValueOneDecimalPlaces; } }

    public bool IsBanned { get { return _isBanned; } }
    public bool IsPriority { get { return _isPriority; } }
    public bool IsInteractive { get { return _isInteractive; } }

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

    public string GetStacksInfo()
    {
        if (_data.MaxStacks <= 1) return string.Empty;
        string stackValue = GetStringFormat(_data.Increment * (1 + _standardMultiplier), ValueOneFormat, ValueOneDecimalPlaces);
        string text = _data.MaxStacks.ToString("N0") + " Stacks. Each: " + stackValue;
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
        if (_data.PerkType == PerkType.UWPERK) _currentValue = _data.BaseValue;
        if (_data.PerkType == PerkType.TRADEOFF)
        {
            _currentValue = (_data.BaseValue * _data.MaxStacks) * (1f + _tradeOffMultiplier);
            return;
        }

        _currentValue = (_data.BaseValue + (_data.Increment * _data.MaxStacks)) * (1f + _standardMultiplier);
    }

    private void CreateDescription()
    {
        string value = "";
        string text = _data.Prefix;

        if (_data.ShowValue)
        {
            value = GetStringFormat(_currentValue, _data.ValueOneFormat, _data.ValueOneDecimalPlaces);
            text += value;
        }
        text += _data.Middle;

        if (_data.PerkType == PerkType.TRADEOFF)
        {
            if (_data.ShowNegValue)
            {
                value = GetStringFormat(_data.NegativeValue, _data.ValueTwoFormat, _data.ValueTwoDecimalPlaces);
                text += value;
            }
            text += _data.Suffix;
        }
        _currentDescription = text;
    }

    private string GetStringFormat(float value, StringFormatType formatType, int decimalPlaces )
    {
        return StringFormating.Format(value, formatType, decimalPlaces);
    }
}
