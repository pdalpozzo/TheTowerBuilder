using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class LabVisualControl : MonoBehaviour
{
    [SerializeField] private Lab _lab;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private Button _reset;
    [SerializeField] private Button _max;

    private Color _defaultColour;
    private Color _maxLevelColour;

    private void Awake()
    {
        EventManager.OnAnyLabChange += UpdateValue;
    }

    private void Start()
    {
        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _maxLevelColour = RarityColors.GetMax();

        _nameText.text = _lab.Name;
        _input.characterLimit = CountMaxLevelCharcters(_lab.MaxLevel);
        UpdateDisplay();
    }

    public void LevelChange()
    {
        int input = 0;
        if (_input.text != null) input = int.Parse(_input.text);
        input = ValidateInput(input, _lab.MaxLevel);
        _lab.NewLevel(input);
        UpdateDisplay();
    }

    public void ForceMaxLevel()
    {
        _lab.NewLevel(_lab.MaxLevel);
        UpdateDisplay();
    }

    public void ForceReset()
    {
        _lab.NewLevel(_lab.BaseLevel);
        UpdateDisplay();
    }

    private int CountMaxLevelCharcters(int max)
    {
        int count = 0;
        while (max != 0)
        {
            max = max / 10;
            count++;
        }
        return count;
    }

    private void UpdateValue(Lab lab)
    {
        if (lab == _lab) UpdateDisplay();
    }

    // could be in update
    private void UpdateDisplay()
    {
        _valueText.text = GetStringFormat(_lab.Value, _lab.Format, _lab.DecimalPlaces);
        _input.placeholder.GetComponent<TextMeshProUGUI>().text = _lab.MaxLevel.ToString();
        _input.text = (_lab.Level == 0) ? "" : _lab.Level.ToString();
        // change text colour if maxed
        _nameText.color = (_lab.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _valueText.color = (_lab.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _levelText.color = (_lab.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        if (_reset != null) _reset.interactable = (_lab.BaseLevel != _lab.Level);
        if (_max != null) _max.interactable = (!_lab.IsMaxLevel);
    }

    private string GetStringFormat(float value, StringFormatType format, int decimalPlaces)
    {
        return StringFormating.Format(value, format, decimalPlaces);
    }

    private int ValidateInput(int input, int max)
    {
        if (input < 0) input = 0;
        if (input > max) input = max;
        return input;
    }

}
