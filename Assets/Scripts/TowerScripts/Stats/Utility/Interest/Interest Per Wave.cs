using UnityEngine;

public class InterestPerWave : Stat
{
    [SerializeField] private Stat _interestMultiStat;   // stat from perk

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
        _multiplier *= _interestMultiStat.Value;
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        _multiplier = 1; // reset to use stat in round value
        _multiplier *= _interestMultiStat.InRoundValue;
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
    }
}
