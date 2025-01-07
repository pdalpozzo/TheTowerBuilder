using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestMulti : Stat
{
    [SerializeField] private Perk _interestMultiPerk;   // perk

    private float _base = 1;

    private new void Start()
    {
        base.Start();
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _interestMultiPerk) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        multiplier *= _lab.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_interestMultiPerk.IsBanned) multiplier *= _interestMultiPerk.Value;   //check if banned
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = 1;
    }
}
