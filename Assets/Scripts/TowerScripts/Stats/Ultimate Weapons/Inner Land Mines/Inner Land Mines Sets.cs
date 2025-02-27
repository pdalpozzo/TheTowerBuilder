using UnityEngine;

public class InnerLandMinesSets : Stat
{
    [SerializeField] private Perk _innerLandMineAdditionalSet;   // in round

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
        if (!_innerLandMineAdditionalSet.IsBanned)
            _additional += _innerLandMineAdditionalSet.Value;   //check if banned
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
