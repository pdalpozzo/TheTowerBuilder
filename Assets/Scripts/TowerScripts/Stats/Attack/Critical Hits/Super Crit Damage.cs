using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCritDamage : Stat
{
    [SerializeField] private Stat _projectileDamage;    // base
    [SerializeField] private Stat _criticalFactor;      // permanant
    [SerializeField] private Stat _superCritMulti;      // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _projectileDamage) UpdateValue();
        if (stat == _criticalFactor) UpdateValue();
        if (stat == _superCritMulti) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        multiplier *= _criticalFactor.Value;
        if (_superCritMulti.Upgrade.IsUnlocked) 
            multiplier *= _superCritMulti.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _projectileDamage.Value;
    }
}
