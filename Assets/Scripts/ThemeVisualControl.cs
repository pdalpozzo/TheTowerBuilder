using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeVisualControl : MonoBehaviour
{
    [SerializeField] private Theme _theme;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Toggle _mainToggle;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _fade;

    private void Awake()
    {
        EventManager.OnThemeStatusChange += UpdateVisual;   // triggered by theme
    }

    // Start is called before the first frame update
    private void Start()
    {
        _nameText.text = _theme.Name;
        _icon.sprite = _theme.Icon;
        UpdateVisual();
    }

    public void ToggleTheme()
    {
        _theme.ChangeActive(_mainToggle.isOn);
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (_mainToggle.isOn != _theme.IsOn) _mainToggle.isOn = _theme.IsOn;
        _fade.gameObject.SetActive(!_mainToggle.isOn);
    }
}
