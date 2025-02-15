using UnityEngine;

public class CoinsPerKillBonus : Stat
{
    [SerializeField] private Stat _coinBonusStat;       // base

    // formula from wiki
    // Coins/Kill (CPK) = (Workshop × CPK lab + CPK mod effect)
    // × (1 + coin bonus enhancement)                       - already in Coin Bouns Value
    // × (1 + coin bonus perk base [0.15] × perk quantity)  - already in Coin Bouns Value
    // × (trade-off perk [1.8] × (1 + trade-off lab))       - already in Coin Bouns Value

    private void Update()
    {
        ResetValues();
        UpdateBase();
        PermanentBuffs();
        InRoundBuffs();
        ConditionalBuffs();
        CreateDescriptions();
    }

    private void PermanentBuffs()
    {
        _multiplier *= _lab.Value;
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
        _value = (_base * _multiplier + _additional) * _coinBonusStat.Value;
    }

    private void InRoundBuffs()
    {
        _inRoundValue = (_base * _multiplier + _additional) * _coinBonusStat.InRoundValue;
    }

    private void ConditionalBuffs()
    {
        _conditionalValue = (_base * _multiplier + _additional) * _coinBonusStat.ConditionalValue;
    }

    private void UpdateBase()
    {
        _base = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
    }

    protected override void UpdateValue()
    {
    }
}
