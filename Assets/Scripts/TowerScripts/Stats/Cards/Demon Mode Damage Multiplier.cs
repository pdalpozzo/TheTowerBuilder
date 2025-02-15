using UnityEngine;

public class DemonModeDamageMultiplier : Stat
{
    [SerializeField] private Card _card;            // permanant
    [SerializeField] private CardMastery _mastery;
    private float _demonModeMultiplier = 3;

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
        CreateValue();
    }

    private void InRoundBuffs()
    {
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        if (_card.IsEquipped && _mastery.Enabled) _multiplier *= _mastery.Value;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = (_card.IsEquipped)? _demonModeMultiplier : 1;
    }

    protected override void UpdateValue()
    {
    }
}
