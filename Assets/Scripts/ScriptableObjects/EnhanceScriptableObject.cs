using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "Enhancement", menuName = "ScriptableObjects/Enhancement")]
public class EnhanceScriptableObject : ScriptableObject
{
    [SerializeField] private int _maxLevel = 300;

    private int _baseLevel = 0;
    private float _baseValue = 1;
    private float _valueIncrement = 0.01f;

    public int BaseLevel { get { return _baseLevel; } }
    public int MaxLevel { get { return _maxLevel; } }


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
