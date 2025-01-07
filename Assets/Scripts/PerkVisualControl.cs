using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        EventManager.OnPerkStatusChange += UpdateVisual;    // triggered by perk
    }

    private void Start()
    {
        _icon.sprite = _perk.Icon;
        _description.text = _perk.GetDescription();
        UpdateVisual(_perk);
    }

    // could be in update
    private void UpdateVisual(Perk perk)
    {
        if (perk != _perk) return;
        _description.text = _perk.GetDescription();
        if (_banOverlay != null) _banOverlay.gameObject.SetActive(_perk.IsBanned);
        if (_fade != null) _fade.gameObject.SetActive((_perk.IsBanned || !_perk.IsInteractive));
        if (_priorityOverlay != null) _priorityOverlay.gameObject.SetActive(_perk.IsPriority);
        if (_perkButton != null) _perkButton.interactable = _perk.IsInteractive;
        if (perk.PerkType == PerkType.COMMON)
        {
            _stack.text = perk.GetStacksInfo();
        }
        else
        {
            if (_stack != null ) _stack.gameObject.SetActive(false);
        }
    }
}
