using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineStunChance : Stat
{
    [SerializeField] private Card _landMineStunCard;        // permanant

    private float _base = 0.3f;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _landMineStunCard) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        if (_landMineStunCard.IsEquipped) additional += 0.3f;
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
        _base = 0;
    }
}
