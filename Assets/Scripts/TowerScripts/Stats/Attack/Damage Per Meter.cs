using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerMeter : Stat
{
    [SerializeField] private RelicManager _relicManager;

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnRelicBonusChange += UpdateValue;
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        multiplier *= _enhancement.Value;
        multiplier *= _lab.Value;
        //multiplier *= (1 + _subEffect.Value);
        multiplier *= (1 + _relicManager.DamagePerMeter);
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
        _base = _upgrade.Value;
    }
}
