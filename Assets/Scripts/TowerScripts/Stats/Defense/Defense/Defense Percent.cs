using UnityEngine;

public class DefensePercent : Stat
{
    [SerializeField] private Card _extraDefenseCard;        // permanant
    [SerializeField] private Stat _extraDefenseCardValue;   // permanant
    [SerializeField] private Stat _defenseCap;              // permanant
    [SerializeField] private Perk _additionalDefense;       // in round

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
        _additional += _lab.Value;
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
        if (_extraDefenseCard.IsEquipped) _additional += _extraDefenseCardValue.Value;
        CreateValue();
        _value = (_value > _defenseCap.Value) ? _defenseCap.Value : _value;
    }

    private void InRoundBuffs()
    {
        if (!_additionalDefense.IsBanned) _additional += _additionalDefense.Value;   //check if banned
        CreateInRoundValue();
        _inRoundValue = (_inRoundValue > _defenseCap.Value) ? _defenseCap.Value : _inRoundValue;
    }

    private void ConditionalBuffs()
    {
        CreateConditionalValue();
        _conditionalValue = (_conditionalValue > _defenseCap.Value) ? _defenseCap.Value : _conditionalValue;
    }

    private void UpdateBase()
    {
        _base = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
    }
}
