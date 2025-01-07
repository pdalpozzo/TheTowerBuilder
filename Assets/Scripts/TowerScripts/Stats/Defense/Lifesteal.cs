using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifesteal : Stat
{
    [SerializeField] private Perk _moreLifestealLessKnockbackForce;         // in round
    [SerializeField] private Perk _lessEnemyHealthLessRegenLifesteal;       // in round

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnPerkStatusChange += UpdateValue;
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _moreLifestealLessKnockbackForce) UpdateValue();
        if (perk == _lessEnemyHealthLessRegenLifesteal) UpdateValue();
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        //additional += _subEffect.Value;
        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_moreLifestealLessKnockbackForce.IsBanned) 
            multiplier *= _moreLifestealLessKnockbackForce.Value;   //check if banned

        if (!_lessEnemyHealthLessRegenLifesteal.IsBanned) 
            multiplier *= (1 + _lessEnemyHealthLessRegenLifesteal.NegativeValue);   //check if banned

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
