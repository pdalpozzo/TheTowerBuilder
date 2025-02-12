using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class HealthRegen : Stat
{
    [SerializeField] private Card _healthRegenCard;                     // permanant
    [SerializeField] private Stat _healthRegenCardValue;                // permanant

    [SerializeField] private Perk _healthRegenMulti;                    // in round
    [SerializeField] private Perk _lessEnemyHealthLessRegenLifesteal;   // in round
    [SerializeField] private Perk _moreHealthRegenLessTowerHealth;      // in round

    [SerializeField] private Card _secondWindCard;                      // conditional
    [SerializeField] private CardMastery _secondWindCardMastery;        // conditional

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnAnyMasteryChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _healthRegenCardValue) UpdateValue();
    }

    private void UpdateValue(Card card)
    {
        if (card == _healthRegenCard) UpdateValue();
        if (card == _secondWindCard) UpdateValue();
    }

    private void UpdateValue(CardMastery mastery)
    {
        if (mastery == _secondWindCardMastery) UpdateValue();
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
        if (_subEffect.IsEquipped) multiplier *= 1 + _subEffect.Value;
        if (_healthRegenCard.IsEquipped) multiplier *= _healthRegenCardValue.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_healthRegenMulti.IsBanned) multiplier *= _healthRegenMulti.Value;   //check if banned
        if (!_lessEnemyHealthLessRegenLifesteal.IsBanned) 
            multiplier *= (1 + _lessEnemyHealthLessRegenLifesteal.NegativeValue);   //check if banned

        if (!_moreHealthRegenLessTowerHealth.IsBanned) 
            multiplier *= _moreHealthRegenLessTowerHealth.Value;   //check if banned
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        if (_secondWindCard.IsEquipped && _secondWindCardMastery.Enabled)
            multiplier *= _secondWindCardMastery.Value;

        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }
}
