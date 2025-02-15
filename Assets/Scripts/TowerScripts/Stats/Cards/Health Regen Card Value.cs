using UnityEngine;

public class HealthRegenCardValue : Stat
{
    [SerializeField] private Card _card;            // permanant
    [SerializeField] private CardMastery _mastery;  // permanant

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
        if (_mastery.Enabled) _multiplier *= _mastery.Value;
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
        _newbase = _card.Value;
    }

    protected override void UpdateValue()
    {
    }
}
