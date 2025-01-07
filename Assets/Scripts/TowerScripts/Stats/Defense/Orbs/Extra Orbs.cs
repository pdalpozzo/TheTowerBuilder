using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraOrbs : Stat
{
    [SerializeField] private Card _extraOrbsCard;        // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _extraOrbsCard) UpdateValue();
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
        _base = _extraOrbsCard.Value;
    }
}
