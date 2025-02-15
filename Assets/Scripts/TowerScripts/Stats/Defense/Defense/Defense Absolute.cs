using UnityEngine;

public class DefenseAbsolute : Stat
{
    [SerializeField] private Card _fortressCard;        // permanant
    [SerializeField] private Perk _defenseAbsMulti;     // in round

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
        if (_subEffect.IsEquipped) _multiplier *= 1 + _subEffect.Value;
        if (_fortressCard.IsEquipped) _multiplier *= _fortressCard.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_defenseAbsMulti.IsBanned) _multiplier *= _defenseAbsMulti.Value;   //check if banned
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
