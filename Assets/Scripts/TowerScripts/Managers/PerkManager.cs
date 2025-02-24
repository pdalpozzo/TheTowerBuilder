using System.Collections.Generic;
using UnityEngine;

public class PerkManager : MonoBehaviour
{
    [SerializeField] private Stat _banPerks;
    [SerializeField] private Stat _autoPickRanking;

    // common or standard perks                                       stacks 
    [SerializeField] private Perk _unlockRandomUW;                    // 1

    // ultimate weapon perks
    [SerializeField] private Perk _blackHole;
    [SerializeField] private Perk _chainLightning;
    [SerializeField] private Perk _chronoField;
    [SerializeField] private Perk _deathWave;
    [SerializeField] private Perk _goldenTower;
    [SerializeField] private Perk _innerLandMines;
    [SerializeField] private Perk _poisonSwamp;
    [SerializeField] private Perk _smartMissile;
    [SerializeField] private Perk _spotlight;

    [SerializeField] private List<Perk> _bannedPerks;
    [SerializeField] private List<Perk> _priorityPerks;

    [SerializeField] private List<Perk> _bannedPresetOne;
    [SerializeField] private List<Perk> _priorityPresetOne;
    [SerializeField] private List<Perk> _bannedPresetTwo;
    [SerializeField] private List<Perk> _priorityPresetTwo;
    [SerializeField] private List<Perk> _bannedPresetThree;
    [SerializeField] private List<Perk> _priorityPresetThree;
    [SerializeField] private List<Perk> _bannedPresetFour;
    [SerializeField] private List<Perk> _priorityPresetFour;
    [SerializeField] private List<Perk> _bannedPresetFive;
    [SerializeField] private List<Perk> _priorityPresetFive;

    private int _selectedPreset = 1;
    private int _unlockedBans = 0;
    private int _unlockedPriority = 0;

    [SerializeField] private bool _randomUWActive = true;

    private void Awake()
    {
        EventManager.OnUltimateWeaponPlusAvailable += AllUltimateWeaponsUnlocked;   // triggered by ultimate weapon holder
        EventManager.OnUltimateWeaponStatusChange += UltimateWeaponsUnlocked;       // triggered by ultimate weapon
        EventManager.OnPerkBanChange += BanPerk;                                    // triggered by perk status control
        EventManager.OnPerkPriorityChange += PriorityPerk;                          // triggered by perk status control
        EventManager.OnPerkPresetChange += ChangePresetSelection;
    }

    private void Update()
    {
        if (_unlockedBans != _banPerks.Value) UpdateBanLimit(_banPerks.Value);
        if (_unlockedPriority != _autoPickRanking.Value) UpdatePriorityLimit(_autoPickRanking.Value);
    }

    private void UpdateBanLimit(float newLimit)
    {
        _unlockedBans = (int)newLimit;

        UpdateNewListLimit(_bannedPerks, _unlockedBans, true);
        UpdateNewListLimit(_bannedPresetOne, _unlockedBans);
        UpdateNewListLimit(_bannedPresetTwo, _unlockedBans);
        UpdateNewListLimit(_bannedPresetThree, _unlockedBans);
        UpdateNewListLimit(_bannedPresetFour, _unlockedBans);
        UpdateNewListLimit(_bannedPresetFive, _unlockedBans);
    }

    private void UpdatePriorityLimit(float newLimit)
    {
        _unlockedPriority = (int)newLimit;

        UpdateNewListLimit(_priorityPerks, _unlockedPriority, true);
        UpdateNewListLimit(_priorityPresetOne, _unlockedPriority);
        UpdateNewListLimit(_priorityPresetTwo, _unlockedPriority);
        UpdateNewListLimit(_priorityPresetThree, _unlockedPriority);
        UpdateNewListLimit(_priorityPresetFour, _unlockedPriority);
        UpdateNewListLimit(_priorityPresetFive, _unlockedPriority);
    }

    private void UpdateNewListLimit(List<Perk> list, int newLimit, bool isEquipped = false)
    {
        for (int i = list.Count; i > newLimit; i--)
        {
            if (isEquipped)
            {
                list[i - 1].SetBan(false);
                list[i - 1].SetPriority(false);
            }
            list.RemoveAt(i - 1);
        }
    }

    private void BanPerk(Perk perk)
    {
        if (perk.IsBanned)
        {
            perk.SetBan(false);
            _bannedPerks.Remove(perk);
            return;
        }

        if (_bannedPerks.Count >= _unlockedBans) return;

        if (perk.IsPriority) _priorityPerks.Remove(perk);
        perk.SetBan(true);
        _bannedPerks.Add(perk);

    }

    private void PriorityPerk(Perk perk)
    {
        if (perk.IsPriority)
        {
            perk.SetPriority(false);
            _priorityPerks.Remove(perk);
            return;
        }

        if (_priorityPerks.Count >= _unlockedPriority) return;

        if (perk.IsBanned) _bannedPerks.Remove(perk);
        perk.SetPriority(true);
        _priorityPerks.Add(perk);
    }

    private void AllUltimateWeaponsUnlocked(bool isUnlocked)
    {
        _randomUWActive = !isUnlocked;
        if (_unlockRandomUW.IsBanned && !_randomUWActive) _bannedPerks.Remove(_unlockRandomUW);
        if (_unlockRandomUW.IsPriority && !_randomUWActive) _priorityPerks.Remove(_unlockRandomUW);
        _unlockRandomUW.SetInteractive(_randomUWActive);
    }

    private void UltimateWeaponsUnlocked(UltimateWeaponType ultimateWeapon, bool isOn)
    {
        switch (ultimateWeapon)
        {
            case UltimateWeaponType.BLACK_HOLE:
                CheckBanAndPriorityOnInteraction(_blackHole, isOn);
                break;
            case UltimateWeaponType.CHAIN_LIGHTNING:
                CheckBanAndPriorityOnInteraction(_chainLightning, isOn);
                break;
            case UltimateWeaponType.CHRONO_FIELD:
                CheckBanAndPriorityOnInteraction(_chronoField, isOn);
                break;
            case UltimateWeaponType.DEATH_WAVE:
                CheckBanAndPriorityOnInteraction(_deathWave, isOn);
                break;
            case UltimateWeaponType.GOLDEN_TOWER:
                CheckBanAndPriorityOnInteraction(_goldenTower, isOn);
                break;
            case UltimateWeaponType.INNER_LAND_MINES:
                CheckBanAndPriorityOnInteraction(_innerLandMines, isOn);
                break;
            case UltimateWeaponType.POISON_SWAMP:
                CheckBanAndPriorityOnInteraction(_poisonSwamp, isOn);
                break;
            case UltimateWeaponType.SMART_MISSILES:
                CheckBanAndPriorityOnInteraction(_smartMissile, isOn);
                break;
            case UltimateWeaponType.SPOTLIGHT:
                CheckBanAndPriorityOnInteraction(_spotlight, isOn);
                break;
        }
    }

    private void CheckBanAndPriorityOnInteraction(Perk perk, bool isOn)
    {
        if (perk.IsBanned && !isOn) _bannedPerks.Remove(perk);
        if (perk.IsPriority && !isOn) _priorityPerks.Remove(perk);
        perk.SetInteractive(isOn);
    }

    private void ChangePresetSelection(int presetSlot)
    {
        if (presetSlot == _selectedPreset) return;

        switch (_selectedPreset)
        {
            case 2:
                TransferBanList(_bannedPresetTwo, _bannedPerks);
                TransferPriorityList(_priorityPresetTwo, _priorityPerks);
                break;
            case 3:
                TransferBanList(_bannedPresetThree, _bannedPerks);
                TransferPriorityList(_priorityPresetThree, _priorityPerks);
                break;
            case 4:
                TransferBanList(_bannedPresetFour, _bannedPerks);
                TransferPriorityList(_priorityPresetFour, _priorityPerks);
                break;
            case 5:
                TransferBanList(_bannedPresetFive, _bannedPerks);
                TransferPriorityList(_priorityPresetFive, _priorityPerks);
                break;
            default:
                TransferBanList(_bannedPresetOne, _bannedPerks);
                TransferPriorityList(_priorityPresetOne, _priorityPerks);
                break;
        }

        _selectedPreset = presetSlot;
        List<Perk> bans = new List<Perk>();
        List<Perk> priorities = new List<Perk>();

        switch (_selectedPreset)
        {
            case 2:
                TransferBanList(bans, _bannedPresetTwo);
                TransferPriorityList(priorities, _priorityPresetTwo);
                break;
            case 3:
                TransferBanList(bans, _bannedPresetThree);
                TransferPriorityList(priorities, _priorityPresetThree);
                break;
            case 4:
                TransferBanList(bans, _bannedPresetFour);
                TransferPriorityList(priorities, _priorityPresetFour);
                break;
            case 5:
                TransferBanList(bans, _bannedPresetFive);
                TransferPriorityList(priorities, _priorityPresetFive);
                break;
            default:
                TransferBanList(bans, _bannedPresetOne);
                TransferPriorityList(priorities, _priorityPresetOne);
                break;
        }
        TransferBanList(_bannedPerks, bans, true);
        TransferPriorityList(_priorityPerks, priorities, true);
    }

    private void TransferBanList(List<Perk> toList, List<Perk> fromList, bool isEquipped = false)
    {
        toList.Clear();
        foreach (Perk perk in fromList)
        {
            perk.ResetBanPriority();
            toList.Add(perk);
            if (isEquipped) perk.SetBan(true);
        }
    }

    private void TransferPriorityList(List<Perk> toList, List<Perk> fromList, bool isEquipped = false)
    {
        toList.Clear();
        foreach (Perk perk in fromList)
        {
            perk.ResetBanPriority();
            toList.Add(perk);
            if (isEquipped) perk.SetPriority(true);
        }
    }
}
