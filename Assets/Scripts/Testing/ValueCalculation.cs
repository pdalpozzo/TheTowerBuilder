using UnityEngine;

public abstract class ValueCalculation : ScriptableObject
{
    //public float BaseValue { get { return Value(0); } }
    public int MaxLevel { get { return GetMaxLevel(); } }

    public abstract float Value(int level);
    public abstract int GetMaxLevel();
}