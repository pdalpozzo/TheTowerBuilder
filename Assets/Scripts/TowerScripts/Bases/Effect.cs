using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectSlot { ONE, TWO, THREE, FOUR, PLUS };

public class Effect : MonoBehaviour
{
    [SerializeField] private EffectScriptableObject _data;
    [SerializeField] private int _currentLevel = 0;

    public string Name { get { return _data.Name; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public int BaseLevel { get { return _data.BaseLevel; } }
    public int Level { get { return _currentLevel; } }
    public float Value { get { return _data.GetValue(_currentLevel); } }
    public bool IsMaxLevel { get { return (_currentLevel == MaxLevel); } }

    public string ValueString() 
    {
        return _data.GetStringFormat(Value);
    }

    //public int GetLevel()
    //{
    //    return _level;
    //}

    //public float GetValue(int level)
    //{
    //    return _levelValues.GetValue(level);
    //}

    public void SetLevel(int levelChange)
    {
        _currentLevel += levelChange;
        _currentLevel = (_currentLevel < BaseLevel) ? BaseLevel : _currentLevel;
        _currentLevel = (_currentLevel > MaxLevel) ? MaxLevel : _currentLevel;
        EventManager.EffectChanged(this);
    }
}
