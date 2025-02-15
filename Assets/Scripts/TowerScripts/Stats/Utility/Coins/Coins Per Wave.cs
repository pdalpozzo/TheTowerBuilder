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
        _value = (_newbase * _multiplier + _additional) * _coinBonusStat.Value;
    }

    private void InRoundBuffs()
    {
        _inRoundValue = (_newbase * _multiplier + _additional) * _coinBonusStat.InRoundValue;
    }

    private void ConditionalBuffs()
    {
        _conditionalValue = (_newbase * _multiplier + _additional) * _coinBonusStat.ConditionalValue;
    }

    private void UpdateBase()
    {
        _newbase = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
    }

    protected override void UpdateValue()
    {
    }
}
