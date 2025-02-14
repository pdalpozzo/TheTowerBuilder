using UnityEngine;

public class Pack : MonoBehaviour
{
    [SerializeField] private string packName;
    [SerializeField] private bool _isOn = false;
    [SerializeField] private float _value;

    public bool IsOn { get { return _isOn; } set { _isOn = value; } }
    public float Value { get { return _value; } }
}
