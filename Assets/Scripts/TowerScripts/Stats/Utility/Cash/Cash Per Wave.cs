using UnityEngine;

public class CashPerWave : Stat
{
    [SerializeField] private Stat _cashBonusStat;                   // base
    [SerializeField] private Perk _moreCashPerWaveNoCashOnKill;     // in round
    private float _moreMulti = 1;

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
        _value = (_newbase * _multiplier + _additional) * _cashBonusStat.Value;
    }

    private void InRoundBuffs()
    {
        if (!_moreCashPerWaveNoCashOnKill.IsBanned)
            _moreMulti = _moreCashPerWaveNoCashOnKill.Value; //check if banned

        _inRoundValue = (_newbase * _multiplier + _additional) * _cashBonusStat.InRoundValue * _moreMulti;
    }

    private void ConditionalBuffs()
    {
        _conditionalValue = (_newbase * _multiplier + _additional) * _cashBonusStat.ConditionalValue * _moreMulti;
    }

    private void UpdateBase()
    {
        _newbase = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
        _moreMulti = 1;
    }

    protected override void UpdateValue()
    {
    }
}
