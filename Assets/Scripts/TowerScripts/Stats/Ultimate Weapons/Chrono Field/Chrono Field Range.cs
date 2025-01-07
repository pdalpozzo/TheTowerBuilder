using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoFieldRange : Stat
{
    [SerializeField] private Stat _towerRange;  // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += RangeChanged;
    }

    private void RangeChanged(Stat stat)
    {
        if (stat == _towerRange) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        additional += _lab.Value;
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
        _base = _towerRange.Value;
    }
}
