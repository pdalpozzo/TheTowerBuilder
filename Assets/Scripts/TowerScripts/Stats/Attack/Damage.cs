using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Stat
{
    [SerializeField] private Card _damageCard;                      // permanant
    [SerializeField] private Card _berserkerCard;                   // in round
    [SerializeField] private Perk _damageMulti;                     // in round
    [SerializeField] private Perk _moreTowerDamageMoreBossHealth;   // in round
    [SerializeField] private Perk _lessEnemyDamageLessTowerDamage;  // in round
    [SerializeField] private ModuleSlot _moduleSlot;
    [SerializeField] private RelicManager _relicManager;

    [SerializeField] private UltimateWeapon _spotlight;             // conditional

    private float _base = 0;

    private new void Start()
    {
        base.Start(); 
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
        EventManager.OnRelicBonusChange += UpdateValue;
        EventManager.OnModuleRarityChange += UpdateValue;
        EventManager.OnSubEffectLimitChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _damageCard) UpdateValue();
        if (card == _berserkerCard) UpdateValue();
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
        if (_damageCard.IsEquipped) multiplier *= _damageCard.Value;
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
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }
}
