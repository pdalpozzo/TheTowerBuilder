using UnityEngine;

public class Damage : Stat
{
    [SerializeField] private Card _damageCard;                      // permanant
    [SerializeField] private Stat _damageCardValue;                 // permanant
    [SerializeField] private ModuleSlot _moduleSlot;                // permanant

    [SerializeField] private Perk _damageMulti;                     // in round
    [SerializeField] private Perk _moreTowerDamageMoreBossHealth;   // in round
    [SerializeField] private Perk _lessEnemyDamageLessTowerDamage;  // in round

    [SerializeField] private UltimateWeapon _spotlight;             // conditional
    [SerializeField] private Card _energyNetCard;                   // conditional
    [SerializeField] private CardMastery _energyNetCardMastery;     // conditional
    [SerializeField] private CardMastery _berserkerCardMastery;     // conditional
    [SerializeField] private Stat _berserkMultiplierLimit;          // conditional
    [SerializeField] private Stat _demonModeDamageMultiplier;       // conditional

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
        _multiplier *= (1 + _relicManager.TowerDamage);
        if (_moduleSlot.EquippedModule != _moduleSlot.ModuleList[0]) _multiplier *= _moduleSlot.Value;
        if (_damageCard.IsEquipped) _multiplier *= _damageCardValue.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        _multiplier *= _berserkMultiplierLimit.InRoundValue;
        if (!_damageMulti.IsBanned) _multiplier *= _damageMulti.Value;       //check if banned

        if (!_moreTowerDamageMoreBossHealth.IsBanned)
            _multiplier *= _moreTowerDamageMoreBossHealth.Value;   //check if banned

        if (!_lessEnemyDamageLessTowerDamage.IsBanned)
            _multiplier *= (1 + _lessEnemyDamageLessTowerDamage.NegativeValue); //check if banned

        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        //multiplier *= (1 + _spotlight.Value);
        if (_energyNetCard.IsEquipped && _energyNetCardMastery.Enabled)
            _multiplier *= _energyNetCardMastery.Value;

        if (_berserkerCardMastery.Enabled) _multiplier *= _berserkMultiplierLimit.ConditionalValue;
        _multiplier *= _demonModeDamageMultiplier.ConditionalValue;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = _upgrade.Value;
    }
}
