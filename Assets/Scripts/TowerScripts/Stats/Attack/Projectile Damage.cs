using UnityEngine;

public class ProjectileDamage : Stat
{
    [SerializeField] private Stat _damageStat;          // base
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
        _base = _damageStat.Value;
    }
}
