using UnityEngine;

public class OverflowWallHealth : Stat
{
    [SerializeField] private Stat _wallHealth;              // base
    [SerializeField] private Stat _wallFortification;       // permanant

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
        _multiplier *= 1 + _wallFortification.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        _newbase = _wallHealth.InRoundValue;
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        _newbase = _wallHealth.ConditionalValue;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _newbase = _wallHealth.Value;
    }

    protected override void UpdateValue()
    {
    }
}

