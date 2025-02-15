using UnityEngine;

public class CoinsPerWave : Stat
{
    [SerializeField] private Stat _coinBonusStat;       // base

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
