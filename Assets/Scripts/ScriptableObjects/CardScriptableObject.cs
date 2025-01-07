using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class CardScriptableObject : ScriptableObject
{
    [SerializeField] private string _cardName;
    //[TextArea(3, 10)][SerializeField] private string _tooltipMessage;
    [SerializeField] private float[] _values;
    [SerializeField] private Rarity _rarity;
    [SerializeField] private Sprite _icon;

    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;

    [SerializeField] private string _prefix = "";
    //[SerializeField] private string _middle = "";
    [SerializeField] private string _suffix = "";

    //[SerializeField] private int _maxLevel = 7;
    //[SerializeField] private int _baseLevel = 0;

    public string Name { get { return _cardName; } }
    //public string Tooltip { get { return _tooltipMessage; } }
    public Rarity Rarity { get { return _rarity; } }
    public Sprite Icon { get { return _icon; } }
    public int MaxLevel { get { return _values.Length - 1; } }
    public int BaseLevel { get { return 0; } }
    public string Prefix { get { return _prefix; } }
    //public string Middle { get { return _middle; } }
    public string Suffix { get { return _suffix; } }
    //public string ValueDisplay { get { return ValueDisplay(value); } }

    public float Value(int level)
    {
        return _values[level];
    }

    public string ValueDisplay(int level)
    {
        string valueDisplay = string.Empty;
        valueDisplay = StringFormating.Format(Value(level), _formatType, _decimalPlaces);
        return valueDisplay;
    }
}
