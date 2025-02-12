using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverflowHealth : Stat
{
    [SerializeField] private Stat _health;              // base
    [SerializeField] private Stat _packageMaxRecovery;  // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _health) UpdateValue();
        if (stat == _packageMaxRecovery) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        _base = _health.Value;
        if (_packageMaxRecovery.Upgrade.IsUnlocked) 
            multiplier *= _packageMaxRecovery.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        _base = _health.InRoundValue;
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _base = _health.ConditionalValue;
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = 0;
    }
}

