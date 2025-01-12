using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMastery : MonoBehaviour
{
    [SerializeField] private CardMasteryScriptableObject _data;
    [SerializeField] private Lab _lab;

    private bool _enabled = false;

    public string Name { get { return _data.Name; } }
    public string Description { get { return _data.Description; } }
    public bool Enabled { get { return _enabled; } }
    public Lab Lab { get { return _lab; } }

    public void SetEnable(bool enabled)
    {
        _enabled = enabled;
    }
}
