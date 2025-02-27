using UnityEngine;

public class SmartMissilesQuantity : Stat
{
    [SerializeField] private Perk _smartMissileQuantity;   // in round

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
        if (!_smartMissileQuantity.IsBanned)
            _additional += _smartMissileQuantity.Value;   //check if banned
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
