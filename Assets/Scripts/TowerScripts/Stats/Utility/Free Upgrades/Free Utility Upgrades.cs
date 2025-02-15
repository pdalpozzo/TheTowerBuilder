using UnityEngine;

public class FreeUtilityUpgrades : Stat
{
    [SerializeField] private Card _freeUpgradesCard;        // permanant
    [SerializeField] private Perk _freeUpgradesForAll;      // in round
    [SerializeField] private Stat _freeUpgradeStat;         // enhancement

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
        _multiplier *= _freeUpgradeStat.Value;
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
        if (_freeUpgradesCard.IsEquipped) _additional += _freeUpgradesCard.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_freeUpgradesForAll.IsBanned) _additional += _freeUpgradesForAll.Value;   //check if banned
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
