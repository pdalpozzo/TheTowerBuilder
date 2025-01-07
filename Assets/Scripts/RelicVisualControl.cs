using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicVisualControl : MonoBehaviour
{
    [SerializeField] private Relic _relic;
    [SerializeField] private Tooltip _tooltip;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _faded;
    [SerializeField] private Toggle _mainToggle;

    private void Awake()
    {
        EventManager.OnRelicStatusChange += UpdateVisual;   // triggered by relic
    }

    private void Start()
    {
        _icon.sprite = _relic.Icon;
        _faded.sprite = _relic.Faded;

        _tooltip.SetMessage(_relic.TooltipMessage, _relic.Name);
        UpdateVisual();
    }

    public void ToggleRelic()
    {
        _relic.ChangeActive(_mainToggle.isOn);
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (_mainToggle.isOn != _relic.IsOn) _mainToggle.isOn = _relic.IsOn;
        _icon.gameObject.SetActive(_mainToggle.isOn);
    }
}
