using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestPerWave : Stat
{
    [SerializeField] private Stat _interestMultiStat;   // stat from perk

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += CoinBonus;
    }

    private void CoinBonus(Stat stat)
    {
        if (stat == _interestMultiStat) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        multiplier *= _interestMultiStat.Value;
        if (_subEffect.IsEquipped) additional += _subEffect.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        multiplier = 1; // reset to use stat in round value
        multiplier *= _interestMultiStat.InRoundValue;
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }
}
