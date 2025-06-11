using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum UnlockCategory
{
    START, RANGE, MULTISHOT, RAPID_FIRE, BOUNCE_SHOT, SUPER_CRIT, REND,
    DEFENSE, THORNS, LIFESTEAL, KNOCKBACK, ORBS, SHOCKWAVE, LANDMINE, DEATH_DEFY, WALL,
    CASH, COIN, FREE_UPGRADE, INTEREST, PACKAGE, ENEMY_LEVEL_SKIP,
    ENHANCEMENT
};

public class WorkshopDisplay : MonoBehaviour
{
    [SerializeField] private ModifiedStat _modStat; // one to display

    [SerializeField] private TextMeshProUGUI _nameText;         // stat name
    [SerializeField] private TextMeshProUGUI _valueText;        // modified stat value
    [SerializeField] private TextMeshProUGUI _levelText;        // stat level
    [SerializeField] private TextMeshProUGUI _placeholderText;  // stat max level
    [SerializeField] private TMP_InputField _levelInput;        // stat current level
    [SerializeField] private OnOffToggleControl _toggle;        // stat in use toggle
    [SerializeField] private UnlockCategory _category;

    private Color _defaultColour;
    private Color _maxLevelColour;
    private Color _disabledColor;
    private Color _enabledColor;

    public UnlockCategory Category { get { return _category; } }

    private void Awake()
    {
        _nameText.text = _modStat.Name + ":";
        _levelInput.characterLimit = CountMaxLevelCharcters(_modStat.MaxLevel);

        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _maxLevelColour = RarityColors.GetMax();
        _disabledColor = RarityColors.GetInputDisable();
        _enabledColor = RarityColors.GetInputEnable();

        _toggle.SetToggle(_modStat.IsInUse);
        Unlock();
    }

    private void Start()
    {
        if (_category == UnlockCategory.START)
        {
            _toggle.SetToggle(true);
            _toggle.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // show the modified stats value and colour
        _valueText.text = _modStat.ToString();
        // update the input field text and colours
        _levelInput.text = (_modStat.Level == 0) ? "" : _modStat.Level.ToString();
        _levelInput.GetComponent<Image>().color = (_modStat.IsInUse) ? _enabledColor : _disabledColor;
    }

    public void LevelChange()
    {
        int input = 0;
        if (_levelInput.text != null) input = int.Parse(_levelInput.text);
        input = ValidateInput(input, _modStat.MaxLevel);
        _modStat.SetLevel(input);
        AssignColours();
    }

    public void ForceToMax()
    {
        _toggle.SetToggle(true);
        _modStat.SetInUse(true);
        _modStat.SetToMaxLevel();
        _placeholderText.text = _modStat.MaxLevel.ToString();
        AssignColours();
    }

    public void ForceUnlock()
    {
        _toggle.SetToggle(true);
        _modStat.SetInUse(true);
        _levelInput.enabled = _modStat.IsInUse;
        _placeholderText.text = _modStat.MaxLevel.ToString();
        AssignColours();
    }

    public void ForceReset()
    {
        if (_category != UnlockCategory.START)
        {
            _modStat.ResetStat();
            _toggle.SetToggle(false);
        }
        else
        {
            _modStat.SetLevel(0);
        }
        AssignColours();
    }

    public void Unlock()
    {
        _modStat.SetInUse(_toggle.IsOn);
        _levelInput.enabled = _modStat.IsInUse;
        if (!_modStat.IsInUse) _modStat.ResetStat();
        _placeholderText.text = (_modStat.IsInUse) ? _modStat.MaxLevel.ToString() : "";
        AssignColours();
        EventManager.UpgradeCategoryUnlock(_category, _modStat.IsInUse);
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

    private void AssignColours()
    {
        bool isMaxLevel = _modStat.IsMaxLevel;
        _valueText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;
        _levelText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;
        _nameText.color = (isMaxLevel) ? _maxLevelColour : _defaultColour;
    }

}
