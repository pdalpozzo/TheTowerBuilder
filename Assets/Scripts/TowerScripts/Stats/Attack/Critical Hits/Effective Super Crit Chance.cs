using UnityEngine;

public class EffectiveSuperCritChance : Stat
{
    [SerializeField] private Stat _criticalChance;      // base
    [SerializeField] private Stat _superCritChance;     // permanant

    private float _cap = 1;

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
        _multiplier *= _superCritChance.Value;
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
        float critChance = (_criticalChance.Value > _cap) ? _cap : _criticalChance.Value;
        _base = critChance;
    }

    protected override void UpdateValue()
    {
    }
}

