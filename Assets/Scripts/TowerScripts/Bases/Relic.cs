using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RelicType { COINS, CRIT_FACTOR, DAMAGE, DAMAGE_PER_METER, DEFENSE_ABSOLUTE, HEALTH, LAB_SPEED };

public class Relic : MonoBehaviour
{

    [SerializeField] private RelicScriptableObject _data;
    [SerializeField] private bool _isOn = false;
    private string _tooltipMessage;

    public string Name { get { return _data.Name; } }
    public string TooltipMessage { get { return _tooltipMessage; } }
    public Sprite Icon { get { return _data.Icon; } }
    public Sprite Faded { get { return _data.Faded; } }
    public bool IsOn { get { return _isOn; } }
    public RelicType Type { get { return _data.RelicType; } }
    public Rarity Rarity { get { return _data.Rarity; } }
    public float Value { get { return _data.Value; } }

    private void Awake()
    {
        // wrong
        //AssignValue();
        CreateTooltipMessage();
    }

    private void CreateTooltipMessage()
    {
        string message = string.Empty;
        switch (Type)
        {
            case RelicType.LAB_SPEED:
                message = "Increase lab speed by ";
                break;
            case RelicType.DAMAGE:
                message = "Increase tower damage by ";
                break;
            case RelicType.DAMAGE_PER_METER:
                message = "Increase damage / meter by ";
                break;
            case RelicType.CRIT_FACTOR:
                message = "Increase critical factor by ";
                break;
            case RelicType.HEALTH:
                message = "Increase tower health by ";
                break;
            case RelicType.DEFENSE_ABSOLUTE:
                message = "Increase defense absolute by ";
                break;
            case RelicType.COINS:
                message = "Increase coins earned by ";
                break;
        }
        string value = StringFormating.Format(_data.Value, StringFormatType.PERCENT, 0);
        _tooltipMessage = message + value;
    }

    public void ChangeActive(bool isOn)
    {
        _isOn = isOn;
        Trigger_RelicStatusChanged();
    }

    // trigger when the relic is turn on or off
    private void Trigger_RelicStatusChanged()
    {
        EventManager.RelicStatusChange();
    }

    //private void AssignValue()
    //{
    //    switch (Rarity)
    //    {
    //        case Rarity.RARE:
    //            _value = 0.02f; // 2%
    //            break;
    //        case Rarity.EPIC:
    //            _value = 0.05f; // 5%
    //            break;
    //        default:
    //            _value = 0.1f; // 10%
    //            break;
    //    }
    //}

    /*              |       types                                                |
     * rarity       | coins | crit | damage | d/m | def abs | health | lab speed |
     * --------------------------------------------------------------------------|
     * rare         |   2   |   2  |    2   |   2 |     2   |    2   |      2    |       
     * epic         |   5   |   5  |    5   |   5 |     5   |    5   |      5    |      
     * legenedary   |  10   |  10  |   10   |  10 |    10   |   10   |     10    |       
     * 
     */
}
