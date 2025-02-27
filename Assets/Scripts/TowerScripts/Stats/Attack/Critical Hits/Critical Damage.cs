using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalDamage : Stat
{
    [SerializeField] private Stat _projectileDamage;    // base
    [SerializeField] private Stat _criticalFactor;      // permanant

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
        _multiplier *= _criticalFactor.Value;
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
        _base = _projectileDamage.Value;
    }
}

