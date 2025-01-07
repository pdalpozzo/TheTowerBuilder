using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalChance : Stat
{
    [SerializeField] private Card _criticalChanceCard;      // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _criticalChanceCard) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        //additional += _subEffect.Value;
        if (_criticalChanceCard.IsEquipped) additional += _criticalChanceCard.Value;
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
