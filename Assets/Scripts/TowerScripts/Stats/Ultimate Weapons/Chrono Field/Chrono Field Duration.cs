using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoFieldDuration : Stat
{
    [SerializeField] private Perk _chronoFieldDuration;   // in round

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _chronoFieldDuration) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        additional += _lab.Value;
        //additional += _subEffect.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_chronoFieldDuration.IsBanned)
            multiplier *= _chronoFieldDuration.Value;   //check if banned
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _effect.Value;
    }
}
