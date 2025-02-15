using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "ScriptableObjects/Effect")]
public class EffectScriptableObject : ScriptableObject
{
    [SerializeField] private string _effectName;
    [SerializeField] private float _baseValue;
    [SerializeField] private float _valueIncrement;
    [SerializeField] private float[] _values;
    [SerializeField] private bool _noIncrement;
    [SerializeField] private int _maxLevel = 30;
    [SerializeField] private int _baseLevel = 0;

    //[SerializeField] private StringFormatType _formatType;
    //[SerializeField] private int _decimalPlaces = 0;

    public string Name { get { return _effectName; } }
    public int BaseLevel { get { return _baseLevel; } }
    public int MaxLevel { get { return _maxLevel; } }

    public float GetValue(int level)
    {
        return Value(level);
    }

    private float Value(int level)
    {
        float value = _baseValue;
        value = (_noIncrement) ? _values[level] : (_baseValue + (_valueIncrement * level));
        return value;
    }
}
