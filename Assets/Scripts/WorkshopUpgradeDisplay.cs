using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public enum UnlockCategory { START, RANGE, MULTISHOT, RAPID_FIRE, BOUNCE_SHOT, SUPER_CRIT, REND, 
    DEFENSE, THORNS, LIFESTEAL, KNOCKBACK, ORBS, SHOCKWAVE, LANDMINE, DEATH_DEFY, WALL, 
    CASH, COIN, FREE_UPGRADE, INTEREST, PACKAGE, ENEMY_LEVEL_SKIP};

public class WorkshopUpgradeDisplay : MonoBehaviour
{
    [SerializeField] private Stat _stat;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _placeholderText;
    [SerializeField] private TMP_InputField _levelInput;
    [SerializeField] private OnOffToggleControl _toggle;
    [SerializeField] private UnlockCategory _category;

    private Color _defaultColour;
    private Color _maxLevelColour;
    private Color _disabledColor;
    private Color _enabledColor;

    public UnlockCategory Category {  get { return _category; } }

    private void Awake()
    {
        EventManager.OnAnyStatChange += StatChanged;
        EventManager.OnUpgradeForceReset += ForceUpgradeReset;
        EventManager.OnUpgradeForceUnlock += ForceUpgradeUnlock;
        EventManager.OnUpgradeForceMax += ForceUpgradeMax;

        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _maxLevelColour = RarityColors.GetMax();
        _disabledColor = RarityColors.GetInputDisable();
        _enabledColor = RarityColors.GetInputEnable();

        _nameText.text = _stat.Name + ":";

        _levelInput.characterLimit = CountMaxLevelCharcters(_stat.Upgrade.MaxLevel);
    }

    private void Start()
    {
        if (_category == UnlockCategory.START) 
        { 
            _toggle.SetToggle(true);
            _toggle.gameObject.SetActive(false);
        }

        UpgradeDisplayText();
        ToggleUpgrade();
    }

    private void ToggleUpgrade()
    {
        _stat.Upgrade.SetUnlock(_toggle.IsOn);
        _levelInput.enabled = _toggle.IsOn;
        _levelInput.GetComponent<Image>().color = _enabledColor;
        if (!_toggle.IsOn)
        {
            _levelInput.GetComponent<Image>().color = _disabledColor;
            _stat.Upgrade.NewLevel(0);
        }
        EventManager.WorkshopChange(_stat);
    }

    private void ForceUpgradeMax()
    {
        //if (!_toggle.IsOn) return;
        _stat.Upgrade.NewLevel(_stat.Upgrade.MaxLevel);
        ToggleUpgrade();
    }

    public void UnlockGroup()
    {
        _stat.Upgrade.SetUnlock(_toggle.IsOn);
        EventManager.UpgradeUnlock(_category, _toggle.IsOn);
    }

    public void ForceUpgradeUnlock()
    {
        _toggle.SetToggle(true);
        ToggleUpgrade();
    }

    public void ForceUpgradeReset()
    {
        _stat.Upgrade.NewLevel(_stat.Upgrade.BaseLevel);
        if (_category != UnlockCategory.START) _toggle.SetToggle(false);
        ToggleUpgrade();
    }

    public void UpgradeChange()
    {
        int input = 0;
        if (_levelInput.text != null) input = int.Parse(_levelInput.text);
        input = ValidateInput(input, _stat.Upgrade.MaxLevel);
        _stat.Upgrade.NewLevel(input);
        EventManager.WorkshopChange(_stat);
        //ToggleUpgrade();
    }

    private void StatChanged(Stat stat)
    {
        if (stat != _stat) return;
        UpgradeDisplayText();
    }

    private void UpgradeDisplayText()
    {
        string placeholder = (_toggle.IsOn) ? _stat.Upgrade.MaxLevel.ToString() : "";
        _valueText.text = _stat.ValueDisplay;
        _levelInput.text = (_stat.Upgrade.Level == 0) ? "" : _stat.Upgrade.Level.ToString();
        _placeholderText.text = placeholder;
        _valueText.color = (_stat.Upgrade.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _levelText.color = (_stat.Upgrade.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _nameText.color = (_stat.Upgrade.IsMaxLevel) ? _maxLevelColour : _defaultColour;
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

    private int ValidateInput(int input, int max)
    {
        if (input < 0) input = 0;
        if (input > max) input = max;
        return input;
    }
}
