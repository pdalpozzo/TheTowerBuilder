using UnityEngine;

[CreateAssetMenu (fileName ="Upgrade", menuName = "ScriptableObjects/Upgrade")]
public class UpgradeScriptableObject : ScriptableObject
{
    [SerializeField] private float _baseValue = 0;
    [SerializeField] private float _valueIncrement;
    [SerializeField] private int _maxLevel = 99;
    [SerializeField] private int _baseLevel = 0;    // does not need to be serialized

    [SerializeField] private enum IncrementType { INCREMENTAL, ALL_VALUES }; //, CASCADE, FORMULA };
    [SerializeField] private IncrementType _incrementType;

    //[SerializeField] private int[] _brackets;
    [SerializeField] private float[] _valueIncrements;

    public int BaseLevel { get { return _baseLevel; } }
    public int MaxLevel { get { return _maxLevel; } }

    public float GetValue(int level)
    {
        switch(_incrementType)
        {
            case IncrementType.INCREMENTAL:
                return IncrementalValue(level);
            case IncrementType.ALL_VALUES:
                return AllValues(level);
            default:
                return IncrementalValue(level);
        }
    }

    private float IncrementalValue(int level)
    {
        return (_baseValue + (_valueIncrement * level));
    }

    //private float BracketValue(int level)
    //{
    //    float value = _baseValue;
    //    int bracket = 0;
    //    for (int i = 1; i <= level; i++)
    //    {
    //        if (i > _brackets[bracket]) bracket++;
    //        value += _valueIncrements[bracket];
    //    }
    //    return value;
    //}

    private float AllValues(int level)
    {
        if (_valueIncrements.Length < level) return 0;
        return _valueIncrements[level];
    }

    //private float CascadeValue(int level)
    //{
    //    if (level == 0) return 0;
    //    if (level == 1) return _baseValue;

    //    float value = _baseValue;
    //    float cascade = _baseValue;
    //    int bracket = 0;

    //    for (int i = 2; i <= level; i++)
    //    {
    //        if (i > _brackets[bracket]) bracket++;
    //        //value += valueIncrements[bracket];
    //        cascade = cascade - _valueIncrements[bracket];
    //        value += cascade;
    //    }
    //    return value;
    //}
}
