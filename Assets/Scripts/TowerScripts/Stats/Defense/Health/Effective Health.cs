using UnityEngine;

public class EffectiveHealth : Stat
{
    [SerializeField] private Stat _overflowHealth;      // base
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
        _value = (_overflowHealth.Value / (1 - _totalMitigation.Value)) + _defenseAbsolute.Value;
    }

    private void InRoundBuffs()
    {
        _inRoundValue = (_overflowHealth.InRoundValue / (1 - _totalMitigation.InRoundValue)) + _defenseAbsolute.InRoundValue;
    }

    private void ConditionalBuffs()
    {
        _conditionalValue = (_overflowHealth.ConditionalValue / (1 - _totalMitigation.ConditionalValue)) + _defenseAbsolute.ConditionalValue;
    }

    private void UpdateBase()
    {
        _base =  0;
    }

    protected override void UpdateValue()
    {
    }
}

