using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CriticalChance : Stat
{
    [SerializeField] private Card _criticalChanceCard;      // permanant
    [SerializeField] private Stat _criticalChanceCardValue; // permanant

    private float _base = 0;
    private float _cap = 1;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
        EventManager.OnAnyCardChange += UpdateValue;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _criticalChanceCardValue) UpdateValue();
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
        if (_subEffect.IsEquipped) additional += _subEffect.Value;
        if (_criticalChanceCard.IsEquipped) additional += _criticalChanceCardValue.Value;
        _value = multiplier * (_base + additional);
        if (_value > _cap) _value = _cap;

        // in round buffs
        _inRoundValue = multiplier * (_base + additional);
        if (_inRoundValue > _cap) _inRoundValue = _cap;

        // conditional buffs
        _conditionalValue = multiplier * (_base + additional);
        if (_conditionalValue > _cap) _conditionalValue = _cap;

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }
}
