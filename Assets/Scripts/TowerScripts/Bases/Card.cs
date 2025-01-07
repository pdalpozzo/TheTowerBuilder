using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Card : MonoBehaviour
{
    [SerializeField] private CardScriptableObject _data;
    [SerializeField] private int _currentLevel = 0;
    [SerializeField] private bool _isEquipped = false;
    [SerializeField] private int _slotNumber = 0;

    public string Name { get { return _data.Name; } }
    //public string TooltipMessage { get { return _data.Tooltip; } }
    public float Value { get { return _data.Value(_currentLevel); } }
    public float BaseValue { get { return _data.Value(0); } }
    public int Level { get { return _currentLevel; } }
    public int Slot { get { return _slotNumber; } }
    public bool IsEquipped { get { return _isEquipped; } }
    public Rarity Rarity { get { return _data.Rarity; } }
    public Sprite Icon { get { return _data.Icon; } }
    public int MaxLevel { get { return _data.MaxLevel; } }
    public int BaseLevel { get { return _data.BaseLevel; } }
    public string ValueDisplay { get { return _data.ValueDisplay(_currentLevel); } }
    public string Description { get { return CreateDescription(); } }

    public void NewLevel(int level)
    {
        ChangeLevel(level);
        EventManager.CardChanged(this);
    }

    public void AssignSlot(int slot)
    {
        _isEquipped = slot != 0;
        _slotNumber = slot;
        EventManager.CardChanged(this);
    }

    private void ChangeLevel(int level)
    {
        _currentLevel = level;
    }

    private string CreateDescription()
    {
        string description = string.Empty;
        description += _data.Prefix;
        description += _data.ValueDisplay(_currentLevel);
        description += _data.Suffix;

        return description;
    }
}
