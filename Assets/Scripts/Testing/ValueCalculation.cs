using UnityEngine;

public abstract class ValueCalculation : ScriptableObject
{
    public int MaxLevel { get { return GetMaxLevel(); } }

    public abstract float Value(int level);
    public abstract int GetMaxLevel();
}