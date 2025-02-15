using UnityEngine;

public class WallRegen : Stat
{
    [SerializeField] private Stat _healthRegen;             // base
    [SerializeField] private Stat _wallRegenMultiplier;     // permanant

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
        _multiplier *= _wallRegenMultiplier.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        _newbase = _healthRegen.InRoundValue;
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        _newbase = _healthRegen.ConditionalValue;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _newbase = _healthRegen.Value;
    }

    protected override void UpdateValue()
    {
    }
}
