using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModuleSlot : MonoBehaviour
{
    [SerializeField] private ModuleSlotScriptableObject _data;
    [SerializeField] private int _currentLevel = 1;
    [SerializeField] private float _currentValue;
    [SerializeField] private Rarity _currentRarity = Rarity.COMMON;
    //[SerializeField] private ModuleType _type;
    [SerializeField] private float _valueIncrement;
    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;
    [SerializeField] private string _bonusText;
    private int[] _levelCaps = {0, 40, 100, 140, 160, 200};
    private string _currentDescription = "";

    [SerializeField] private List<Module> _modules;
    [SerializeField] private List<SubEffect> _subEffects;

    [SerializeField] private Module _equippedModule;
    private string _uniqueDescription = "";

    [SerializeField] private List<SubEffect> _equippedSubEffects;
    [SerializeField] private int _slotsUnlocked = 0;

    public string Name { get { return _data.Name; } }
    public string ModuleName { get { return _equippedModule.Name; } }
    public string Bonus { get { return _bonusText; } }
    public int MaxLevel { get { return _levelCaps[_levelCaps.Length - 1]; } }
    public int BaseLevel { get { return _levelCaps[0]; } }
    public int Level { get { return _currentLevel; } }
    public int SlotUnlocked { get { return _slotsUnlocked; } }
    public bool IsNone { get { return _equippedModule.IsNone; } }
    public bool IsMaxLevel { get { return (_currentLevel == MaxLevel); } }
    public StringFormatType Format { get { return _data.FormatType; } }
    public int DecimalPlaces { get { return _data.DecimalPlaces; } }
    public ModuleType ModuleType { get { return _data.ModuleType; } }
    public Rarity ModuleBaseRarity { get { return _equippedModule.BaseRarity; } }
    public Rarity Rarity { get { return _currentRarity; } }
    public List<Module> ModuleList { get { return _modules; } }
    public List<SubEffect> SubEffectsList { get { return _subEffects; } }
    public Module EquippedModule { get { return _equippedModule; } }
    public List<SubEffect> EquippedSubEffects { get { return _equippedSubEffects; } }
    public string Description { get { return CreateDescription(); } }

    private void Awake()
    {
        EventManager.OnSubEffectChange += EquipSubEffect;    // triggered by sub effect visual control
        if (_equippedModule == null) ModuleSelection(0);
    }

    private void Start()
    {
        Trigger_OnSubEffectLimitChange();
        //Trigger_OnModuleRarityChange();
    }

    public float GetValue()
    {
        if (IsNone) return 0;
        return _data.GetValue(_currentLevel);
    }

    public void NewLevel(int level)
    {
        ChangeLevel(level);
        // check sub effect list to remove over assigned slots
    }

    public void ChangeRarity(Rarity rarity)
    {
        if (rarity < ModuleBaseRarity) rarity = ModuleBaseRarity;
        if (IsNone) rarity = Rarity.COMMON;
        _currentRarity = rarity;
        SubEffectRarityChange(rarity);

        //Trigger_OnModuleRarityChange();
        //Trigger_OnSubEffectLimitChange();
    }

    public void ModuleSelection(int index)
    {
        if (_equippedModule == _modules[index]) return;

        for (int i = 0; i < _modules.Count; i++)
        {
            _modules[i].ChangeEquipped(false);
        }
        _modules[index].ChangeEquipped(true);
        _equippedModule = _modules[index];

        ChangeRarity(_currentRarity);
    }

    private void Trigger_OnModuleRarityChange()
    {
        EventManager.ModuleSlotRarityChange();
    }

    private void EquipSubEffect(SubEffect subEffect)
    {
        if (_data.ModuleType != subEffect.ModuleType) return;

        if (subEffect.IsEquipped)
        {
            //unequip if already equipped
            subEffect.SetEquipped(false);
            _equippedSubEffects.Remove(subEffect);
            Trigger_OnSubEffectLimitChange();
            return;
        } 

        if (_equippedSubEffects.Count >= _slotsUnlocked)
        {   
            // check slots unlocked before equipping
            //CheckSlotLimit();
            return;
        } 

        // free slots to equip sub effect
        subEffect.SetEquipped(true);
        _equippedSubEffects.Add(subEffect);
        Trigger_OnSubEffectLimitChange();
    }

    //private void UnlockSubEffects()
    //{
    //    foreach (var effect in _subEffects)
    //    {
    //        //if (!effect.IsEquipped) effect.setlock
    //    }
    //}

    private void Trigger_OnSubEffectLimitChange()
    {
        CheckSlotLimit();
        bool isFull = (_slotsUnlocked == _equippedSubEffects.Count);
        EventManager.SubEffectLimitChange(_data.ModuleType, isFull);
    }

    private void ChangeLevel(int level)
    {
        if (_equippedModule.IsNone) 
        { 
            _slotsUnlocked = 0;
            Trigger_OnSubEffectLimitChange();
            return; 
        }

        if (level > MaxLevel) level = MaxLevel;       // check new level is not above max level
        if (level < BaseLevel) level = BaseLevel;     // check new level is not below base level
        _currentLevel = level;

        for (int i = _levelCaps.Length - 2; i >= 0; i--)
        {
            if (_currentLevel > _levelCaps[i])
            {
                _slotsUnlocked = 2 + i;
                //CheckSlotLimit();
                Trigger_OnSubEffectLimitChange();
                return;
            }
        }
        Trigger_OnSubEffectLimitChange();
    }

    private void CheckSlotLimit()
    {
        if (_equippedSubEffects.Count <= _slotsUnlocked) return;
        for (int i = _equippedSubEffects.Count - 1; i >= 0; i--)
        {
            if (i >= _slotsUnlocked) 
            {
                _equippedSubEffects[i].SetEquipped(false);
                _equippedSubEffects.RemoveAt(i); 
            }
        }
        //Trigger_OnSubEffectLimitChange();
    }

    private void SubEffectRarityChange(Rarity rarity)
    {
        // lower rarity of sub effects to match module rarity
        foreach (var effect in _subEffects)
        {
            effect.SetModuleRarity(rarity);
            if (rarity > effect.Rarity) continue;       // if rarity is higher than sub effect current rarity
            //if (rarity < effect.BaseRarity) continue;   // if rarity is lower than sub effect base rarity
            effect.ChangeRarity(rarity);
        }

        // check that sub effect is not equipped if module rarity is too low
        for (int i = _equippedSubEffects.Count - 1; i >= 0; i--)
        {
            if ( _equippedModule.IsNone || _equippedSubEffects[i].BaseRarity > rarity)
            {
                _equippedSubEffects[i].SetEquipped(false);
                _equippedSubEffects.RemoveAt(i);
            }
        }
        Trigger_OnSubEffectLimitChange();
    }

    private string CreateDescription()
    {
        return _equippedModule.CreateDescription(_currentRarity);
    }
}
