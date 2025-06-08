using UnityEngine;

public enum CalculationType : byte { BASE, IN_ROUND, CONDITIONAL }

public abstract class Modifier : MonoBehaviour
{
    [SerializeField] protected CalculationType _type = CalculationType.BASE;
    [SerializeField] protected bool _isInUse = false;

    public bool IsInUse { get { return _isInUse; } }
    public CalculationType Type { get { return _type; } }

    public abstract float Value();
}
