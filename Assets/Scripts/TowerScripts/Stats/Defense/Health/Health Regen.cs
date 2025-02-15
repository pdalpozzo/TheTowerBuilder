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
        _multiplier *= _enhancement.Value;
        _multiplier *= _lab.Value;
        if (_subEffect.IsEquipped) _multiplier *= 1 + _subEffect.Value;
        if (_healthRegenCard.IsEquipped) _multiplier *= _healthRegenCardValue.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_healthRegenMulti.IsBanned) _multiplier *= _healthRegenMulti.Value;   //check if banned
        if (!_lessEnemyHealthLessRegenLifesteal.IsBanned)
            _multiplier *= (1 + _lessEnemyHealthLessRegenLifesteal.NegativeValue);   //check if banned

        if (!_moreHealthRegenLessTowerHealth.IsBanned)
            _multiplier *= _moreHealthRegenLessTowerHealth.Value;   //check if banned
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        if (_secondWindCard.IsEquipped && _secondWindCardMastery.Enabled)
            _multiplier *= _secondWindCardMastery.Value;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }

    protected override void UpdateValue()
    {
    }
}
