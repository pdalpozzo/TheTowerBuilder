using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWaveQuantity : Stat
{
    [SerializeField] private Perk _deathWaveAdditionalWave;   // in round

    private float _base = 1;

    private new void Start()
    {
        base.Start();
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _deathWaveAdditionalWave) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        //additional += _subEffect.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_deathWaveAdditionalWave.IsBanned)
            additional += _deathWaveAdditionalWave.Value;   //check if banned
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
