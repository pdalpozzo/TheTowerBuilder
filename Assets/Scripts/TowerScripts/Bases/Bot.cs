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
        EventManager.BotChanged(this);
    }
}
