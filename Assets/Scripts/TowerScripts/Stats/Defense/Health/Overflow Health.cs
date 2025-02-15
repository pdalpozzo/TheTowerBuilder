using UnityEngine;

public class OverflowHealth : Stat
{
    [SerializeField] private Stat _health;              // base
    [SerializeField] private Stat _packageMaxRecovery;  // permanant

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
        if (_packageMaxRecovery.Upgrade.IsUnlocked)
            _multiplier *= _packageMaxRecovery.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        _newbase = _health.InRoundValue;
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        _newbase = _health.ConditionalValue;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _newbase = _health.Value;
    }

    protected override void UpdateValue()
    {
    }
}

