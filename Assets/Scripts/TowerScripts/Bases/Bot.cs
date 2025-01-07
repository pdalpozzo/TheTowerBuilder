using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private string _botName;
    [TextArea(3, 10)][SerializeField] private string tooltipMessage;
    [SerializeField] private bool _isOn = false;
    [SerializeField] private Effect _one;
    [SerializeField] private Effect _two;
    [SerializeField] private Effect _three;
    [SerializeField] private Effect _four;
    [SerializeField] private Sprite _icon;

    public string Name { get { return _botName; } }
    public string TooltipMessage { get { return tooltipMessage; } }
    public bool IsOn { get { return _isOn; } }
    public Sprite Icon { get { return _icon; } }

    public void ChangeActive(bool isOn)
    {
        _isOn = isOn;
    }

    public float GetEffectValue(EffectSlot effectSlot)
    {
        return SelectEffectSlot(effectSlot).Value;
    }

    public string GetEffectValueString(EffectSlot effectSlot)
    {
        return SelectEffectSlot(effectSlot).ValueString();
    }

    public string GetEffectName(EffectSlot effectSlot)
    {
        return SelectEffectSlot(effectSlot).Name;
    }

    public int GetEffectLevel(EffectSlot effectSlot)
    {
        return SelectEffectSlot(effectSlot).Level;
    }

    public int GetEffectMaxLevel(EffectSlot effectSlot)
    {
        return SelectEffectSlot(effectSlot).MaxLevel;
    }

    public int GetEffectBaseLevel(EffectSlot effectSlot)
    {
        return SelectEffectSlot(effectSlot).BaseLevel;
    }

    public bool GetEffectIsMax(EffectSlot effectSlot)
    {
        return SelectEffectSlot(effectSlot).IsMaxLevel;
    }

    public void ChangeEffectLevel(EffectSlot effectSlot, int levelChange)
    {
        SelectEffectSlot(effectSlot).SetLevel(levelChange);
    }

    private Effect SelectEffectSlot(EffectSlot effectSlot)
    {
        return effectSlot switch
        {
            EffectSlot.ONE => _one,
            EffectSlot.TWO => _two,
            EffectSlot.THREE => _three,
            EffectSlot.FOUR => _four,
            _ => _one,
        };
    }

}
