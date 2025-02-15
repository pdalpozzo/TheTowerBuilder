using UnityEngine;

public class MaxDamageAbsorbed : Stat
{
    // This stat is to show the highest amount of damage the tower
    // can take resulting in no health being removed.

    [SerializeField] private Stat _defenseAbsolute;     // base
    [SerializeField] private Stat _totalMitigation;     // permanant

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
        _value = _defenseAbsolute.Value / (1 - _totalMitigation.Value);
    }

    private void InRoundBuffs()
    {
        _inRoundValue = _defenseAbsolute.InRoundValue / (1 - _totalMitigation.InRoundValue);
    }

    private void ConditionalBuffs()
    {
        _conditionalValue = _defenseAbsolute.ConditionalValue / (1 - _totalMitigation.ConditionalValue);
    }

    private void UpdateBase()
    {
        _newbase = 0;
    }

    protected override void UpdateValue()
    {
    }
}
