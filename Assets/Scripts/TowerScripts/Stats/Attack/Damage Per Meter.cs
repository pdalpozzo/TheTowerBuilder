using UnityEngine;

public class DamagePerMeter : Stat
{
    [SerializeField] private Card _rangeCard;               // permanant
    [SerializeField] private CardMastery _rangeCardMastery; // permanant

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
        _multiplier *= (1 + _relicManager.DamagePerMeter);
        if (_subEffect.IsEquipped) _additional += _subEffect.Value;

        if (_rangeCard.IsEquipped && _rangeCardMastery.Enabled)
            _multiplier *= _rangeCardMastery.Value;
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
