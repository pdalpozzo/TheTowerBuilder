using UnityEngine;

public class PackageChance : Stat
{
    [SerializeField] private Card _recoveryPackageChanceCard;   // permanant

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
        _additional += _lab.Value;
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
        if (_recoveryPackageChanceCard.IsEquipped) _additional += _recoveryPackageChanceCard.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
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
