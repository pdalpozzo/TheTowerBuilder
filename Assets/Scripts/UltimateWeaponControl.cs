using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UltimateWeaponControl : MonoBehaviour
{
    [SerializeField] private UltimateWeapon _ultimateWeapon;
    [SerializeField] private Tooltip _tooltip;

    [SerializeField] private EffectVisualControl _effectOne;
    [SerializeField] private EffectVisualControl _effectTwo;
    [SerializeField] private EffectVisualControl _effectThree;
    [SerializeField] private EffectVisualControl _effectPlus;

    [SerializeField] private TextMeshProUGUI _ultimateWeapongNameText;

    [SerializeField] private OnOffToggleControl _mainToggleControl;
    [SerializeField] private OnOffToggleControl _plusToggleControl;

    [SerializeField] private Image _icon;
    [SerializeField] private Image _mainFade;
    [SerializeField] private Image _plusFade;

    public bool IsOn { get { return _mainToggleControl.IsOn; } }
    public OnOffToggleControl ToggleControl {  get { return _mainToggleControl; } }

    private void Awake()
    {
        EventManager.OnUltimateWeaponPlusAvailable += UltimateWeaponPlusAvailability;   // triggered by ultimate weapon holder
    }

    private void Start()
    {
        _ultimateWeapongNameText.text = _ultimateWeapon.Name;
        _icon.sprite = _ultimateWeapon.Icon;
        _plusToggleControl.SetUnlock(false);

        UpdateInteractions(_mainToggleControl.IsOn);
        UpdatePlusInteractions(_plusToggleControl.IsOn);

        _tooltip.SetMessage(_ultimateWeapon.TooltipMessage, _ultimateWeapon.Name);
    }

    public void ForceOnUltimateWeapon()
    {
        _mainToggleControl.SetToggle(true);
        UpdateInteractions(true);
    }

    public void ForceOffUltimateWeapon()
    {
        _mainToggleControl.SetToggle(false);
        UpdateInteractions(false);
        UpdatePlusInteractions(false);
    }

    public void ToggleUltimateWeapon()
    {
        _ultimateWeapon.ChangeActive(_mainToggleControl.IsOn);
        UpdateInteractions(_mainToggleControl.IsOn);

        if (!_ultimateWeapon.IsPlusAvailable)
        {
            _plusToggleControl.SetUnlock(_ultimateWeapon.IsPlusAvailable);
            UpdatePlusInteractions(_plusToggleControl.IsOn);
        }
    }

    public void ToggleUltimateWeaponPlus()
    {
        _ultimateWeapon.SetPlusUnlocked(_plusToggleControl.IsOn);
        UpdatePlusInteractions(_plusToggleControl.IsOn);
    }

    private void UltimateWeaponPlusAvailability(bool isPlusAvailable)
    {
        _plusToggleControl.SetUnlock(isPlusAvailable);
        _ultimateWeapon.SetPlusUnlocked(_plusToggleControl.IsOn);
        UpdatePlusInteractions(_plusToggleControl.IsOn);
    }

    private void UpdateInteractions(bool isOn)
    {
        _effectOne.SetInteraction(isOn);
        _effectTwo.SetInteraction(isOn);
        _effectThree.SetInteraction(isOn);
        _mainFade.gameObject.SetActive(!isOn);
    }

    private void UpdatePlusInteractions(bool isOn)
    {
        _effectPlus.SetInteraction(isOn);
        _plusFade.gameObject.SetActive(!isOn);
    }
}
