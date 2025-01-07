using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerMeterDamage : MonoBehaviour
{
    [SerializeField] protected string _name;

    // this stat only effects projectiles
    [SerializeField] private Stat _projectileDamage;    // base
    [SerializeField] private Stat _range;               // permanant
    [SerializeField] private Stat _damagePerMeter;      // permanant
    [SerializeField] private Card _superTowerCard;      // conditional

    private float _multiplier = 0;

    private float _baseDamage = 0;
    private float _superTowerDamage = 0;

    private float _maxRangeDamage = 0;
    private float _superTowerMaxRangeDamage = 0;

    private string _maxRangeDamageDisplay = "";
    private string _superTowerMaxRangeDamageDisplay = "";

    public float BaseDamage { get { return _baseDamage; } }
    public float MaxRangeDamage { get { return _maxRangeDamage; } }
    public float SuperTowerDamage { get { return _superTowerMaxRangeDamage; } }

    public string Name { get { return _name; } }
    public string MaxRangeDamageDisplay { get { return _maxRangeDamageDisplay; } }
    public string SuperTowerDamageDisplay { get { return _superTowerMaxRangeDamageDisplay; } }

    private void Awake()
    {
        UpdateValue();
    }

    private void Start()
    {
        EventManager.OnAnyStatChange += UpdateValue;
        EventManager.OnAnyCardChange += UpdateValue;
    }

    private void UpdateValue(Stat stat)
    {
        if (stat == _projectileDamage) UpdateValue();
        if (stat == _range) UpdateValue();
        if (stat == _damagePerMeter) UpdateValue();
    }

    private void UpdateValue(Card card)
    {
        if (card == _superTowerCard) UpdateValue();
    }

    private void UpdateValue()
    {
        // calculate value
        UpdateBase();
        _multiplier = (1 + (_damagePerMeter.Value * _range.Value));

        // permanant buffs
        _maxRangeDamage = _multiplier * _baseDamage;

        // conditional buffs
        _superTowerMaxRangeDamage = _multiplier * _superTowerDamage;

        CreateDescriptions();
        EventManager.CalculationChanged();
    }

    private void UpdateBase()
    {
        _baseDamage = _projectileDamage.Value;
        // uses conditional value that already factors in Super Tower
        _superTowerDamage = _projectileDamage.ConditionalValue;
    }

    private void CreateDescriptions()
    {
        StringFormatType formatType = StringFormatType.BASIC;
        int decimalPlaces = 0;
        _maxRangeDamageDisplay = StringFormating.Format(_maxRangeDamage, formatType, decimalPlaces);
        _superTowerMaxRangeDamageDisplay = StringFormating.Format(_superTowerMaxRangeDamage, formatType, decimalPlaces);
    }
}
