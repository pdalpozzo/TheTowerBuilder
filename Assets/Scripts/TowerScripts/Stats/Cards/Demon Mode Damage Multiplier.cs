using UnityEngine;

public class DemonModeDamageMultiplier : Stat
{
    [SerializeField] private Card _card;            // permanant
    private float _demonModeMultiplier = 3;

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
        _newbase = _demonModeMultiplier;
    }

    protected override void UpdateValue()
    {
    }
}
