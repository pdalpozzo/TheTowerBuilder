using UnityEngine;

public class TotalMitigationPercent : Stat
{
    [SerializeField] private Stat _defensePercent;                          // permanant
    [SerializeField] private UltimateWeapon _chronoField;                   // ultimate weapon
    [SerializeField] private Stat _chronoFieldDamageReduction;              // conditional
    [SerializeField] private Bot _flameBot;                                 // bot
    [SerializeField] private Stat _flameBotDamageReduction;                 // conditional
    [SerializeField] private UltimateWeapon _chainLightning;                // ultimate weapon
    [SerializeField] private Stat _chainLightningThunderDamageReduction;    // conditional

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
        CreateValue();
    }

    private void InRoundBuffs()
    {
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        float subTotal = _multiplier * (_base + _additional);

        if (_chronoField.IsOn)
            subTotal += (1 - subTotal) * _chronoFieldDamageReduction.Value;

        if (_flameBot.IsOn)
            subTotal += (1 - subTotal) * _flameBotDamageReduction.Value;

        _conditionalValue = subTotal;
    }

    private void UpdateBase()
    {
        _base = (_defensePercent.Upgrade.IsUnlocked) ? _defensePercent.ConditionalValue : 0;
    }

    protected override void UpdateValue()
    {
    }
}
