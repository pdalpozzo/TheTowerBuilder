using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EffectVisualControl : MonoBehaviour
{
    [SerializeField] private Button _downTen;
    [SerializeField] private Button _downOne;
    [SerializeField] private Button _upOne;
    [SerializeField] private Button _upTen;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _levelText;

    [SerializeField] private Stat _stat;

    private Color _defaultColour;
    private Color _maxLevelColour;
    private bool _canInteract = false;

    private void Awake()
    {
        EventManager.OnAnyStatChange += StatChanged;
    }

    private void Start()
    {
        _defaultColour = RarityColors.GetColor(Rarity.COMMON);
        _maxLevelColour = RarityColors.GetMax();

        _nameText.text = _stat.Effect.Name;
    }

    private void StatChanged(Stat stat)
    {
        if (stat != _stat) return;
    }

    private void Update()
    {
        _downTen.interactable = _stat.Effect.Level > _stat.Effect.BaseLevel;
        _downOne.interactable = _stat.Effect.Level > _stat.Effect.BaseLevel;
        _upOne.interactable = _stat.Effect.Level < _stat.Effect.MaxLevel;
        _upTen.interactable = _stat.Effect.Level < _stat.Effect.MaxLevel;

        _levelText.text = _stat.Effect.Level.ToString();
        _valueText.text = _stat.ValueDisplay;
        // change text colour if maxed
        _nameText.color = (_stat.Effect.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _valueText.color = (_stat.Effect.IsMaxLevel) ? _maxLevelColour : _defaultColour;
        _levelText.color = (_stat.Effect.IsMaxLevel) ? _maxLevelColour : _defaultColour;
    }

    public void SetInteraction(bool interact)
    {
        _canInteract = interact;
    }

    public void LevelChange(int levelChange)
    {
        if (!_canInteract) return;
        _stat.Effect.SetLevel(levelChange);
    }
}
