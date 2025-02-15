using UnityEngine;

public class SuperTowerCooldown : Stat
{
    [SerializeField] private CardMastery _mastery;  // permanant
    private float _cooldown = 30;

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
        _newbase = _cooldown;
    }

    protected override void UpdateValue()
    {
    }
}