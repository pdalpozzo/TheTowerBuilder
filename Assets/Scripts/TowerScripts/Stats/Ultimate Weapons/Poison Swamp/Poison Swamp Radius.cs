using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSwampRadius : Stat
{
    [SerializeField] private Perk _poisonSwampRadius;   // in round

    private float _base = 5; // not sure what the base radius is

    private new void Start()
    {
        base.Start();
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _poisonSwampRadius) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        additional += _lab.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_poisonSwampRadius.IsBanned)
            multiplier *= _poisonSwampRadius.Value;   //check if banned
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = 5;
    }
}
