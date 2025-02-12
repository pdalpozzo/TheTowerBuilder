using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalDamageCalculations : MonoBehaviour
{
    [SerializeField] protected string _name;

    //[SerializeField] private DamagePerMeterDamage _damagePerMeterDamage;    // permanant
    [SerializeField] private Stat _criticalChance;                          // permanant
    [SerializeField] private Stat _criticalFactor;                          // permanant
    [SerializeField] private Stat _superCriticalChance;                     // permanant
    [SerializeField] private Stat _superCriticalMulti;                      // permanant

    private float _noRangeBase = 0;
    private float _maxRangeBase = 0;
    private float _superTowerBase = 0;

    private float _basicHitDamage = 0;
    private float _basicHitChance = 1;
    private float _critDamage = 0;
    private float _critChance = 0;
    private float _superCritDamage = 0;
    private float _superCritChance = 0;

    private float _noRangeAverageHit = 0;
    private float _maxRangeAverageHit = 0;
    private float _superTowerAverageHit = 0;

    private float _effectiveBasicHitChance = 0;
    private float _effectiveCritChance = 0;
    private float _effectiveSuperCritChance = 0;

    private string _basicHitDamageDisplay = "";
    private string _basicHitChanceDisplay = "";
    private string _critDamageDisplay = "";
    private string _critChanceDisplay = "";
    private string _superCritDamageDisplay = "";
    private string _superCritChanceDisplay = "";

    private string _noRangeAverageHitDisplay = "";
    private string _maxRangeAverageHitDisplay = "";
    private string _superTowerAverageHitDisplay = "";

    private string _effectiveBasicChanceDisplay = "";
    private string _effectiveCritChanceDisplay = "";
    private string _effectiveSuperChanceDisplay = "";

    public string Name { get { return _name; } }
    public string BasicHitDamage { get { return _basicHitDamageDisplay; } }
    public string BasicHitChance { get { return _basicHitChanceDisplay; } }
    public string CriticalChance { get { return _critDamageDisplay; } }
    public string CriticalDamage { get { return _critChanceDisplay; } }
    public string SuperCritChance { get { return _superCritDamageDisplay; } }
    public string SuperCritDamage { get { return _superCritChanceDisplay; } }
    public string AverageDamage { get { return _maxRangeAverageHitDisplay; } }

    private void Awake()
    {
        UpdateValue();
    }

    private void Start()
    {
        EventManager.OnAnyStatChange += UpdateValue;
        EventManager.OnCalculationChange += UpdateValue;
    }

    private void UpdateValue(Stat stat)
    {
        if (stat == _criticalChance) UpdateValue();
        if (stat == _criticalFactor) UpdateValue();
        if (stat == _superCriticalChance) UpdateValue();
        if (stat == _superCriticalMulti) UpdateValue();
    }

    private void UpdateValue()
    {
        // calculate value
        UpdateBase();

        //// base chance for each type of hit
        //_critChance = _criticalChance.Value;
        //_superCritChance = _superCriticalChance.Value;

        //// base hit is reduce by the percent that is critical
        //_effectiveBasicHitChance = 1 - _critChance;
        //// some critical hits turn into super critical hits
        //_effectiveSuperCritChance = _critChance * _superCriticalChance.Value;
        //// new critical hit is reduce by the percent that is super critical
        //_effectiveCritChance = _critChance - _effectiveSuperCritChance;

        // 10% super crit, 70% crit
        // effective base hit 30%
        // effective super crit 10% of 70% = 7%
        // effective crit 100% - eff base hit - eff super crit = 100% - 30% - 7% = 63%

        //// damage for each type of hit if not 0% chance
        //_basicHitDamage = _maxRangeBase;
        //_critDamage = (_effectiveCritChance > 0) ? _maxRangeBase * _criticalFactor.Value: 0;
        //_superCritDamage = (_effectiveSuperCritChance > 0 && _effectiveCritChance > 0) ? _critDamage * _superCriticalMulti.Value : 0f;

        //_noRangeAverageHit = Calculate(_noRangeBase);
        //_maxRangeAverageHit = Calculate(_maxRangeBase);
        //_superTowerAverageHit = Calculate(_superTowerBase);
        //CreateDescriptions();
    }

    private float Calculate(float damage)
    {
        // damage when factoring all critical chances and multipliers
        float crit = damage * _criticalFactor.Value;
        float super = crit * _superCriticalMulti.Value;

        float value = (damage * _effectiveBasicHitChance) + (crit * _effectiveCritChance) + (super * _effectiveSuperCritChance);
        return value;
    }

    private void UpdateBase()
    {
        //_noRangeBase = _damagePerMeterDamage.BaseDamage;
        //_maxRangeBase = _damagePerMeterDamage.MaxRangeDamage;
        //_superTowerBase = _damagePerMeterDamage.SuperTowerDamage;
    }

    private void CreateDescriptions()
    {
        StringFormatType formatType = StringFormatType.BASIC;
        int decimalPlaces = 0;
        _basicHitDamageDisplay = StringFormating.Format(_noRangeBase, formatType, decimalPlaces);
        _critDamageDisplay = StringFormating.Format(_critDamage, formatType, decimalPlaces);
        _superCritDamageDisplay = StringFormating.Format(_superCritDamage, formatType, decimalPlaces);
        _noRangeAverageHitDisplay = StringFormating.Format(_noRangeAverageHit, formatType, decimalPlaces);
        _maxRangeAverageHitDisplay = StringFormating.Format(_maxRangeAverageHit, formatType, decimalPlaces);
        _superTowerAverageHitDisplay = StringFormating.Format(_superTowerAverageHit, formatType, decimalPlaces);

        formatType = StringFormatType.PERCENT;
        decimalPlaces = 2;
        _basicHitChanceDisplay = StringFormating.Format(_basicHitChance, formatType, decimalPlaces);
        _critChanceDisplay = StringFormating.Format(_critChance, formatType, decimalPlaces);
        _superCritChanceDisplay = StringFormating.Format(_superCritChance, formatType, decimalPlaces);
        _effectiveBasicChanceDisplay = StringFormating.Format(_effectiveBasicHitChance, formatType, decimalPlaces);
        _effectiveCritChanceDisplay = StringFormating.Format(_effectiveCritChance, formatType, decimalPlaces);
        _effectiveSuperChanceDisplay = StringFormating.Format(_effectiveSuperCritChance, formatType, decimalPlaces);
    }
}
