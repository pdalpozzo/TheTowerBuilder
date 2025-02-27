using UnityEngine;

public class BlackHoleDuration : Stat
{
    [SerializeField] private Perk _blackHoleDuration;   // in round

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
        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_blackHoleDuration.IsBanned)
            _additional += _blackHoleDuration.Value;   //check if banned
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = _effect.Value;
    }
}
