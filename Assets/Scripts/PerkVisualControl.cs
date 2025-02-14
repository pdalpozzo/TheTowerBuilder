using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkVisualControl : MonoBehaviour
{
    [SerializeField] private Perk _perk;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _stack;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _banOverlay;
    [SerializeField] private Image _priorityOverlay;
    [SerializeField] private Image _fade;
    [SerializeField] private Button _perkButton;

    public Perk Perk { get { return _perk; } }

    private void Start()
    {
        _icon.sprite = _perk.Icon;
        _description.text = _perk.GetDescription();
    }

    private void Update()
    {
        _description.text = _perk.GetDescription();
        _banOverlay.gameObject.SetActive(_perk.IsBanned);
        _fade.gameObject.SetActive((_perk.IsBanned || !_perk.IsInteractive));
        _priorityOverlay.gameObject.SetActive(_perk.IsPriority);
        _perkButton.interactable = _perk.IsInteractive;

        if (_perk.PerkType == PerkType.COMMON)
        {
            _stack.text = _perk.GetStacksInfo();
        }
        else
        {
            _stack.gameObject.SetActive(false);
        }
    }
}
