using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverflowWallHealth : Stat
{
    [SerializeField] private Stat _wallHealth;              // base
    [SerializeField] private Stat _wallFortification;       // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _wallHealth) UpdateValue();
        if (stat == _wallFortification) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        _base = _wallHealth.Value;
        multiplier *= 1 + _wallFortification.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        _base = _wallHealth.InRoundValue;
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _base = _wallHealth.ConditionalValue;
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = 0;
    }
}

