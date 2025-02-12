using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    /*
     * module unique value
     * UW values []
     * cards []
     * perks []
     */
    [SerializeField] protected string _name;
    [SerializeField] protected Upgrade _upgrade;
    [SerializeField] protected Enhancement _enhancement;
    [SerializeField] protected Lab _lab;
    //[SerializeField] protected ModuleSlot _moduleSlot;
    [SerializeField] protected SubEffect _subEffect;
    [SerializeField] protected Effect _effect;
    [SerializeField] protected RelicManager _relicManager;

    [SerializeField] private bool _displayInCalculations = false;

    [SerializeField] private StringFormatType _formatType;
    [SerializeField] private int _decimalPlaces = 2;
    [SerializeField] private bool _noSymbol = false;

    public string Name { get { return _name; } }
    public Upgrade Upgrade { get { return _upgrade; } }
    public Enhancement Enhancement { get { return _enhancement; } }
    public Lab Lab { get { return _lab; } }
    //public ModuleSlot ModuleSlot { get { return _moduleSlot; } }
    public SubEffect SubEffect { get { return _subEffect; } }
    public Effect Effect { get { return _effect; } }
    public StringFormatType FormatType { get { return _formatType; } }
    public int DecimalPlaces { get { return _decimalPlaces; } }
    public bool NoSymbol { get { return _noSymbol; } }

    /*
     * === VALUE MEANINGS ===
     * value - permanant buffs (upgrade, enhancements, simple cards, module)
     * inRoundValue - buffs that are gained during a round (perks, complex cards (berserker))
     * conditionalValue - when all conditions are met (in SL, hit by Flame Bot, in GT)
     * 
     * The description is the value that has been formatted for display - DO NOT USE FOR CALCULATIONS
     */
    protected float _value = 0;
    protected float _inRoundValue = 0;
    protected float _conditionalValue = 0;
    protected string _valueDisplay = "";
    protected string _inRoundDisplay = "";
    protected string _conditionalDisplay = "";

    public float Value { get { return _value; } }
    public float InRoundValue { get { return _inRoundValue; } }
    public float ConditionalValue { get { return _conditionalValue; } }

    public string ValueDisplay { get { return _valueDisplay; } }
    public string InRoundDisplay { get { return _inRoundDisplay; } }
    public string ConditionalDisplay { get { return _conditionalDisplay; } }

    protected void CreateDescriptions()
    {
        _valueDisplay = StringFormating.Format(_value, _formatType, _decimalPlaces);
        _inRoundDisplay = StringFormating.Format(_inRoundValue, _formatType, _decimalPlaces);
        _conditionalDisplay = StringFormating.Format(_conditionalValue, _formatType, _decimalPlaces);
    }

    private void Awake()
    {
        UpdateValue();
    }

    protected void Start()
    {
        if (_upgrade != null || _enhancement != null) EventManager.OnWorkshopChange += UpdateValue;
        if (_lab != null) EventManager.OnAnyLabChange += UpdateValue;
        if (_relicManager != null) EventManager.OnRelicBonusChange += UpdateValue;
        //if (_moduleSlot != null) EventManager.OnModuleSlotChange += UpdateValue;
        if (_subEffect != null)
        {
            EventManager.OnSubEffectEquipChange += UpdateValue;
            EventManager.OnSubEffectRarityChange += UpdateValue;
            EventManager.OnModuleRarityChange += UpdateValue;
        }
        if (_effect != null) EventManager.OnAnyEffectChange += UpdateValue;
    }

    protected virtual void UpdateValue(Stat stat)
    {
        if (stat == this) UpdateValue();
    }

    private void UpdateValue(Lab lab)
    {
        if (lab == _lab) UpdateValue();
    }

    //private void UpdateValue(ModuleSlot slot)
    //private void UpdateValue(ModuleSlot slot)
    //{
    //    if (slot == _moduleSlot) UpdateValue();
    //}

    private void UpdateValue(SubEffect subEffect)
    {
        if (subEffect == _subEffect) UpdateValue();
    }

    private void UpdateValue(Effect effect)
    {
        if (effect == _effect) UpdateValue();
    }

    protected virtual void UpdateValue()
    {

    }

}
