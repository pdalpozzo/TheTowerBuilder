using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleType { CANNON, ARMOR, GENERATOR, CORE };

[CreateAssetMenu(fileName = "Module Slot", menuName = "ScriptableObjects/Module Slot")]
public class ModuleSlotScriptableObject : ScriptableObject
{
    [SerializeField] private string _slotName;
    [SerializeField] private string _suffix;
    [SerializeField] private ModuleType _type;
    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 3;
    [SerializeField] private float _baseValue = 0;
    [SerializeField] private float _increment = 0;

    public string Name { get { return _slotName; } }
    public string Suffix { get { return _suffix; } }
    public ModuleType ModuleType { get { return _type; } }
    public int DecimalPlaces { get { return _decimalPlaces; } }
    public StringFormatType FormatType { get { return _formatType; } }

    public float GetValue(int level)
    {
        float value = _baseValue;
        value += (_increment * level);
        return value;
    }
}
