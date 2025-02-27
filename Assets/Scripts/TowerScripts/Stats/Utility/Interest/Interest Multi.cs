using UnityEngine;

public class InterestMulti : Stat
{
    [SerializeField] private Perk _interestMultiPerk;   // perk

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
        _multiplier *= _lab.Value;
        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_interestMultiPerk.IsBanned) _multiplier *= _interestMultiPerk.Value;   //check if banned
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = 1;
    }
}
