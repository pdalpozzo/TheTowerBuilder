using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class CardScriptableObject : ScriptableObject
{
    [SerializeField] private string _cardName;
    [SerializeField] private float[] _values;
    [SerializeField] private Rarity _rarity;
    [SerializeField] private Sprite _icon;

    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;
    [SerializeField] private bool _noSymbol = false;

    [SerializeField] private string _prefix = "";
    [SerializeField] private string _suffix = "";

    public string Name { get { return _cardName; } }
    public Rarity Rarity { get { return _rarity; } }
    public Sprite Icon { get { return _icon; } }
    public int MaxLevel { get { return _values.Length - 1; } }
    public int BaseLevel { get { return 0; } }
    public int DecimalPlaces { get { return _decimalPlaces; } }
    public StringFormatType FormatType { get { return _formatType; } }
    public bool NoSymbol { get { return _noSymbol; } }
    public string Prefix { get { return _prefix; } }
    public string Suffix { get { return _suffix; } }

    public float Value(int level)
    {
        return _values[level];
    }
}
