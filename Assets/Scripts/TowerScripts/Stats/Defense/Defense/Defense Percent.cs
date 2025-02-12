using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DefensePercent : Stat
{
    [SerializeField] private Card _extraDefenseCard;        // permanant
    [SerializeField] private Stat _extraDefenseCardValue;   // permanant
    [SerializeField] private Stat _defenseCap;              // permanant

    [SerializeField] private Perk _additionalDefense;       // in round

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _extraDefenseCardValue) UpdateValue();
        if (stat == _defenseCap) UpdateValue();
    }

    private void UpdateValue(Card card)
    {
        if (card == _extraDefenseCard) UpdateValue();
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _additionalDefense) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        additional += _lab.Value;
        if (_subEffect.IsEquipped) additional += _subEffect.Value;
        if (_extraDefenseCard.IsEquipped) additional += _extraDefenseCardValue.Value;
        _value = multiplier * (_base + additional);
        _value = (_value > _defenseCap.Value) ? _defenseCap.Value : _value;

        // in round buffs
        if (!_additionalDefense.IsBanned) additional += _additionalDefense.Value;   //check if banned
        _inRoundValue = multiplier * (_base + additional);
        _inRoundValue = (_inRoundValue > _defenseCap.Value) ? _defenseCap.Value : _inRoundValue;

        // conditional buffs
        _conditionalValue = multiplier * (_base + additional);
        _conditionalValue = (_conditionalValue > _defenseCap.Value) ? _defenseCap.Value : _conditionalValue;

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = (_upgrade.IsUnlocked) ? _upgrade.Value : _base;
    }
}
