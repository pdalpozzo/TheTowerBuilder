using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Enhancement : MonoBehaviour
{
    [SerializeField] private EnhanceScriptableObject _data;
    private int _currentLevel = 0;

    public string ValueDisplay { get { return CreateDescription(); } }
    public float Value { get { return _data.Value(_currentLevel); } }
    public int Level { get { return _currentLevel; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public int BaseLevel { get { return _data.BaseLevel; } }
    public bool IsMaxLevel { get { return (_currentLevel == MaxLevel); } }

    public void NewLevel(int level)
    {
        ChangeLevel(level);
    }

    //public void Reset()
    //{
    //    ChangeLevel(BaseLevel);
    //}

    private string CreateDescription()
    {
        return StringFormating.Format(Value, StringFormatType.MULTIPLIER, 2);
    }

    private void ChangeLevel(int level)
    {
        if (level > MaxLevel) level = MaxLevel;       // check new level is not above max level
        if (level < BaseLevel) level = BaseLevel;     // check new level is not below base level
        _currentLevel = level;
    }


}
