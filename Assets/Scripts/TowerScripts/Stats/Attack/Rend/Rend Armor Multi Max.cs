using UnityEngine;

public class RendArmorMultiMax : Stat
{
    [SerializeField] private Stat _rendArmorMulti;      // per hit
    private int _hitsToMax = 0;

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
        _multiplier *= _enhancement.Value;
        CreateValue();
        _hitsToMax = 0;
        if (_rendArmorMulti.Value > 0) _hitsToMax = Mathf.CeilToInt(_value / _rendArmorMulti.Value);
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
        _base = _lab.Value;
    }
}
