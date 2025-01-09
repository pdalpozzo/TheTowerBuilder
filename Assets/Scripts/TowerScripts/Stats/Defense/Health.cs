using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Stat
{
    [SerializeField] private Card _healthCard;                      // permanant
    [SerializeField] private Perk _maxHealthMulti;                  // in round
    [SerializeField] private Perk _moreCoinsLessTowerHealth;        // in round
    [SerializeField] private Perk _moreHealthRegenLessTowerHealth;  // in round
    [SerializeField] private ModuleSlot _moduleSlot;
    [SerializeField] private RelicManager _relicManager;

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
        if (card == _healthCard) UpdateValue();
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
        if (perk == _maxHealthMulti) UpdateValue();
        if (perk == _moreCoinsLessTowerHealth) UpdateValue();
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
        multiplier *= (1 + _relicManager.TowerDamage);
        if (_moduleSlot.EquippedModule != _moduleSlot.ModuleList[0]) multiplier *= _moduleSlot.Value;
        if (_healthCard.IsEquipped) multiplier *= _healthCard.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_maxHealthMulti.IsBanned) multiplier *= _maxHealthMulti.Value;   //check if banned

        if (!_moreCoinsLessTowerHealth.IsBanned) 
            multiplier *= (1 + _moreCoinsLessTowerHealth.NegativeValue);   //check if banned

        if (!_moreHealthRegenLessTowerHealth.IsBanned) 
            multiplier *= (1 + _moreHealthRegenLessTowerHealth.NegativeValue);   //check if banned

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
