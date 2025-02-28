using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public enum IncrementType { INCREMENTAL, ALL_VALUES, FORMULA }; //, CASCADE };

[CreateAssetMenu (fileName ="Upgrade", menuName = "ScriptableObjects/Upgrade")]
public class UpgradeScriptableObject : ScriptableObject
{
    [SerializeField] private float _baseValue = 0;
    [SerializeField] private float _valueIncrement;
    [SerializeField] private int _maxLevel = 99;
    [SerializeField] private int _baseLevel = 0;    // does not need to be serialized

    [SerializeField] private IncrementType _incrementType;
    //[SerializeField] private int[] _brackets;
    [SerializeField] private float[] _valueIncrements;

    private enum WorkshopFormula { DAMAGE, HEALTH, HEALTH_REGEN, DEFENSE_ABSOLUTE};
    [SerializeField] private WorkshopFormula _workshopFormula;

    public int BaseLevel { get { return _baseLevel; } }
    public int MaxLevel { get { return _maxLevel; } }

    public float GetValue(int level)
    {
        switch(_incrementType)
        {
            case IncrementType.INCREMENTAL:
                return IncrementalValue(level);
            case IncrementType.ALL_VALUES:
                return AllValues(level);
            case IncrementType.FORMULA:
                return FormulaValues(level);
            default:
                return IncrementalValue(level);
        }
    }

    private float IncrementalValue(int level)
    {
        return (_baseValue + (_valueIncrement * level));
    }

    //private float BracketValue(int level)
    //{
    //    float value = _baseValue;
    //    int bracket = 0;
    //    for (int i = 1; i <= level; i++)
    //    {
    //        if (i > _brackets[bracket]) bracket++;
    //        value += _valueIncrements[bracket];
    //    }
    //    return value;
    //}

    private float AllValues(int level)
    {
        if (_valueIncrements.Length < level) return 0;
        return _valueIncrements[level];
    }

    //private float CascadeValue(int level)
    //{
    //    if (level == 0) return 0;
    //    if (level == 1) return _baseValue;

    //    float value = _baseValue;
    //    float cascade = _baseValue;
    //    int bracket = 0;

    //    for (int i = 2; i <= level; i++)
    //    {
    //        if (i > _brackets[bracket]) bracket++;
    //        //value += valueIncrements[bracket];
    //        cascade = cascade - _valueIncrements[bracket];
    //        value += cascade;
    //    }
    //    return value;
    //}

    private float FormulaValues(int level)
    {
        float value = 0;
        switch (_workshopFormula)
        {
            case WorkshopFormula.DAMAGE:
                value = DamageValue(level);
                break;
            case WorkshopFormula.HEALTH:
                value = HealthValue(level);
                break;
            case WorkshopFormula.HEALTH_REGEN:
                value = HealthRegenValue(level);
                break;
            case WorkshopFormula.DEFENSE_ABSOLUTE:
                value = DefenseAbsoluteValue(level);
                break;
            default:
                value = 0;
                break;
        }
        return value;
    }

    private float HealthValue(int level)
    {
        if (level == 0) return _baseValue;

        float value;
        float multiplier = 1;

        // value = (0.077 * (x-1)^2.72 + 5(x-1) + 10) * multiplier
        value = .077f * Mathf.Pow((level - 1), 2.72f) + 5 * (level - 1) + 10;

        // multiplier brackets
        if (level >= 130) multiplier = 1.03f;
        else if (level >= 100) multiplier = 1.02f;
        else if (level >= 75) multiplier = 1.01f;
        else if (level >= 30 && level < 50) multiplier = .985f;
        else if (level >= 15) multiplier = .975f;
        else if (level >= 3) multiplier = .98f;

        // multiplier *= (x > 5000)? 1.0015^x-5000 : 1
        if (level > 5000) multiplier *= Mathf.Pow(1.0015f, level - 5000);

        return value * multiplier;
    }

    private float HealthRegenValue(int level)
    {
        if (level == 0) return _baseValue;

        float value;
        float multiplier = 1;

        // value = .0045 * (x-1)^2.39 + .004(x-1) + .04x
        value = .0045f * Mathf.Pow((level - 1), 2.39f) + .004f * (level - 1) + level * .04f;

        // value increases at level thresholds
        if (level >= 250) value += .020f * Mathf.Pow(level - 249, 2.25f);
        if (level >= 500) value += .020f * Mathf.Pow(level - 499, 2.85f);

        // multiplier *= (x > 5000)? 1.0024^x-5000 : 1
        if (level > 5000) multiplier *= Mathf.Pow(1.0024f, level - 5000);

        return value * multiplier;
    }

    private float DefenseAbsoluteValue(int level)
    {
        if (level == 0) return _baseValue;

        float value;
        float multiplier = 1;

        // value = (0.0049 * (x-1)^2.63 + .5(x-1) + .5x) * multiplier
        value = .0049f * Mathf.Pow((level - 1), 2.63f) + .5f * (level - 1) + level * .5f;

        // value increases at level thresholds
        if (level >= 300) value += .08f * Mathf.Pow((level - 299), 2.18f);
        if (level >= 1300) value += .10f * Mathf.Pow((level - 1299), 2.20f);
        if (level >= 1800) value += .12f * Mathf.Pow((level - 1799), 2.27f);
        if (level >= 2500) value += .14f * Mathf.Pow((level - 2499), 2.42f);

        // multiplier brackets
        if (level >= 110) multiplier = 1.06f;
        else if (level >= 90) multiplier = 1.05f;
        else if (level >= 70) multiplier = 1.04f;
        else if (level >= 50) multiplier = 1.03f;
        else if (level >= 30) multiplier = 1.02f;
        else if (level >= 15) multiplier = 1.01f;

        return value * multiplier;
    }

    private float DamageValue(int level)
    {
        if (level == 0) return _baseValue;

        float value;
        float multiplier = 1;

        // value = (0.0015 * (x-1)^2.43 + 2(x-1)) * multiplier
        value = 0.077f * Mathf.Pow(level, 2) + 2.8f * level + 3;

        // value increases at level thresholds
        if (level >= 1000) value += 0.08f * Mathf.Pow(level - 999, 2.1f);
        if (level >= 1500) value += 0.09f * Mathf.Pow(level - 1499, 2.12f);
        if (level >= 2000) value += 0.1f * Mathf.Pow(level - 1999, 2.18f);
        if (level >= 2500) value += 0.1f * Mathf.Pow(level - 2499, 2.25f);
        if (level >= 3000) value += 0.15f * Mathf.Pow(level - 2999, 2.3f);
        if (level >= 3500) value += 0.2f * Mathf.Pow(level - 3499, 2.33f);
        if (level >= 4000) value += 0.2f * Mathf.Pow(level - 3999, 2.34f);

        return value * multiplier;
    }
}
