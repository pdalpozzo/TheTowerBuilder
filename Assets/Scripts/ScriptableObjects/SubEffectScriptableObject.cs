using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sub Effect", menuName = "ScriptableObjects/Sub Effect")]
public class SubEffectScriptableObject : ScriptableObject
{
    [SerializeField] private string _subEffectName;
    //[TextArea(3, 10)][SerializeField] private string _tooltipMessage;
    [SerializeField] private Rarity _baseRarity;
    [SerializeField] private ModuleType _type;
    // values are listed backwards due to lower rarities not having values
    [SerializeField] private float[] _values;
    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;

    public string Name { get { return _subEffectName; } }
    //public string Tooltip { get { return _tooltipMessage; } }
    public Rarity Rarity { get { return _baseRarity; } }
    public ModuleType ModuleType { get { return _type; } }
    public int DecimalPlaces { get { return _decimalPlaces; } }
    public StringFormatType FormatType { get { return _formatType; } }

    public float GetValue(int level)
    {
        return _values[level];
    }
}
