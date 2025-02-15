using UnityEngine;

public class GoldenTowerMultiplier : Stat
{
    [SerializeField] private Perk _goldenTowerMultiplier;   // in round

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
        _value = (_multiplier * _newbase) + _additional;
    }

    private void InRoundBuffs()
    {
        if (!_goldenTowerMultiplier.IsBanned)
            _multiplier *= _goldenTowerMultiplier.Value;   //check if banned
        _inRoundValue = (_multiplier * _newbase) + _additional;
    }

    private void ConditionalBuffs()
    {
        _conditionalValue = (_multiplier * _newbase) + _additional;
    }

    private void UpdateBase()
    {
        _newbase = _effect.Value;
    }

    protected override void UpdateValue()
    {
    }
}
