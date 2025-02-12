using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Stat
{
    [SerializeField] private Card _damageCard;                      // permanant
    [SerializeField] private Stat _damageCardValue;                 // permanant
    [SerializeField] private ModuleSlot _moduleSlot;                // permanant

    [SerializeField] private Card _berserkerCard;                   // in round
    [SerializeField] private CardMastery _berserkerCardMastery;     // in round
    [SerializeField] private Perk _damageMulti;                     // in round
    [SerializeField] private Perk _moreTowerDamageMoreBossHealth;   // in round
    [SerializeField] private Perk _lessEnemyDamageLessTowerDamage;  // in round

    [SerializeField] private UltimateWeapon _spotlight;             // conditional
    [SerializeField] private Card _energyNetCard;                   // conditional
    [SerializeField] private CardMastery _energyNetCardMastery;     // conditional
    [SerializeField] private Card _demonModeCard;                   // conditional
    [SerializeField] private CardMastery _demonModeCardMastery;     // conditional
    [SerializeField] private Stat _demonModeDamageMultiplier;       // conditional

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnAnyMasteryChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
        EventManager.OnModuleRarityChange += UpdateValue;
        EventManager.OnSubEffectLimitChange += UpdateValue;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _damageCardValue) UpdateValue();
    }

    private void UpdateValue(Card card)
    {
        if (card == _damageCard) UpdateValue();
        if (card == _berserkerCard) UpdateValue();
        if (card == _energyNetCard) UpdateValue();
        if (card == _demonModeCard) UpdateValue();
    }

    private void UpdateValue(CardMastery mastery)
    {
        //if (mastery == _damageCardMastery) UpdateValue();
        if (mastery == _berserkerCardMastery) UpdateValue();
        if (mastery == _energyNetCardMastery) UpdateValue();
        if (mastery == _demonModeCardMastery) UpdateValue();
    }

    private void UpdateValue(ModuleSlot slot)
    {
        if (slot == _moduleSlot) UpdateValue();
    }

    private void UpdateValue(ModuleType type, bool isFull)
    {
        if (type == _moduleSlot.ModuleType) UpdateValue();
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _damageMulti) UpdateValue();
        if (perk == _moreTowerDamageMoreBossHealth) UpdateValue();
        if (perk == _lessEnemyDamageLessTowerDamage) UpdateValue();
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
        multiplier *= (1 + _relicManager.TowerDamage);
        if (_moduleSlot.EquippedModule != _moduleSlot.ModuleList[0]) multiplier *= _moduleSlot.Value;
        if (_damageCard.IsEquipped) multiplier *= _damageCardValue.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (_berserkerCard.IsEquipped) multiplier *= (1 + _berserkerCard.Value);
        if (!_damageMulti.IsBanned) multiplier *= _damageMulti.Value;       //check if banned

        if (!_moreTowerDamageMoreBossHealth.IsBanned)
            multiplier *= _moreTowerDamageMoreBossHealth.Value;   //check if banned

        if (!_lessEnemyDamageLessTowerDamage.IsBanned)
            multiplier *= (1 + _lessEnemyDamageLessTowerDamage.NegativeValue); //check if banned

        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        //multiplier *= (1 + _spotlight.Value);
        if (_energyNetCard.IsEquipped && _energyNetCardMastery.Enabled)
            multiplier *= _energyNetCardMastery.Value;

        if (_demonModeCard.IsEquipped)
        {
            if(_demonModeCardMastery.Enabled)
                multiplier *= _demonModeCardMastery.Value;
            else
                multiplier *= _demonModeDamageMultiplier.Value;
        }
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }
}
