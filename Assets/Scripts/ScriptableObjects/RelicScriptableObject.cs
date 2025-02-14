using UnityEngine;

[CreateAssetMenu(fileName = "Relic", menuName = "ScriptableObjects/Relic")]
public class RelicScriptableObject : ScriptableObject
{
    [SerializeField] private string _relicName;
    [SerializeField] private Rarity _rarity = Rarity.RARE;
    [SerializeField] private RelicType _relicType;
    [SerializeField] private float _value;
    [SerializeField] private int _decimalPlaces = 2;
    [SerializeField] private StringFormatType _formatType;

    public string Name { get { return _relicName; } }
    public Rarity Rarity { get { return _rarity; } }
    public RelicType RelicType { get { return _relicType; } }
    public float Value { get { return _value; } }
    public int DecimalPlaces { get { return _decimalPlaces; } }
    public StringFormatType FormatType { get { return _formatType; } }
}
