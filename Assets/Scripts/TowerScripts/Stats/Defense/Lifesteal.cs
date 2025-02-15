using UnityEngine;

public class Lifesteal : Stat
{
    [SerializeField] private Perk _moreLifestealLessKnockbackForce;         // in round
    [SerializeField] private Perk _lessEnemyHealthLessRegenLifesteal;       // in round

    private void Update()
    {
        ResetValues();
        UpdateBase();
        PermanentBuffs();
        InRoundBuffs();
        ConditionalBuffs();
        CreateDescriptions();
    }

    private void PermanentBuffs()
    {
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_moreLifestealLessKnockbackForce.IsBanned)
            _multiplier *= _moreLifestealLessKnockbackForce.Value;   //check if banned

        if (!_lessEnemyHealthLessRegenLifesteal.IsBanned)
            _multiplier *= (1 + _lessEnemyHealthLessRegenLifesteal.NegativeValue);   //check if banned
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
    }

    protected override void UpdateValue()
    {
    }
}
