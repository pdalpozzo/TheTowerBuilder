using UnityEngine;

public class Health : Stat
{
    [SerializeField] private Card _healthCard;                      // permanant
    [SerializeField] private Stat _healthCardValue;                 // permanant
    [SerializeField] private ModuleSlot _moduleSlot;                // permanant

    [SerializeField] private Perk _maxHealthMulti;                  // in round
    [SerializeField] private Perk _moreCoinsLessTowerHealth;        // in round
    [SerializeField] private Perk _moreHealthRegenLessTowerHealth;  // in round

    [SerializeField] private UltimateWeapon _deathWave;             // ultimate weapon
    [SerializeField] private Stat _deathWaveHealthBonus;            // conditional

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
        _multiplier *= (1 + _relicManager.TowerHealth);
        if (_moduleSlot.EquippedModule != _moduleSlot.ModuleList[0]) _multiplier *= _moduleSlot.Value;
        if (_healthCard.IsEquipped) _multiplier *= _healthCardValue.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_maxHealthMulti.IsBanned) _multiplier *= _maxHealthMulti.Value;   //check if banned

        if (!_moreCoinsLessTowerHealth.IsBanned)
            _multiplier *= (1 + _moreCoinsLessTowerHealth.NegativeValue);   //check if banned

        if (!_moreHealthRegenLessTowerHealth.IsBanned)
            _multiplier *= (1 + _moreHealthRegenLessTowerHealth.NegativeValue);   //check if banned
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        if (_deathWave.IsOn) // FIX
            _multiplier *= 12.5f;
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
