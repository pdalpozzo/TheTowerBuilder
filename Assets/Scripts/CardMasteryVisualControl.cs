using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardMasteryVisualControl : MonoBehaviour
{
    [SerializeField] private Card _card;
    [SerializeField] private CardMastery _mastery;
    [SerializeField] private Stat _stat;

    [SerializeField] private OnOffToggleControl _masteryToggle;

    [SerializeField] private TextMeshProUGUI _cardNameText;
    [SerializeField] private TextMeshProUGUI _masteryNameText;
    [SerializeField] private TextMeshProUGUI _cardDescriptionText;
    [SerializeField] private TextMeshProUGUI _masteryDescriptionText;
    [SerializeField] private TextMeshProUGUI _cardLevelText;
    [SerializeField] private TextMeshProUGUI _masteryLevelText;
    [SerializeField] private TextMeshProUGUI _slotNumberText;

    [SerializeField] private GameObject _slot;
    [SerializeField] private GameObject _fade;

    [SerializeField] private TMP_InputField _cardInput;
    [SerializeField] private TMP_InputField _masteryInput;

    [SerializeField] private Button _cardLevelReset;
    [SerializeField] private Button _cardLevelMax;
    [SerializeField] private Button _masteryLevelReset;
    [SerializeField] private Button _masteryLevelMax;

    [SerializeField] private Image _border;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _iconBorder;
    [SerializeField] private Image[] _outlines;
    [SerializeField] private Image[] _stars;

    private Color _defaultColour;
    private Color _fiveStarColour;
    private Color _maxLevelColour;
    private Color _masteryColour;

    private void Awake()
    {
        EventManager.OnCardForceReset += ForceCardReset;        // triggered by cards mass control
        EventManager.OnCardForceMax += ForceMaxCardLevel;       // triggered by cards mass control
    }

    private void Start()
    {
        _cardNameText.text = _card.Name;
        _masteryNameText.text = _mastery.Name;
        _icon.sprite = _card.Icon;
        _iconBorder.color = RarityColors.GetColor(_card.Rarity);
        _border.color = RarityColors.GetColor(_card.Rarity);

        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _fiveStarColour = RarityColors.GetMax();
        _maxLevelColour = RarityColors.GetColor(Rarity.EPIC);
        _masteryColour = RarityColors.GetColor(Rarity.ANCESTRAL);

        _cardInput.placeholder.GetComponent<TextMeshProUGUI>().text = _card.MaxLevel.ToString();
        _masteryInput.placeholder.GetComponent<TextMeshProUGUI>().text = _mastery.Lab.MaxLevel.ToString();
    }

    public void EquipChange()
    {
        Trigger_CardSelectionChange();
    }

    public void ChangeCardLevel()
    {
        int input = 0;
        if (_cardInput.text != null) input = int.Parse(_cardInput.text);
        input = ValidateInput(input, _card.MaxLevel);
        _card.NewLevel(input);

        if (_card.IsEquipped && _card.Level == 0)
        {
            Trigger_CardSelectionChange();
        }

        UpdateInputField();
    }

    public void ForceMaxCardLevel()
    {
        _card.NewLevel(_card.MaxLevel);
        UpdateInputField();
    }

    public void ForceCardReset()
    {
        _card.NewLevel(_card.BaseLevel);
        _masteryToggle.SetToggle(false);
        _mastery.SetEnable(false);
        Trigger_CardSelectionChange();
        UpdateInputField();
    }

    public void ForceMaxMasteryLevel()
    {
        _mastery.SetEnable(true);
        _mastery.Lab.NewLevel(_mastery.Lab.MaxLevel);
    }

    public void ForceMasteryReset()
    {
        _mastery.Lab.NewLevel(_mastery.Lab.BaseLevel);
    }

    public void ToggleMastery()
    {
        _mastery.SetEnable(_masteryToggle.IsOn);
    }

    // trigger when the card UI has been click to assign the card to a slot
    private void Trigger_CardSelectionChange()
    {
        EventManager.CardSelectionChange(_card);
    }

    private void UpdateInputField()
    {
        _cardInput.text = (_card.Level == 0) ? "" : _card.Level.ToString();
        _masteryInput.text = _mastery.Lab.Level.ToString();
    }

    private void Update()
    {
        _slot.SetActive(_card.IsEquipped);
        _slotNumberText.text = (_card.IsEquipped) ? (_card.Slot + 1).ToString("N0") : "0";

        _fade.SetActive((_card.Level == 0));
        _cardDescriptionText.text = _card.Description;
        _masteryDescriptionText.text = _mastery.Description;

        Color assignColour = _defaultColour;
        if (_card.Level == _card.MaxLevel - 1) assignColour = _fiveStarColour;
        if (_card.Level == _card.MaxLevel) assignColour = _maxLevelColour;
        if (_masteryToggle.IsOn) assignColour = _masteryColour;

        foreach (Image star in _stars)
        {
            star.color = assignColour;
        }

        for (int i = 0; i < _stars.Length; i++)
        {
            _stars[i].gameObject.SetActive(true);
            _outlines[i].color = assignColour;
            _stars[i].color = assignColour;
            if (i >= _card.Level) _stars[i].gameObject.SetActive(false);
        }

        _cardLevelText.color = assignColour;

        _masteryLevelText.color = (_mastery.Lab.MaxLevel == _mastery.Lab.Level) ? _fiveStarColour : _defaultColour;

        if (_cardLevelReset != null) _cardLevelReset.interactable = (_card.BaseLevel != _card.Level);
        if (_cardLevelMax != null) _cardLevelMax.interactable = (_card.MaxLevel != _card.Level);

        if (_masteryLevelReset != null) _masteryLevelReset.interactable = (_masteryToggle.IsOn && _mastery.Lab.BaseLevel != _mastery.Lab.Level);
        if (_masteryLevelMax != null) _masteryLevelMax.interactable = (_masteryToggle.IsOn && _mastery.Lab.MaxLevel != _mastery.Lab.Level);
    }

    private int ValidateInput(int input, int max)
    {
        if (input < 0) input = 0;
        if (input > max) input = max;
        return input;
    }
}
