using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAbsolute : Stat
{
    [SerializeField] private Card _fortressCard;        // permanant
    [SerializeField] private Perk _defenseAbsMulti;     // in round
    [SerializeField] private RelicManager _relicManager;

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
        EventManager.OnRelicBonusChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _fortressCard) UpdateValue();
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _defenseAbsMulti) UpdateValue();
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
        multiplier *= (1 + _relicManager.TowerDamage);
        if (_fortressCard.IsEquipped) multiplier *= _fortressCard.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_defenseAbsMulti.IsBanned) multiplier *= _defenseAbsMulti.Value;   //check if banned
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
