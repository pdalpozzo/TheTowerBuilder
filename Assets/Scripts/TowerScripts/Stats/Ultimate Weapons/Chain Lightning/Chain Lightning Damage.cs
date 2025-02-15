using UnityEngine;

public class ChainLightningDamage : Stat
{
    [SerializeField] private Perk _chainLightningDamage;   // in round

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
        if (!_chainLightningDamage.IsBanned)
            _multiplier *= _chainLightningDamage.Value;   //check if banned
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _newbase = _effect.Value;
    }

    protected override void UpdateValue()
    {
    }
}
