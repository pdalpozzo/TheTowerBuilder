using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : Stat
{
    [SerializeField] private Stat _damageStat;          // base
    [SerializeField] private Card _superTowerCard;      // conditional
    // Lab is Light Speed Projectiles
    private bool _isLightSpeed = false;

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        _isLightSpeed = _lab.IsMaxLevel;
        EventManager.OnAnyStatChange += UpdateStat;
        EventManager.OnAnyCardChange += UpdateValue;
    }

    public string ProjectileSpeed()
    {
        string value = (_isLightSpeed) ? "Light Speed Projectiles" : "Slow Projectiles";
        return value;
    }

    protected void UpdateStat(Stat stat)
    {
        if (stat == _damageStat) UpdateValue();
    }

    private void UpdateValue(Card card)
    {
        if (card == _superTowerCard) UpdateValue();
    }

    protected override void UpdateValue()
    {
        _isLightSpeed = _lab.IsMaxLevel;

        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        _value = multiplier * (_base + additional);

        // in round buffs
        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        if (_superTowerCard.IsEquipped) multiplier *= _superTowerCard.Value;
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = _damageStat.Value;
    }
}
