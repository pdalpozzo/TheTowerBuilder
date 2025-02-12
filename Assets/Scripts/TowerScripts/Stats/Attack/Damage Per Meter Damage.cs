using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerMeterDamage : Stat
{
    [SerializeField] private Stat _projectileDamage;    // base
    [SerializeField] private Stat _range;               // permanant
    [SerializeField] private Stat _damagePerMeter;      // permanant
    [SerializeField] private Card _superTowerCard;      // conditional

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
        EventManager.OnAnyCardChange += UpdateValue;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _projectileDamage) UpdateValue();
        if (stat == _range) UpdateValue();
        if (stat == _damagePerMeter) UpdateValue();
    }

    private void UpdateValue(Card card)
    {
        if (card == _superTowerCard) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        multiplier *= (1 + (_damagePerMeter.Value * _range.Value));
        _value = multiplier * (_base + additional);

        // in round buffs
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        if (_superTowerCard.IsEquipped) multiplier *= _superTowerCard.Value;
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _projectileDamage.Value;
    }

}
