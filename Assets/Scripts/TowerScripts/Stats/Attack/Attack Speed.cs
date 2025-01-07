using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class AttackSpeed : Stat
{
    [SerializeField] private Card _attackSpeedCard;     // permanant
    [SerializeField] private Stat _rapidFireMultiplier; // conditional
    
    private float _base = 0;

    private void Awake()
    {
        UpdateValue();
    }

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _attackSpeedCard) UpdateValue();
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
        if (_attackSpeedCard.IsEquipped) multiplier *= _attackSpeedCard.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        multiplier *= _rapidFireMultiplier.Value;
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }
}
