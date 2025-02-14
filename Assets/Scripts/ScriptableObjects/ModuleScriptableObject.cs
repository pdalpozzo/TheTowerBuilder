using UnityEngine;

[CreateAssetMenu(fileName = "Module", menuName = "ScriptableObjects/Module")]
public class ModuleScriptableObject : ScriptableObject
{
    [SerializeField] private string _moduleName;
    [SerializeField] private Rarity _baseRarity = Rarity.EPIC;
    [SerializeField] private float[] _uniqueValues;
    [SerializeField] private string _prefix;
    [SerializeField] private string _suffix;
    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;
    [SerializeField] private bool _isNone = false;
    [SerializeField] private bool _isNonEpic = false;
    [SerializeField] private Sprite _icon;

    public string Name { get { return _moduleName; } }
    public string Prefix { get { return _prefix; } }
    public string Suffix { get { return _suffix; } }
    public Rarity Rarity { get { return _baseRarity; } }
    public bool IsNone { get { return _isNone; } }
    public bool IsNonEpic { get { return _isNonEpic; } }
    public Sprite Icon { get { return _icon; } }

    public float Value(int level)
    {
        level -= 2;
        if (level < 0) level = 0;
        if (level >= _uniqueValues.Length) level = _uniqueValues.Length - 1;
        return _uniqueValues[level];
    }

    public string ValueDisplay(int level)
    {
        string valueDisplay = string.Empty;
        valueDisplay = StringFormating.Format(Value(level), _formatType, _decimalPlaces);
        return valueDisplay;
    }
}
