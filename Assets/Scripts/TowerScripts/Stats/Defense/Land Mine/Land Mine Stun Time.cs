using UnityEngine;

public class LandMineStunTime : Stat
{
    [SerializeField] private Card _landMineStunCard;        // permanant

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
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _newbase = _landMineStunCard.Value;
    }

    protected override void UpdateValue()
    {
    }
}
