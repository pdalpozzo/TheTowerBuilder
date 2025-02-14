using UnityEngine;

public enum RelicType { DAMAGE, ATTACK_SPEED, CRIT_CHANCE, CRIT_FACTOR, RANGE, DAMAGE_PER_METER, SUPER_CRIT_CHANCE, SUPER_CRIT_MULTI,
    HEALTH, HEALTH_REGEN, DEFENSE_ABSOLUTE, DEATH_DEFY, WALL_HEALTH, WALL_REBUILD,
    COINS, FREE_ATTACK_UPGRADE, FREE_DEFENSE_UPGRADE, FREE_UTILITY_UPGRADE, RECOVERY_AMOUNT, MAX_RECOVERY, PACKAGE_CHANCE, ENEMY_ATTACK_LEVEL_SKIP, ENEMY_HEALTH_LEVEL_SKIP,
    LAB_SPEED, BOT_RANGE, ULTIMATE_DAMAGE
};

public class Relic : MonoBehaviour
{
    [SerializeField] private RelicScriptableObject _data;
    [SerializeField] private bool _isOn = false;
    private string _tooltipMessage;

    public string Name { get { return _data.Name; } }
    public string TooltipMessage { get { return _tooltipMessage; } }
    public bool IsOn { get { return _isOn; } }
    public RelicType Type { get { return _data.RelicType; } }
    public float Value { get { return _data.Value; } }

    private void Awake()
    {
        CreateTooltipMessage();
    }

    private void CreateTooltipMessage()
    {
        string message = MessageString();
        string value = GetStringFormat(_data.Value, _data.FormatType, _data.DecimalPlaces);
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

    private string GetStringFormat(float value, StringFormatType format, int decimalPlaces)
    {
        return StringFormating.Format(value, format, decimalPlaces);
    }

    private string MessageString()
    {
        string message = string.Empty;
        switch (_data.RelicType)
        {
            case RelicType.DAMAGE:
                message = "Increase tower damage by ";
                break;
            case RelicType.ATTACK_SPEED:
                message = "Increase attack speed by ";
                break;
            case RelicType.CRIT_CHANCE:
                message = "Increase critical chance by ";
                break;
            case RelicType.CRIT_FACTOR:
                message = "Increase critical factor by ";
                break;
            case RelicType.RANGE:
                message = "Increase tower range by ";
                break;
            case RelicType.DAMAGE_PER_METER:
                message = "Increase damage / meter by ";
                break;
            case RelicType.SUPER_CRIT_CHANCE:
                message = "Increase super critical chance by ";
                break;
            case RelicType.SUPER_CRIT_MULTI:
                message = "Increase super critical factor by ";
                break;
            case RelicType.HEALTH:
                message = "Increase tower health by ";
                break;
            case RelicType.HEALTH_REGEN:
                message = "Increase health regen by ";
                break;
            case RelicType.DEFENSE_ABSOLUTE:
                message = "Increase defense absolute by ";
                break;
            case RelicType.DEATH_DEFY:
                message = "Increase death defy by ";
                break;
            case RelicType.WALL_HEALTH:
                message = "Increase wall health by ";
                break;
            case RelicType.WALL_REBUILD:
                message = "Reduce wall rebuild time by ";
                break;
            case RelicType.COINS:
                message = "Increase coins earned by ";
                break;
            case RelicType.FREE_ATTACK_UPGRADE:
                message = "Increase free attack upgrade by ";
                break;
            case RelicType.FREE_DEFENSE_UPGRADE:
                message = "Increase free defense upgrade by ";
                break;
            case RelicType.FREE_UTILITY_UPGRADE:
                message = "Increase free utility upgrade by ";
                break;
            case RelicType.RECOVERY_AMOUNT:
                message = "Increase recovery amount by ";
                break;
            case RelicType.MAX_RECOVERY:
                message = "Increase max recovery by ";
                break;
            case RelicType.PACKAGE_CHANCE:
                message = "Increase package chance by ";
                break;
            case RelicType.ENEMY_ATTACK_LEVEL_SKIP:
                message = "Increase enemy attack level skip by ";
                break;
            case RelicType.ENEMY_HEALTH_LEVEL_SKIP:
                message = "Increase enemy health level skip by ";
                break;
            case RelicType.LAB_SPEED:
                message = "Increase lab speed by ";
                break;
            case RelicType.BOT_RANGE:
                message = "Increase bot range by ";
                break;
            case RelicType.ULTIMATE_DAMAGE:
                message = "Increase ultimate damage by ";
                break;
            default:
                message = "Not Implemented Yet.";
                break;
        }
        return message;
    }
}
