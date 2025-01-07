using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLandMinesSets : Stat
{
    [SerializeField] private Perk _innerLandMineAdditionalSet;   // in round

    private float _base = 1;

    private new void Start()
    {
        base.Start();
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _innerLandMineAdditionalSet) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_innerLandMineAdditionalSet.IsBanned)
            additional += _innerLandMineAdditionalSet.Value;   //check if banned
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
