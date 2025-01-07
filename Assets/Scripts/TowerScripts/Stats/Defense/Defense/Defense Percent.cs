using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePercent : Stat
{
    [SerializeField] private Card _extraDefenseCard;        // permanant
    [SerializeField] private Perk _additionalDefense;       // in round

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
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
        //additional += _subEffect.Value;
        if (_extraDefenseCard.IsEquipped) additional += _extraDefenseCard.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_additionalDefense.IsBanned) additional += _additionalDefense.Value;   //check if banned
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