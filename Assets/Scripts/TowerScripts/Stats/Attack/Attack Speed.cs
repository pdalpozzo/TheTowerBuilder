using UnityEngine;

public class AttackSpeed : Stat
{
    [SerializeField] private Card _attackSpeedCard;         // permanant
    [SerializeField] private Stat _attackSpeedCardValue;    // permanant
    [SerializeField] private Stat _rapidFireMultiplier;     // conditional
    
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
        _multiplier *= (1 + _relicManager.AttackSpeed);
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
        if (_attackSpeedCard.IsEquipped) _multiplier *= _attackSpeedCardValue.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        _multiplier *= _rapidFireMultiplier.Value;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _newbase = _upgrade.Value;
    }

    protected override void UpdateValue()
    {
    }
}
