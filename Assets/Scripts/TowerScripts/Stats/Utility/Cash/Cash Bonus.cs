using UnityEngine;

public class CashBonus : Stat
{
    [SerializeField] private Card _cashCard;                            // permanant
    [SerializeField] private Perk _cashBonusMulti;                      // in round

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
        _multiplier *= _enhancement.Value;
        _multiplier *= _lab.Value;
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
        if (_cashCard.IsEquipped) _multiplier *= _cashCard.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_cashBonusMulti.IsBanned) _multiplier *= _cashBonusMulti.Value;   //check if banned
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _newbase = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
    }

    protected override void UpdateValue()
    {
    }
}
