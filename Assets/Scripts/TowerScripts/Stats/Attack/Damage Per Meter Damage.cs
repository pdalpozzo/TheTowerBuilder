using UnityEngine;

public class DamagePerMeterDamage : Stat
{
    [SerializeField] private Stat _projectileDamage;    // base
    [SerializeField] private Stat _range;               // permanant
    [SerializeField] private Stat _damagePerMeter;      // permanant
    [SerializeField] private Card _superTowerCard;      // conditional

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
        _multiplier *= (1 + (_damagePerMeter.Value * _range.Value));
        CreateValue();
    }

    private void InRoundBuffs()
    {
        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        if (_superTowerCard.IsEquipped) _multiplier *= _superTowerCard.Value;
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
