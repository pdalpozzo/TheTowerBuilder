using UnityEngine;
using UnityEngine.UI;

public class WorkshopPanelControl : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private GameObject _enhancementPanel;

    [SerializeField] private Toggle _upgradeButton;
    [SerializeField] private Toggle _enhancementButton;

    [SerializeField] private Button _unlockAllUpgradesButton;
    [SerializeField] private Button _resetUpgradesButton;
    [SerializeField] private Button _maxUpgradesButton;
    [SerializeField] private Button _unlockAllEnhancementsButton;
    [SerializeField] private Button _resetEnhancementsButton;

    [SerializeField] private WorkshopUpgradeDisplay[] _attack;
    [SerializeField] private WorkshopUpgradeDisplay[] _defense;
    [SerializeField] private WorkshopUpgradeDisplay[] _utility;

    private void Awake()
    {
        EventManager.OnUpgradeUnlock += HandleGroupUnlocking;
    }

    private void Start()
    {
        ToggleWorkshop();
    }

    public void ToggleWorkshop()
    {
        _upgradePanel.SetActive(_upgradeButton.isOn);
        _unlockAllUpgradesButton.gameObject.SetActive(_upgradeButton.isOn);
        _resetUpgradesButton.gameObject.SetActive(_upgradeButton.isOn);
        _maxUpgradesButton.gameObject.SetActive(_upgradeButton.isOn);

        _enhancementPanel.SetActive(_enhancementButton.isOn);
        _unlockAllEnhancementsButton.gameObject.SetActive(_enhancementButton.isOn);
        _resetEnhancementsButton.gameObject.SetActive(_enhancementButton.isOn);
    }

    public void ResetUpgrade()
    {
        EventManager.UpgradeForceReset();
    }

    public void UnlockAllUpgrades()
    {
        EventManager.UpgradeForceUnlock();
    }

    public void MaxAllUpgrades()
    {
        EventManager.UpgradeForceMax();
    }

    public void ResetEnhancements()
    {
        EventManager.EnhancementForceReset();
    }

    public void UnlockAllEnhancements()
    {
        EventManager.EnhancementForceUnlock();
    }

    private void HandleGroupUnlocking(UnlockCategory category, bool isUnlocked)
    {
        int baseNumber = (int)UnlockCategory.DEFENSE;                                   // base for defense
        if (category < UnlockCategory.DEFENSE) baseNumber = (int)UnlockCategory.RANGE;  // base for attacks
        if (category >= UnlockCategory.CASH) baseNumber = (int)UnlockCategory.CASH;     // base for utility

        if (isUnlocked)
        {
            if (baseNumber == (int)UnlockCategory.RANGE) UnlockGroups(_attack, category);
            if (baseNumber == (int)UnlockCategory.DEFENSE) UnlockGroups(_defense, category);
            if (baseNumber == (int)UnlockCategory.CASH) UnlockGroups(_utility, category);
        }
        else
        {
            if (baseNumber == (int)UnlockCategory.RANGE) LockGroups(_attack, category);
            if (baseNumber == (int)UnlockCategory.DEFENSE) LockGroups(_defense, category);
            if (baseNumber == (int)UnlockCategory.CASH) LockGroups(_utility, category);
        }
    }

    private void UnlockGroups(WorkshopUpgradeDisplay[] upgrades, UnlockCategory category)
    {
        foreach (WorkshopUpgradeDisplay upgrade in upgrades)
        {
            if (upgrade.Category <= category) upgrade.ForceUpgradeUnlock();
        }
    }

    private void LockGroups(WorkshopUpgradeDisplay[] upgrades, UnlockCategory category)
    {
        foreach (WorkshopUpgradeDisplay upgrade in upgrades)
        {
            if (upgrade.Category >= category) upgrade.ForceUpgradeReset();
        }
    }
}
