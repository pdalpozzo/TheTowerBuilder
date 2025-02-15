using UnityEngine;

public class PoisonSwampRadius : Stat
{
    [SerializeField] private Perk _poisonSwampRadius;   // in round

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
        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_poisonSwampRadius.IsBanned)
            _multiplier *= _poisonSwampRadius.Value;   //check if banned
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = 5; // not sure what the base radius is
    }

    protected override void UpdateValue()
    {
    }
}
