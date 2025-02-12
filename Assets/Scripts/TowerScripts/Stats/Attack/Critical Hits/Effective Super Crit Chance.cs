using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectiveSuperCritChance : Stat
{
    [SerializeField] private Stat _criticalChance;      // base
    [SerializeField] private Stat _superCritChance;     // permanant

    private float _base = 0;
    private float _cap = 1;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _criticalChance) UpdateValue();
        if (stat == _superCritChance) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();

        // permanant buffs
        _value = _base * _superCritChance.Value;
        if (_value > _cap) _value = _cap;

        // in round buffs
        _inRoundValue = _base * _superCritChance.Value;
        if (_inRoundValue > _cap) _inRoundValue = _cap;

        // conditional buffs
        _conditionalValue = _base * _superCritChance.Value;
        if (_conditionalValue > _cap) _conditionalValue = _cap;

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _criticalChance.Value;
    }
}

