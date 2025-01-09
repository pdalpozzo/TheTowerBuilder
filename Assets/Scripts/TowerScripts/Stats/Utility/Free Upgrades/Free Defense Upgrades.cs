using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeDefenseUpgrades : Stat
{
    [SerializeField] private Card _freeUpgradesCard;        // permanant
    [SerializeField] private Perk _freeUpgradesForAll;      // in round
    [SerializeField] private Stat _freeUpgradeStat;         // enhancement

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
        EventManager.OnAnyStatChange += FreeUpgradeEnhancement;
    }

    private void UpdateValue(Card card)
    {
        if (card == _freeUpgradesCard) UpdateValue();
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _freeUpgradesForAll) UpdateValue();
    }

    private void FreeUpgradeEnhancement(Stat stat)
    {
        if (stat == _freeUpgradeStat) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        multiplier *= _freeUpgradeStat.Value;
        if (_subEffect.IsEquipped) additional += _subEffect.Value;
        if (_freeUpgradesCard.IsEquipped) additional += _freeUpgradesCard.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_freeUpgradesForAll.IsBanned) additional += _freeUpgradesForAll.Value;   //check if banned

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
