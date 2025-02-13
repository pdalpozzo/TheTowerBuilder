using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnOffToggleControl : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Image _on;
    [SerializeField] private Image _off;

    [SerializeField] private bool _isOn;
    [SerializeField] private bool _isUnlocked;

    public bool IsOn {  get { return _isOn; } }

    private void Start()
    {
        _isUnlocked = true;
    }

    private void Update()
    {
        _label.text = (_isOn) ? "ON" : "OFF";
        if (_on != null) _on.gameObject.SetActive(_isOn);
        if (_off != null) _off.gameObject.SetActive(!_isOn);
    }

    public void UpdateToggle()
    {
        if (!_isUnlocked) return;
        _isOn = _toggle.isOn;
    }

    public void SetToggle(bool value)
    {
        _isOn = value;
        _toggle.isOn = value;
    }

    public void SetUnlock(bool value)
    {
        _isUnlocked = value;
        SetToggle(false);
    }
}
