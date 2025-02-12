using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRebuild : Stat
{
    [SerializeField] private Card _fortressCard;                // permanant
    [SerializeField] private CardMastery _fortressCardMastery;  // permanant

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnAnyMasteryChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _fortressCard) UpdateValue();
    }

    private void UpdateValue(CardMastery mastery)
    {
        if (mastery == _fortressCardMastery) UpdateValue();
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
        if (_fortressCard.IsEquipped && _fortressCardMastery.Enabled)
            additional += _fortressCardMastery.Value;
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
        _base = (_upgrade.IsUnlocked) ? _upgrade.Value : _base;
    }
}
