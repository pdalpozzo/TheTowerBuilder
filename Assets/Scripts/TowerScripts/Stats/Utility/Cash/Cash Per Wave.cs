using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPerWave : Stat
{
    [SerializeField] private Stat _cashBonusStat;                   // base
    [SerializeField] private Perk _moreCashPerWaveNoCashOnKill;     // in round

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += CoinBonus;
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void CoinBonus(Stat stat)
    {
        if (stat == _cashBonusStat) UpdateValue();
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _moreCashPerWaveNoCashOnKill) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        multiplier *= _lab.Value;
        if (_subEffect.IsEquipped) additional += _subEffect.Value;
        _value = (_base * multiplier + additional) * _cashBonusStat.Value;

        // in round buffs
        float more_multi = 1;
        if (!_moreCashPerWaveNoCashOnKill.IsBanned)
            more_multi = _moreCashPerWaveNoCashOnKill.Value; //check if banned

        _inRoundValue = (_base * multiplier + additional) * _cashBonusStat.InRoundValue * more_multi;

        // conditional buffs
        _conditionalValue = (_base * multiplier + additional) * _cashBonusStat.ConditionalValue * more_multi;

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }
}
