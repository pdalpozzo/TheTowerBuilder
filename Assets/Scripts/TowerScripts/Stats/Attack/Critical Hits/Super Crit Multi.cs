using UnityEngine;

public class SuperCritMulti : Stat
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
        _multiplier *= _enhancement.Value;
        _multiplier *= _lab.Value;
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
        _newbase = (_upgrade.IsUnlocked) ? _upgrade.Value : 0;
    }

    protected override void UpdateValue()
    {
    }
}
