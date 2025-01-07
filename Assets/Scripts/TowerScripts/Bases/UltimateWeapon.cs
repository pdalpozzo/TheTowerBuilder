using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UltimateWeaponType { BLACK_HOLE, CHAIN_LIGHTNING, CHRONO_FIELD, DEATH_WAVE, GOLDEN_TOWER, INNER_LAND_MINES, POISON_SWAMP, SMART_MISSILES, SPOTLIGHT};

public class UltimateWeapon : MonoBehaviour
{
    [SerializeField] private string _uwName;
    [TextArea(3, 10)][SerializeField] private string tooltipMessage;
    [SerializeField] private UltimateWeaponType _uwType;
    [SerializeField] private bool _isOn = false;
    [SerializeField] private bool _isPlusAvailable = false; // conditions are met
    [SerializeField] private bool _isPlusUnlocked = false;  // has been unlocked
    [SerializeField] private Effect _one;
    [SerializeField] private Effect _two;
    [SerializeField] private Effect _three;
    [SerializeField] private Effect _plus;
    [SerializeField] private Sprite _icon;

    public string Name { get { return _uwName; } }
    public string TooltipMessage { get { return tooltipMessage; } }
    public bool IsOn { get { return _isOn; } }
    public bool IsPlusAvailable { get { return _isPlusAvailable; } }
    public bool IsPlusUnlocked { get { return _isPlusUnlocked; } }
    public Sprite Icon { get { return _icon; } }

    private void Awake()
    {
        EventManager.OnUltimateWeaponPlusAvailable += ChangePlusAvailable;  // triggered by ultimate weapons holder
    }

    private void Start()
    {
        Trigger_UltimateWeaponStatusChanged();
    }

    public void ChangeActive(bool isOn)
    {
        _isOn = isOn;
        Trigger_UltimateWeaponStatusChanged();
    }

    public void SetPlusUnlocked(bool isUnlocked)
    {
        _isPlusUnlocked = false;
        if (_isPlusAvailable) _isPlusUnlocked = isUnlocked;
    }

    private void ChangePlusAvailable(bool available)
    {
        _isPlusAvailable = available;
        if(!_isPlusAvailable) _isPlusUnlocked = false;
    }

    // trigger when the ultimate weapon is turn on or off
    private void Trigger_UltimateWeaponStatusChanged()
    {
        EventManager.UltimateWeaponStatusChange(_uwType, _isOn);
    }
}
