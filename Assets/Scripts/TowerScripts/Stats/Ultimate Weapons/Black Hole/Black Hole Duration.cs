using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleDuration : Stat
{
    [SerializeField] private Perk _blackHoleDuration;   // in round

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _blackHoleDuration) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        if (_subEffect.IsEquipped) additional += _subEffect.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_blackHoleDuration.IsBanned)
            additional += _blackHoleDuration.Value;   //check if banned
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
