using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        _input.placeholder.GetComponent<TextMeshProUGUI>().text = _lab.MaxLevel.ToString();
    }

    public void LevelChange()
    {
        int input = 0;
        if (_input.text != null) input = int.Parse(_input.text);
        input = ValidateInput(input, _lab.MaxLevel);
        _lab.NewLevel(input);
        UpdateInputField();
    }

    public void ForceMaxLevel()
    {
        _lab.NewLevel(_lab.MaxLevel);
        UpdateInputField();
    }

    public void ForceReset()
    {
        _lab.NewLevel(_lab.BaseLevel);
        UpdateInputField();
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
        if (lab == _lab) UpdateInputField();
    }

    private void UpdateInputField()
    {
        _input.text = (_lab.Level == 0) ? "" : _lab.Level.ToString();
    }

    private void Update()
    {
        _valueText.text = _lab.DisplayValue;

        _nameText.color = (_lab.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _valueText.color = (_lab.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _levelText.color = (_lab.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        if (_reset != null) _reset.interactable = (_lab.BaseLevel != _lab.Level);
        if (_max != null) _max.interactable = (!_lab.IsMaxLevel);
    }

    private int ValidateInput(int input, int max)
    {
        if (input < 0) input = 0;
        if (input > max) input = max;
        return input;
    }

}
