using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageMaxRecovery : Stat
{
    [SerializeField] private Stat _recoveryPackageEnhancement;      // enhancement

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += RecoverPackageEnhancement;
    }

    private void RecoverPackageEnhancement(Stat stat)
    {
        if (stat == _recoveryPackageEnhancement) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        multiplier *= _recoveryPackageEnhancement.Value;
        additional += _lab.Value;       // potentially incorrect
        if (_subEffect.IsEquipped) additional += _subEffect.Value;
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
        _base = (_upgrade.IsUnlocked) ? _upgrade.Value : _base;
    }
}
