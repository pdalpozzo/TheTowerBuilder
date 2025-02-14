using UnityEngine;

public class Enhancement : MonoBehaviour
{
    [SerializeField] private EnhanceScriptableObject _data;
    private int _currentLevel = 0; 
    private bool _isUnlocked = false;

    public string ValueDisplay { get { return CreateDescription(); } }
    public float Value { get { return _data.Value(_currentLevel); } }
    public int Level { get { return _currentLevel; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public bool IsMaxLevel { get { return (_currentLevel == MaxLevel); } }

    public void NewLevel(int level)
    {
        ChangeLevel(level);
    }

    public void SetUnlock(bool isUnlocked)
    {
        _isUnlocked = isUnlocked;
    }

    private string CreateDescription()
    {
        return StringFormating.Format(_data.Value(_currentLevel), StringFormatType.MULTIPLIER, 2);
    }

    private void ChangeLevel(int level)
    {
        if (level > _data.MaxLevel) level = _data.MaxLevel;       // check new level is not above max level
        if (level < _data.BaseLevel) level = _data.BaseLevel;     // check new level is not below base level
        _currentLevel = level;
    }
}
