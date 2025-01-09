using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPerKillBonus : Stat
{
    [SerializeField] private Stat _coinBonusStat;       // base

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += CoinBonus;
    }

    private void CoinBonus(Stat stat)
    {
        if (stat == _coinBonusStat) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // formula from wiki
        // Coins/Kill (CPK) = (Workshop × CPK lab + CPK mod effect)
        // × (1 + coin bonus enhancement)                       - already in Coin Bouns Value
        // × (1 + coin bonus perk base [0.15] × perk quantity)  - already in Coin Bouns Value
        // × (trade-off perk [1.8] × (1 + trade-off lab))       - already in Coin Bouns Value

        // permanant buffs
        multiplier *= _lab.Value;
        if (_subEffect.IsEquipped) additional += _subEffect.Value;
        //_value = multiplier * (_base + additional);
        _value = (_base * multiplier + additional) * _coinBonusStat.Value;

        // in round buffs
        _inRoundValue = (_base * multiplier + additional) * _coinBonusStat.InRoundValue;

        // conditional buffs
        _conditionalValue = (_base * multiplier + additional) * _coinBonusStat.ConditionalValue;

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }
}
