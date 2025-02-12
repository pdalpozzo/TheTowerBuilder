using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDamageAbsorbed : Stat
{
    // This stat is to show the highest amount of damage the tower
    // can take resulting in no health being removed.

    [SerializeField] private Stat _defenseAbsolute;     // base
    [SerializeField] private Stat _totalMitigation;     // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _defenseAbsolute) UpdateValue();
        if (stat == _totalMitigation) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        //float additional = 0;
        //float multiplier = 1;

        // permanant buffs
        //_value = multiplier * (_base + additional);
        _value = _defenseAbsolute.Value / (1 - _totalMitigation.Value);

        // in round buffs
        //_inRoundValue = multiplier * (_base + additional);
        _inRoundValue = _defenseAbsolute.InRoundValue / (1 - _totalMitigation.InRoundValue);

        // conditional buffs
        //_conditionalValue = multiplier * (_base + additional);
        _conditionalValue = _defenseAbsolute.ConditionalValue / (1 - _totalMitigation.ConditionalValue);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = 0;
    }
}
