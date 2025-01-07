using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : Stat
{
    [SerializeField] private Card _healthRegenCard;                     // permanant
    [SerializeField] private Perk _healthRegenMulti;                    // in round
    [SerializeField] private Perk _lessEnemyHealthLessRegenLifesteal;   // in round
    [SerializeField] private Perk _moreHealthRegenLessTowerHealth;      // in round

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _healthRegenCard) UpdateValue();
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _healthRegenMulti) UpdateValue();
        if (perk == _lessEnemyHealthLessRegenLifesteal) UpdateValue();
        if (perk == _moreHealthRegenLessTowerHealth) UpdateValue();
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
        if (_healthRegenCard.IsEquipped) multiplier *= _healthRegenCard.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_healthRegenMulti.IsBanned) multiplier *= _healthRegenMulti.Value;   //check if banned
        if (!_lessEnemyHealthLessRegenLifesteal.IsBanned) 
            multiplier *= (1 + _lessEnemyHealthLessRegenLifesteal.NegativeValue);   //check if banned

        if (!_moreHealthRegenLessTowerHealth.IsBanned) 
            multiplier *= _moreHealthRegenLessTowerHealth.Value;   //check if banned
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
