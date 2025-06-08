using UnityEngine;

public class NewStat : Modifier
{
    [SerializeField] private string _name;
    [SerializeField] private ValueCalculation _data;
    [SerializeField] private int _currentLevel = 0;

    public string Name { get { return _name; } }
    public int Level { get { return _currentLevel; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public bool IsMaxLevel { get { return (_currentLevel == _data.MaxLevel); } }

    public void SetLevel(int level)
    {
        if (level > _data.MaxLevel) level = _data.MaxLevel; // check new level is not above max level
        if (level < 0) level = 0;                               // check new level is not below base level
        _currentLevel = level;
    }

    public override float Value()
    {
        return _data.Value(_currentLevel);
    }

    public void SetInUse(bool inUse)
    {
        this._isInUse = inUse;
        if (!inUse) _currentLevel = 0;
    }

    public void SetToMaxLevel()
    {
        _currentLevel = _data.MaxLevel;
        this._isInUse = true;
    }

    public void ResetStat()
    {
        _currentLevel = 0;
        this._isInUse = false;
    }
}