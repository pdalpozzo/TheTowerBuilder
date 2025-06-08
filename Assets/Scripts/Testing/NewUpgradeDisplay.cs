using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewUpgradeDisplay : MonoBehaviour
{
    [SerializeField] private ModifiedStat _modStat; // one to display

    [SerializeField] private TextMeshProUGUI _nameText;         // stat name
    [SerializeField] private TextMeshProUGUI _valueText;        // modified stat value
    [SerializeField] private TextMeshProUGUI _levelText;        // stat level
    [SerializeField] private TextMeshProUGUI _placeholderText;  // stat max level
    [SerializeField] private TMP_InputField _levelInput;        // stat current level
    [SerializeField] private OnOffToggleControl _toggle;        // stat in use toggle
                                                                //[SerializeField] private UnlockCategory _category;

    private NewStat _stat;      // one to edit
    private Color _defaultColour;
    private Color _maxLevelColour;
    private Color _disabledColor;
    private Color _enabledColor;

    private void Awake()
    {
        _stat = (NewStat)_modStat.BaseStat;

        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _maxLevelColour = RarityColors.GetMax();
        _disabledColor = RarityColors.GetInputDisable();
        _enabledColor = RarityColors.GetInputEnable();

        _nameText.text = _stat.Name + ":";

        _levelInput.characterLimit = CountMaxLevelCharcters(_stat.MaxLevel);

        _toggle.SetToggle(false);
        Unlock();
    }

    public void LevelChange()
    {
        int input = 0;
        if (_levelInput.text != null) input = int.Parse(_levelInput.text);
        input = ValidateInput(input, _stat.MaxLevel);
        _stat.SetLevel(input);
        _levelInput.text = (_stat.Level == 0) ? "" : _stat.Level.ToString();
    }

    public void ForceToMax()
    {
        _toggle.SetToggle(true);
        _stat.SetToMaxLevel();
    }

    public void ForceReset()
    {
        _stat.ResetStat();
    }

    public void Unlock()
    {
        _stat.SetInUse(_toggle.IsOn);
        _levelInput.enabled = _toggle.IsOn;
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

    private void Update()
    {
        // elevated values that are used multiple times
        bool isMaxLevel = _stat.IsMaxLevel;
        // set placeholder text
        string placeholder = (_toggle.IsOn) ? _stat.MaxLevel.ToString() : "";
        _placeholderText.text = placeholder;
        // show the modified stats value and colour
        _valueText.text = _modStat.ToString();
        _valueText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;
        // update the input field text and colours
        _levelInput.text = (_stat.Level == 0) ? "" : _stat.Level.ToString();
        _levelInput.GetComponent<Image>().color = (_toggle.IsOn) ? _enabledColor : _disabledColor;
        _levelText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;
        // set name text colour
        _nameText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;
    }
}
