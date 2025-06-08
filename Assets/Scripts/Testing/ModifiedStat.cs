using UnityEngine;


public class ModifiedStat : Modifier
{
    [SerializeField] private Modifier _baseStat;

    [SerializeField] private Modifier[] _additionalModifiers;
    [SerializeField] private Modifier[] _multiplicativeModifiers;
    [SerializeField] private Modifier[] _base0MultiplicativeModifiers;

    [SerializeField] private float _value = 0f;
    private float _additional = 0;
    private float _multiplier = 1;

    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;
    [SerializeField] private bool _noSymbol = false;

    public Modifier BaseStat { get { return _baseStat; } }

    private void Update()
    {
        // make sure we have a base stat to calculate with
        if (_baseStat == null) return;
        // check is the base stat is in use
        this._isInUse = _baseStat.IsInUse;

        CalculateAdditional();
        CalculateMultiplicative();
        CalculateBaseZeroMultiplicative();
        _value = _multiplier * (_baseStat.Value() + _additional);
    }

    private void CalculateAdditional()
    {
        _additional = 0;
        if (_additionalModifiers.Length <= 0 ) return; 
        if (!this._isInUse) return;

        foreach (var item in _additionalModifiers)
        {
            if (!item.IsInUse) continue;
            // change this to reference a global value of what to display
            // then copy to all calculation functions in this file
            if (item.Type != CalculationType.BASE) continue;
            _additional += item.Value();
        }
    }

    private void CalculateMultiplicative()
    {
        _multiplier = 1;
        if (_multiplicativeModifiers.Length <= 0) return;
        if (!this._isInUse) return;

        foreach (var item in _multiplicativeModifiers)
        {
            if (!item.IsInUse) continue;
            _multiplier *= item.Value();
        }
    }

    private void CalculateBaseZeroMultiplicative()
    {
        if (_base0MultiplicativeModifiers.Length <= 0) return;
        if (!this._isInUse) return;

        foreach (var item in _base0MultiplicativeModifiers)
        {
            if (!item.IsInUse) continue;
            _multiplier *= 1 + item.Value();
        }
    }

    public override float Value()
    {
        return _value;
    }

    public override string ToString()
    {
        string text = StringFormating.Format(_value, _formatType, _decimalPlaces, _noSymbol);
        return text;
    }
}
