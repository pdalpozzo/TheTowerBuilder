using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopEnhancementDisplay : MonoBehaviour
{
    [SerializeField] private Stat _stat;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _placeholderText;
    [SerializeField] private TMP_InputField _levelInput;
    [SerializeField] private OnOffToggleControl _toggle;

    private Color _defaultColour;
    private Color _maxLevelColour;
    private Color _disabledColor;
    private Color _enabledColor;

    private void Awake()
    {
        EventManager.OnEnhancementForceReset += ForceEnhancementReset;
        EventManager.OnEnhancementForceUnlock += ForceEnhancementUnlock;

        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _maxLevelColour = RarityColors.GetMax();
        _disabledColor = RarityColors.GetInputDisable();
        _enabledColor = RarityColors.GetInputEnable();

        _nameText.text = _stat.Name + ":";

        _levelInput.characterLimit = CountMaxLevelCharcters(_stat.Enhancement.MaxLevel);
    }

    private void Start()
    {
        ToggleEnhancement();
    }

    public void ToggleEnhancement()
    {
        _stat.Enhancement.SetUnlock(_toggle.IsOn);
        _levelInput.enabled = _toggle.IsOn;
        _levelInput.GetComponent<Image>().color = _enabledColor;
        if (!_toggle.IsOn)
        {
            _levelInput.GetComponent<Image>().color = _disabledColor;
            _stat.Enhancement.NewLevel(0);
        }
        UpdateInputField();
        EventManager.WorkshopChange(_stat);
    }

    public void ForceEnhancementUnlock()
    {
        _toggle.SetToggle(true);
        ToggleEnhancement();
    }

    public void ForceEnhancementReset()
    {
        _toggle.SetToggle(false); 
        ToggleEnhancement();
    }

    public void EnhancementChanged()
    {
        int input = 0;
        if (_levelInput.text != null) input = int.Parse(_levelInput.text);
        input = ValidateInput(input, _stat.Enhancement.MaxLevel);
        _stat.Enhancement.NewLevel(input); 
        UpdateInputField();
        EventManager.WorkshopChange(_stat);
    }

    private void UpdateInputField()
    {
        _levelInput.text = (_stat.Enhancement.Level == 0) ? "" : _stat.Enhancement.Level.ToString();
    }

    private void Update()
    {
        string placeholder = (_toggle.IsOn) ? _stat.Enhancement.MaxLevel.ToString() : "";
        _placeholderText.text = placeholder;
        _valueText.text = _stat.Enhancement.ValueDisplay;
        _valueText.color = (_stat.Enhancement.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _levelText.color = (_stat.Enhancement.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _nameText.color = (_stat.Enhancement.IsMaxLevel) ? _maxLevelColour : _defaultColour;
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
