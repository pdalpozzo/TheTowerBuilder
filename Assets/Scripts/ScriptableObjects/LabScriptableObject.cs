using UnityEngine;

[CreateAssetMenu(fileName = "Lab", menuName = "ScriptableObjects/Lab")]
public class LabScriptableObject : ScriptableObject
{
    [SerializeField] private string _labName;
    [SerializeField] private float _baseValue = 1;
    [SerializeField] private float _valueIncrement;
    [SerializeField] private int _maxLevel = 30;
    [SerializeField] private int _baseLevel = 0;

    [SerializeField] private IncrementType _incrementType;
    [SerializeField] private float[] _valueIncrements;

    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;
    [SerializeField] private bool _noSymbol = false;
    [SerializeField] private bool _isUnlockLab = false;    // true if only 1 level to unlock

    public string Name { get { return _labName; } }
    public int BaseLevel { get { return _baseLevel; } }
    public int MaxLevel { get { return _maxLevel; } }
    public int DecimalPlaces { get { return _decimalPlaces; } }
    public StringFormatType FormatType { get { return _formatType; } }
    public bool IsUnlockedLab {  get { return _isUnlockLab; } }
    public bool NoSymbol { get { return _noSymbol; } }

    public float Value(int level)
    {
        switch (_incrementType)
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

    private float AllValues(int level)
    {
        if (_valueIncrements.Length < level) return 0;
        return _valueIncrements[level];
    }

}
