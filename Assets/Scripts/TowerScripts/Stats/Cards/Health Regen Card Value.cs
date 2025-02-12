using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegenCardValue : Stat
{
    [SerializeField] private Card _card;            // permanant
    [SerializeField] private CardMastery _mastery;  // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnAnyMasteryChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _card) UpdateValue();
    }

    private void UpdateValue(CardMastery mastery)
    {
        if (mastery == _mastery) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        if (_mastery.Enabled) multiplier *= _mastery.Value;
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
        _base = _card.Value;
    }
}
