using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Lab", menuName = "ScriptableObjects/Lab")]
public class LabScriptableObject : ScriptableObject
{
    [SerializeField] private string _labName;
    //[TextArea(3, 10)][SerializeField] private string _tooltipMessage;
    [SerializeField] private float _baseValue = 1;
    [SerializeField] private float _valueIncrement;
    [SerializeField] private int _maxLevel = 30;
    [SerializeField] private int _baseLevel = 0;
    [SerializeField] private int _decimalPlaces = 2;
    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private bool _isUnlockLab = false;    // true if only 1 level to unlock

    public string Name { get { return _labName; } }
    //public string Tooltip { get { return _tooltipMessage; } }
    public int BaseLevel { get { return _baseLevel; } }
    public int MaxLevel { get { return _maxLevel; } }
    public int DecimalPlaces { get { return _decimalPlaces; } }
    public StringFormatType FormatType { get { return _formatType; } }

    public float Value(int level)
    {
        return Calculate(level);
    }

    private float Calculate(int level)
    {
        float value = _baseValue;
        value += (_valueIncrement * level);
        return value;
    }
}
