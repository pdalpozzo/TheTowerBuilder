using UnityEngine;

public class EffectiveWallHealth : Stat
{
    [SerializeField] private Stat _overflowWallHealth;  // base
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
        _value = (_overflowWallHealth.Value / (1 - _totalMitigation.Value)) + _defenseAbsolute.Value;
    }

    private void InRoundBuffs()
    {
        _inRoundValue = (_overflowWallHealth.InRoundValue / (1 - _totalMitigation.InRoundValue)) + _defenseAbsolute.InRoundValue;
    }

    private void ConditionalBuffs()
    {
        _conditionalValue = (_overflowWallHealth.ConditionalValue / (1 - _totalMitigation.ConditionalValue)) + _defenseAbsolute.ConditionalValue;
    }

    private void UpdateBase()
    {
        _newbase =  0;
    }

    protected override void UpdateValue()
    {
    }
}

