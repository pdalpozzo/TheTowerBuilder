using UnityEngine;

public class SuperCritDamage : Stat
{
    [SerializeField] private Stat _projectileDamage;    // base
    [SerializeField] private Stat _criticalFactor;      // permanant
    [SerializeField] private Stat _superCritMulti;      // permanant

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
        _multiplier *= _criticalFactor.Value;
        if (_superCritMulti.Upgrade.IsUnlocked) _multiplier *= _superCritMulti.Value;
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
        _newbase = _projectileDamage.Value;
    }

    protected override void UpdateValue()
    {
    }
}
