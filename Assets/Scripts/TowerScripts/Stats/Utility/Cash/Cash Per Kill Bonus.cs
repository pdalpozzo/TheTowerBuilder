using UnityEngine;

public class CashPerKillBonus : Stat
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
        _value = (_newbase * _multiplier + _additional) * _cashBonusStat.Value;
    }

    private void InRoundBuffs()
    {
        if (!_moreCashPerWaveNoCashOnKill.IsBanned)
            _moreMulti = _moreCashPerWaveNoCashOnKill.NegativeValue; //check if banned

        _inRoundValue = (_newbase * _multiplier + _additional) * _cashBonusStat.InRoundValue * _moreMulti;
    }

    private void ConditionalBuffs()
    {
        _conditionalValue = (_newbase * _multiplier + _additional) * _cashBonusStat.ConditionalValue * _moreMulti;
    }

    private void UpdateBase()
    {
        // comes from enemies
        _newbase = 1;
        _moreMulti = 1;
    }

    protected override void UpdateValue()
    {
    }
}
