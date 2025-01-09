using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ModuleVisualControl : MonoBehaviour
{
    [SerializeField] private ModuleSlot _moduleSlot;
    [SerializeField] private TextMeshProUGUI _slotTypeText;
    [SerializeField] private TextMeshProUGUI _moduleNameText;
    [SerializeField] private TextMeshProUGUI _bonusValueText;
    [SerializeField] private TextMeshProUGUI _bonusNameText;
    [SerializeField] private TextMeshProUGUI _uniqueText;
    [SerializeField] private TextMeshProUGUI _rarityText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _levelLabelText;
    [SerializeField] private TextMeshProUGUI _subEffectsUnlockText;
    [SerializeField] private TMP_InputField _levelInput;
    [SerializeField] private Image _moduleBorder;
    [SerializeField] private Image _rarityBorder;
    [SerializeField] private GameObject _fade;
    [SerializeField] private Button _rarityDown;
    [SerializeField] private Button _rarityUp;

    [SerializeField] private ModuleIconControl[] _icons;

    private Color _defaultColour;
    private Color _maxLevelColour;

    private void Awake()
    {
        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _maxLevelColour = RarityColors.GetMax();

        _slotTypeText.text = _moduleSlot.Name;
        _levelInput.characterLimit = CountMaxLevelCharcters(_moduleSlot.MaxLevel);
        List<Module> modules = _moduleSlot.ModuleList;

        for (int i = 0; i < modules.Count; i++)
        {
            _icons[i].SetModule(modules[i]);
        }
        _levelInput.placeholder.GetComponent<TextMeshProUGUI>().text = _moduleSlot.MaxLevel.ToString();
    }

    private void Start()
    {
        UpdateDisplay();
    }

    public void LevelChange()
    {
        int input = 0;
        if (_levelInput.text != null) input = int.Parse(_levelInput.text);
        input = ValidateInput(input, _moduleSlot.MaxLevel);
        _moduleSlot.NewLevel(input);
        UpdateDisplay();
    }

    public void RarityUp()
    {
        Rarity newRarity = _moduleSlot.Rarity + 1;
        int enumCount = Enum.GetNames(typeof(Rarity)).Length;
        if ((int)newRarity >= enumCount) newRarity = Rarity.ANCESTRAL;

        _moduleSlot.ChangeRarity(newRarity);
        UpdateDisplay();
    }

    public void RarityDown()
    {
        Rarity newRarity = _moduleSlot.Rarity - 1;
        if (newRarity < Rarity.COMMON) newRarity = Rarity.COMMON;

        _moduleSlot.ChangeRarity(newRarity);
        UpdateDisplay();
    }

    public void ModuleSelection(int index)
    {
        _moduleSlot.ModuleSelection(index);
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

    // could be in update
    private void UpdateDisplay()
    {
        foreach (var module in _icons)
        {
            module.UpdateDisplay();
        }
        _moduleNameText.color = RarityColors.GetColor(_moduleSlot.Rarity);
        _rarityText.color = RarityColors.GetColor(_moduleSlot.Rarity);
        _rarityBorder.color = RarityColors.GetColor(_moduleSlot.Rarity);
        _moduleBorder.color = RarityColors.GetColor(_moduleSlot.Rarity);

        _moduleNameText.text = _moduleSlot.EquippedModule.Name;
        _rarityText.text = Enum.GetName(typeof(Rarity), _moduleSlot.Rarity);

        _rarityUp.interactable = (_moduleSlot.Rarity != Rarity.ANCESTRAL);
        _rarityDown.interactable = (_moduleSlot.Rarity != _moduleSlot.ModuleBaseRarity);

        _bonusValueText.text = GetStringFormat(_moduleSlot.GetValue(), _moduleSlot.Format, _moduleSlot.DecimalPlaces);
        _bonusNameText.text = _moduleSlot.Bonus;

        _fade.SetActive(_moduleSlot.EquippedModule.IsNone);

        _levelInput.characterLimit = CountMaxLevelCharcters(_moduleSlot.MaxLevel);
        _levelInput.text = (_moduleSlot.Level == 0) ? "" : _moduleSlot.Level.ToString();
        _levelLabelText.color = (_moduleSlot.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _levelText.color = (_moduleSlot.IsMaxLevel) ? _maxLevelColour : _defaultColour;

        _uniqueText.text = _moduleSlot.Description;
        _subEffectsUnlockText.text = _moduleSlot.SlotUnlocked.ToString();
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
