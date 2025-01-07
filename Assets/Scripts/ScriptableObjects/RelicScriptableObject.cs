using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Relic", menuName = "ScriptableObjects/Relic")]
public class RelicScriptableObject : ScriptableObject
{
    [SerializeField] private string _relicName;
    [SerializeField] private Rarity _rarity = Rarity.RARE;
    [SerializeField] private RelicType _relicType;
    [SerializeField] private float _value;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Sprite _faded;

    public string Name { get { return _relicName; } }
    public Rarity Rarity { get { return _rarity; } }
    public RelicType RelicType { get { return _relicType; } }
    public float Value { get { return _value; } }
    public Sprite Icon { get { return _icon; } }
    public Sprite Faded { get { return _faded; } }
}
