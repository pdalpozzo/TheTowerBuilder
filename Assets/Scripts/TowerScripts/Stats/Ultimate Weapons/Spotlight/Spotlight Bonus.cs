using UnityEngine;

public class SpotlightBonus : Stat
{
    [SerializeField] private Perk _spotlightDamageBonus;   // in round

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
        if (!_spotlightDamageBonus.IsBanned)
            _multiplier *= _spotlightDamageBonus.Value;   //check if banned
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
