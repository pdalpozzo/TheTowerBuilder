using UnityEngine;

public class WallHealth : Stat
{
    [SerializeField] private Stat _health;                  // base
    [SerializeField] private Stat _wallHealthMultiplier;    // permanant

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
        _multiplier *= _wallHealthMultiplier.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        _base = _health.InRoundValue;
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        _base = _health.ConditionalValue;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = _health.Value;
    }
}
