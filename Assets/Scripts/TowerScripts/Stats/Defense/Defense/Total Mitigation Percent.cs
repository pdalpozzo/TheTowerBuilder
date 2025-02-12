using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalMitigationPercent : Stat
{
    [SerializeField] private Stat _defensePercent;                          // permanant
    [SerializeField] private UltimateWeapon _chronoField;                   // ultimate weapon
    [SerializeField] private Stat _chronoFieldDamageReduction;              // conditional
    [SerializeField] private Bot _flameBot;                                 // bot
    [SerializeField] private Stat _flameBotDamageReduction;                 // conditional
    [SerializeField] private UltimateWeapon _chainLightning;                // ultimate weapon
    [SerializeField] private Stat _chainLightningThunderDamageReduction;    // conditional

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyStatChange += UpdateStat;
        EventManager.OnUltimateWeaponStatusChange += UpdateValue;
        EventManager.OnAnyBotChange += UpdateValue;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _defensePercent) UpdateValue();
        if (stat == _chronoFieldDamageReduction) UpdateValue();
        if (stat == _flameBotDamageReduction) UpdateValue();
        if (stat == _chainLightningThunderDamageReduction) UpdateValue();
    }

    private void UpdateValue(UltimateWeaponType ultimateWeapon, bool isOn)
    {
        if (ultimateWeapon == _chronoField.UltimateWeaponType) UpdateValue();
    }

    private void UpdateValue(Bot bot)
    {
        if (bot == _flameBot) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        _base = (_defensePercent.Upgrade.IsUnlocked) ? _defensePercent.Value : _base;
        _value = multiplier * (_base + additional);

        // in round buffs
        _base = (_defensePercent.Upgrade.IsUnlocked) ? _defensePercent.InRoundValue : _base;
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        _base = (_defensePercent.Upgrade.IsUnlocked) ? _defensePercent.ConditionalValue : _base;
        float subTotal = multiplier * (_base + additional);

        if (_chronoField.IsOn)
            subTotal += (1 - subTotal) * _chronoFieldDamageReduction.Value;

        if (_flameBot.IsOn)
            subTotal += (1 - subTotal) * _flameBotDamageReduction.Value;

        _conditionalValue = subTotal;

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = 0;
    }
}
