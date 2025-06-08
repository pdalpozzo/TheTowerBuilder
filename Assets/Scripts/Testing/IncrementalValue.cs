using UnityEngine;

[CreateAssetMenu(fileName = "IncrementalValue", menuName = "ScriptableObjects/Values/Incremental")]
public class IncrementalValue : ValueCalculation
{
    [SerializeField] private int _maxLevel = 99;
    [SerializeField] private float _baseValue = 0;
    [SerializeField] private float _valueIncrement;

    public override int GetMaxLevel()
    {
        return _maxLevel;
    }

    public override float Value(int level)
    {
        if (level <= 0) return _baseValue;
        if (level > _maxLevel) level = _maxLevel;
        return (_baseValue + (_valueIncrement * level));
    }
}

