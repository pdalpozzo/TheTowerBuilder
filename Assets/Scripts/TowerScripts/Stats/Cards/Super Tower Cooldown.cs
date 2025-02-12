using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTowerCooldown : Stat
{
    [SerializeField] private CardMastery _mastery;  // permanant

    private float _base = 0;
    private float _cooldown = 30;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyMasteryChange += UpdateValue;
    }

    private void UpdateValue(CardMastery mastery)
    {
        if (mastery == _mastery) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        if (_mastery.Enabled) additional += _mastery.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _cooldown;
    }
}