using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendArmorMultiMax : Stat
{
    [SerializeField] private Stat _rendArmorMulti;      // per hit

    private float _base = 8;
    private int _hitsToMax = 0;

    public int HitsToMaxRend { get { return _hitsToMax; } }

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += RendPerHit;
    }

    private void RendPerHit(Stat stat)
    {
        if (stat == _rendArmorMulti) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        //multiplier *= _subEffect.Value;
        multiplier *= _enhancement.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _conditionalValue = multiplier * (_base + additional);

        _hitsToMax = 0;
        if (_rendArmorMulti.Value > 0) _hitsToMax = Mathf.CeilToInt(_value / _rendArmorMulti.Value);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _lab.Value;
    }
}
