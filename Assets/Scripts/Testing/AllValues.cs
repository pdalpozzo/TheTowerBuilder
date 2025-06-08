using UnityEngine;

[CreateAssetMenu(fileName = "AllValue", menuName = "ScriptableObjects/Values/All")]
public class AllValues : ValueCalculation
{
    [SerializeField] private float[] _valueIncrements;

    public override int GetMaxLevel()
    {
        return _valueIncrements.Length - 1;
    }

    public override float Value(int level)
    {
        if (level <= 0) return _valueIncrements[0];
        if (level > _valueIncrements.Length - 1) level = _valueIncrements.Length - 1;
        return _valueIncrements[level];
    }
}
