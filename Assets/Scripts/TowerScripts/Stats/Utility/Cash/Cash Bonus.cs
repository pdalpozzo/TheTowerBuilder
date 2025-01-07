using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashBonus : Stat
{
    [SerializeField] private Card _cashCard;                            // permanant
    [SerializeField] private Perk _cashBonusMulti;                      // in round

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _cashCard) UpdateValue();
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _cashBonusMulti) UpdateValue();
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
        if (_cashCard.IsEquipped) multiplier *= _cashCard.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_cashBonusMulti.IsBanned) multiplier *= _cashBonusMulti.Value;   //check if banned
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
