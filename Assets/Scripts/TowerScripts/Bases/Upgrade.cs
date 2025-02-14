using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradeScriptableObject _data;
    [SerializeField] private int _currentLevel = 0;     // does not need to be serialized
    //[SerializeField] private bool _isUnlocked;          // does not need to be serialized, used for unlocking workshops
    private bool _isUnlocked = false;

    public float Value { get { return _data.GetValue(_currentLevel); } }
    public int Level { get { return _currentLevel; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public int BaseLevel { get { return _data.BaseLevel; } }
    public bool IsMaxLevel { get { return (_currentLevel == MaxLevel); } }
    public bool IsUnlocked {  get { return _isUnlocked; } }

    public void NewLevel(int level)
    {
        ChangeLevel(level);
    }

    public void SetUnlock(bool isUnlocked)
    {
        _isUnlocked = isUnlocked;
    }

    private void ChangeLevel(int level)
    {
        if (level > _data.MaxLevel) level = _data.MaxLevel;       // check new level is not above max level
        if (level < _data.BaseLevel) level = _data.BaseLevel;     // check new level is not below base level
        _currentLevel = level;
    }

}
