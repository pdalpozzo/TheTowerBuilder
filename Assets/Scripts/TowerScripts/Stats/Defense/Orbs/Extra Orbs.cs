using UnityEngine;

public class ExtraOrbs : Stat
{
    [SerializeField] private Card _extraOrbsCard;        // permanant

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
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _newbase = _extraOrbsCard.Value;
    }

    protected override void UpdateValue()
    {
    }
}
