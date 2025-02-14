using UnityEngine;

[CreateAssetMenu(fileName = "Sub Effect", menuName = "ScriptableObjects/Sub Effect")]
public class SubEffectScriptableObject : ScriptableObject
{
    [SerializeField] private string _subEffectName;
    [SerializeField] private Rarity _baseRarity;
    [SerializeField] private ModuleType _type;
    [SerializeField] private float[] _values; // a value of 0 means that the sub effect is not available at that rarity
    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;

    public string Name { get { return _subEffectName; } }
    public Rarity Rarity { get { return _baseRarity; } }
    public ModuleType ModuleType { get { return _type; } }
    public int DecimalPlaces { get { return _decimalPlaces; } }
    public StringFormatType FormatType { get { return _formatType; } }

    public float GetValue(int level)
    {
        return _values[level];
    }
}
