using UnityEngine;

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

    public void SetLevel(int levelChange)
    {
        _currentLevel += levelChange;
        _currentLevel = (_currentLevel < BaseLevel) ? BaseLevel : _currentLevel;
        _currentLevel = (_currentLevel > MaxLevel) ? MaxLevel : _currentLevel;
        EventManager.EffectChanged(this);
    }
}
