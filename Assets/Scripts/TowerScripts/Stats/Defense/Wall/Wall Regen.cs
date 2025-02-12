using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRegen : Stat
{
    [SerializeField] private Stat _healthRegen;             // base
    [SerializeField] private Stat _wallRegenMultiplier;     // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _healthRegen) UpdateValue();
        if (stat == _wallRegenMultiplier) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        _base = _healthRegen.Value;
        multiplier *= _wallRegenMultiplier.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        _base = _healthRegen.InRoundValue;
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _base = _healthRegen.ConditionalValue;
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = 0;
    }
}
