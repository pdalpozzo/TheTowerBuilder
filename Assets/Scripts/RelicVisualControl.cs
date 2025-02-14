using TMPro;
using UnityEngine;

public class RelicVisualControl : MonoBehaviour
{
    [SerializeField] private Relic _relic;
    [SerializeField] private Tooltip _tooltip;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private OnOffToggleControl _toggle;

    private void Start()
    {
        if (_nameText != null) _nameText.text = _relic.Name;
        _tooltip.SetMessage(_relic.TooltipMessage, _relic.Name);
    }

    public void ToggleRelic()
    {
        _relic.ChangeActive(_toggle.IsOn);
    }

    private void Update()
    {
        if (_toggle.IsOn != _relic.IsOn) _toggle.SetToggle(_relic.IsOn);
    }
}
