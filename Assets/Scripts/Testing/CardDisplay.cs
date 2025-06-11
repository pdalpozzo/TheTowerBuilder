using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private ModifiedStat _modStat;             // one to display
    [SerializeField] private NewCard _card;                     // card details
    [SerializeField] private MasteryDisplay _masteryDisplay;    // mastery stat

    // card fields
    [SerializeField] private TextMeshProUGUI _nameText;         // stat name
    [SerializeField] private TextMeshProUGUI _valueText;        // modified stat value
    [SerializeField] private TextMeshProUGUI _levelText;        // stat level
    [SerializeField] private TextMeshProUGUI _placeholderText;  // stat max level
    [SerializeField] private TextMeshProUGUI _descriptionText;  // card description
    [SerializeField] private TMP_InputField _levelInput;        // stat current level
    [SerializeField] private Toggle _toggle;                    // stat in use toggle
    [SerializeField] private Button _resetLevel;                // set stat to level 1
    [SerializeField] private Button _setToMaxLevel;             // set stat to max level
    [SerializeField] private Image _border;                     // card border to be rarity colour
    [SerializeField] private Image _icon;                       // card icon
    [SerializeField] private Image _iconBorder;                 // icon border to be rarity colour
    [SerializeField] private Image[] _outlines;                 // star outlines
    [SerializeField] private Image[] _stars;                    // filled stars
    [SerializeField] private GameObject _fade;                  // use to fade card
    [SerializeField] private GameObject _equippedBorder;        // use to show equipped

    private ModifiedStat _mastery;
    private Color _defaultColour;
    private Color _fiveStarColour;
    private Color _maxLevelColour;
    private Color _masteryColour;

    private void Start()
    {
        _mastery = _masteryDisplay.Stat;

        _nameText.text = _modStat.Name;
        _levelInput.characterLimit = 1;
        _icon.sprite = _card.Icon;
        _iconBorder.color = RarityColors.GetColor(_card.Rarity);
        _border.color = _iconBorder.color;

        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _fiveStarColour = RarityColors.GetMax();
        _maxLevelColour = RarityColors.GetColor(Rarity.EPIC);
        _masteryColour = RarityColors.GetColor(Rarity.ANCESTRAL);

        _placeholderText.text = _modStat.MaxLevel.ToString();

        _toggle.isOn = _modStat.IsInUse;
        Unlock();
    }

    public void LevelChange()
    {
        int input = 0;
        if (_levelInput.text != null) input = int.Parse(_levelInput.text);
        input = ValidateInput(input, _modStat.MaxLevel);
        _modStat.SetLevel(input);
        _levelInput.text = (_modStat.Level == 0) ? "" : _modStat.Level.ToString();
    }

    public void ForceToMax()
    {
        _toggle.isOn = true;
        _modStat.SetToMaxLevel();
    }

    public void ForceReset()
    {
        _modStat.ResetStat();
        _mastery.ResetStat();
    }

    public void Unlock()
    {
        _modStat.SetInUse(_toggle.isOn);
        _levelInput.enabled = _modStat.IsInUse;
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
        bool isMaxLevel = _modStat.IsMaxLevel;
        // set placeholder text
        string placeholder = (_modStat.IsInUse) ? _modStat.MaxLevel.ToString() : "";
        _placeholderText.text = placeholder;
        // show the modified stats value and colour
        _valueText.text = _modStat.ToString();
        _valueText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;
        // update the input field text and colours
        _levelInput.text = (_modStat.Level == 0) ? "" : _modStat.Level.ToString();
        // set name text colour
        _nameText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;
        // set equipped border and fade
        _equippedBorder.SetActive(_modStat.IsInUse);
        _fade.SetActive((_modStat.Level == 0));

        // work out the colour based on level
        Color assignColour = _defaultColour;
        if (_modStat.Level == _modStat.MaxLevel - 1) assignColour = _fiveStarColour;
        if (isMaxLevel) assignColour = _maxLevelColour;
        if (_mastery.IsInUse) assignColour = _masteryColour;
        _levelText.color = assignColour;

        // set stars and assign colour based on level
        for (int i = 0; i < _stars.Length; i++)
        {
            _stars[i].gameObject.SetActive(true);
            _outlines[i].color = assignColour;
            _stars[i].color = assignColour;
            if (i >= _modStat.Level) _stars[i].gameObject.SetActive(false);
        }

        // button interactions
        if (_resetLevel != null) _resetLevel.interactable = (_modStat.Level != 0);
        if (_setToMaxLevel != null) _setToMaxLevel.interactable = (!isMaxLevel);
    }
}
