using UnityEngine;

public class EffectiveCriticalChance : Stat
{
    [SerializeField] private Stat _criticalChance;              // base
    [SerializeField] private Stat _effectiveSuperCritChance;    // permanant

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
        _value = 1 - _base - _effectiveSuperCritChance.Value;
    }

    private void InRoundBuffs()
    {
        _inRoundValue = 1 - _base - _effectiveSuperCritChance.Value;
    }

    private void ConditionalBuffs()
    {
        _conditionalValue = 1 - _base - _effectiveSuperCritChance.Value;
    }

    private void UpdateBase()
    {
        float critChance = (_criticalChance.Value > _cap) ? _cap : _criticalChance.Value;
        _base = 1 - critChance;
    }
}

