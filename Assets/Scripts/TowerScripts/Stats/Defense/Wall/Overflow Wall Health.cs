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
        _base = _wallHealth.InRoundValue;
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        _base = _wallHealth.ConditionalValue;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = _wallHealth.Value;
    }
}

