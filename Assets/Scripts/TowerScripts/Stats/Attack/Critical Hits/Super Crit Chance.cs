using UnityEngine;

public class SuperCritChance : Stat
{
    [SerializeField] private Card _criticalChanceCard;                  // permanant
    [SerializeField] private CardMastery _criticalChanceCardMastery;    // permanant

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
        _additional += _relicManager.SuperCritChance;
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;
        if (_criticalChanceCard.IsEquipped && _criticalChanceCardMastery.Enabled)
            _additional += _criticalChanceCardMastery.Value;
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
        _base = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
    }

    protected override void UpdateValue()
    {
    }
}
