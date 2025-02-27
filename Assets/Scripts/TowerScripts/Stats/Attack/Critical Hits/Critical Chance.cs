using UnityEngine;

public class CriticalChance : Stat
{
    [SerializeField] private Card _criticalChanceCard;      // permanant
    [SerializeField] private Stat _criticalChanceCardValue; // permanant

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
        if (_criticalChanceCard.IsEquipped) _additional += _criticalChanceCardValue.Value;
        _additional += _relicManager.CritChance;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
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
