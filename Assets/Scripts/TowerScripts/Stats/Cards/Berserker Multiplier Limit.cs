using UnityEngine;

public class BerserkerMultiplierLimit : Stat
{
    [SerializeField] private Card _card;            // permanant
    [SerializeField] private CardMastery _mastery;
    private float _berserkerMultiplierLimit = 3;
    private float _vikingFuneralMultiplierLimit = 500;

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
        if (_card.IsEquipped && _mastery.Enabled) _base = _vikingFuneralMultiplierLimit/ _berserkerMultiplierLimit;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = (_card.IsEquipped) ? _berserkerMultiplierLimit : 1;
    }

    protected override void UpdateValue()
    {
    }
}
