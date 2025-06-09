using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MasteryDisplay : MonoBehaviour
{
    [SerializeField] private ModifiedStat _modStat; // one to display

    // mastery fields
    [SerializeField] private TextMeshProUGUI _nameText;         // stat name
    [SerializeField] private TextMeshProUGUI _valueText;        // modified stat value
    [SerializeField] private TextMeshProUGUI _levelText;        // stat level
    [SerializeField] private TextMeshProUGUI _placeholderText;  // stat max level
    [SerializeField] private TextMeshProUGUI _descriptionText;  // card description
    [SerializeField] private TMP_InputField _levelInput;        // stat current level
    [SerializeField] private OnOffToggleControl _toggle;        // stat in use toggle
    [SerializeField] private Button _resetLevel;                // set stat to level 1
    [SerializeField] private Button _setToMaxLevel;             // set stat to max level

    private NewStat _stat;      // one to edit
    private Color _defaultColour;
    private Color _maxLevelColour;

    public NewStat Stat {  get { return _stat; } }

    private void Start()
    {
        _stat = (NewStat)_modStat.BaseStat;

        _nameText.text = _stat.Name;
        _levelInput.characterLimit = 1;

        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _maxLevelColour = RarityColors.GetMax();

        _placeholderText.text = _stat.MaxLevel.ToString();

        _toggle.SetToggle(_stat.IsInUse);
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
        _levelInput.enabled = _stat.IsInUse;
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
        string placeholder = (_stat.IsInUse) ? _stat.MaxLevel.ToString() : "";
        _placeholderText.text = placeholder;
        // show the modified stats value and colour
        _valueText.text = _modStat.ToString();
        _valueText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;
        // update the input field text and colours
        _levelInput.text = (_stat.Level == 0) ? "" : _stat.Level.ToString();
        // set name text colour
        _nameText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;

        // work out the colour based on level
        Color assignColour = _defaultColour;
        if (isMaxLevel) assignColour = _maxLevelColour;
        _levelText.color = assignColour;

        // button interactions
        if (_resetLevel != null) _resetLevel.interactable = (_stat.Level != 0);
        if (_setToMaxLevel != null) _setToMaxLevel.interactable = (!isMaxLevel);
    }
}
