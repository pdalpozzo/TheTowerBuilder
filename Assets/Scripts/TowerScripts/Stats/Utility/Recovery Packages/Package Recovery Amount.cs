using UnityEngine;

public class PackageRecoveryAmount : Stat
{
    [SerializeField] private Stat _recoveryPackageEnhancement;      // enhancement

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
        _multiplier *= _recoveryPackageEnhancement.Value;
        _additional += _lab.Value;
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
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
        _base = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
    }
}
