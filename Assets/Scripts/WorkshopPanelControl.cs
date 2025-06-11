using UnityEngine;
using UnityEngine.UI;

public class WorkshopPanelControl : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private GameObject _enhancementPanel;
    [SerializeField] private GameObject _contentPanel;
    // tab buttons
    [SerializeField] private Toggle _upgradeButton;
    [SerializeField] private Toggle _enhancementButton;
    // upgrade buttons
    [SerializeField] private Button _unlockAllUpgradesButton;
    [SerializeField] private Button _resetUpgradesButton;
    [SerializeField] private Button _maxUpgradesButton;
    // enhancement buttons
    [SerializeField] private Button _unlockAllEnhancementsButton;
    [SerializeField] private Button _resetEnhancementsButton;
    // upgrade lists
    [SerializeField] private WorkshopDisplay[] _attackUpgrades;
    [SerializeField] private WorkshopDisplay[] _defenseUpgrades;
    [SerializeField] private WorkshopDisplay[] _utilityUpgrades;
    // enhancement lists
    [SerializeField] private WorkshopDisplay[] _attackEnhancements;
    [SerializeField] private WorkshopDisplay[] _defenseEnhancements;
    [SerializeField] private WorkshopDisplay[] _utilityEnhancements;

    private void Awake()
    {
        EventManager.OnUpgradeCategoryUnlock += HandleGroupUnlocking;
    }

    private void Start()
    {
        ToggleWorkshop();
    }

    private void Update()
    {
        Vector2 targetRect = _upgradePanel.GetComponent<RectTransform>().sizeDelta;
        if (_enhancementButton.isOn) targetRect = _enhancementPanel.GetComponent<RectTransform>().sizeDelta;

        _contentPanel.GetComponent<RectTransform>().sizeDelta = targetRect;
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
        LockUpgradeGroups(_attackUpgrades, UnlockCategory.START);
        LockUpgradeGroups(_defenseUpgrades, UnlockCategory.START);
        LockUpgradeGroups(_utilityUpgrades, UnlockCategory.START);
    }

    public void UnlockAllUpgrades()
    {
        UnlockUpgradeGroups(_attackUpgrades, UnlockCategory.REND);
        UnlockUpgradeGroups(_defenseUpgrades, UnlockCategory.WALL);
        UnlockUpgradeGroups(_utilityUpgrades, UnlockCategory.ENEMY_LEVEL_SKIP);
    }

    public void MaxAllUpgrades()
    {
        SetGroupToMaxLevel(_attackUpgrades);
        SetGroupToMaxLevel(_defenseUpgrades);
        SetGroupToMaxLevel(_utilityUpgrades);
    }

    public void ResetEnhancements()
    {
        LockEnhancementGroups(_attackEnhancements);
        LockEnhancementGroups(_defenseEnhancements);
        LockEnhancementGroups(_utilityEnhancements);
    }

    public void UnlockAllEnhancements()
    {
        UnlockEnhancementGroups(_attackEnhancements);
        UnlockEnhancementGroups(_defenseEnhancements);
        UnlockEnhancementGroups(_utilityEnhancements);
    }

    public void MaxAllEnhancements()
    {
        SetGroupToMaxLevel(_attackEnhancements);
        SetGroupToMaxLevel(_defenseEnhancements);
        SetGroupToMaxLevel(_utilityEnhancements);
    }

    private void HandleGroupUnlocking(UnlockCategory category, bool isUnlocked)
    {
        int baseNumber = (int)UnlockCategory.DEFENSE;                                   // base for defense
        if (category < UnlockCategory.DEFENSE) baseNumber = (int)UnlockCategory.RANGE;  // base for attacks
        if (category >= UnlockCategory.CASH) baseNumber = (int)UnlockCategory.CASH;     // base for utility

        if (isUnlocked)
        {
            if (baseNumber == (int)UnlockCategory.RANGE) UnlockUpgradeGroups(_attackUpgrades, category);
            if (baseNumber == (int)UnlockCategory.DEFENSE) UnlockUpgradeGroups(_defenseUpgrades, category);
            if (baseNumber == (int)UnlockCategory.CASH) UnlockUpgradeGroups(_utilityUpgrades, category);
        }
        else
        {
            if (baseNumber == (int)UnlockCategory.RANGE) LockUpgradeGroups(_attackUpgrades, category);
            if (baseNumber == (int)UnlockCategory.DEFENSE) LockUpgradeGroups(_defenseUpgrades, category);
            if (baseNumber == (int)UnlockCategory.CASH) LockUpgradeGroups(_utilityUpgrades, category);
        }
    }

    private void UnlockUpgradeGroups(WorkshopDisplay[] upgrades, UnlockCategory category)
    {
        foreach (WorkshopDisplay upgrade in upgrades)
        {
            if (upgrade.Category <= category) upgrade.ForceUnlock();
        }
    }

    private void LockUpgradeGroups(WorkshopDisplay[] upgrades, UnlockCategory category)
    {
        foreach (WorkshopDisplay upgrade in upgrades)
        {
            if (upgrade.Category >= category) upgrade.ForceReset();
        }
    }

    private void UnlockEnhancementGroups(WorkshopDisplay[] enhancements)
    {
        foreach (WorkshopDisplay enhancement in enhancements)
        {
            enhancement.ForceUnlock();
        }
    }

    private void LockEnhancementGroups(WorkshopDisplay[] enhancements)
    {
        foreach (WorkshopDisplay enhancement in enhancements)
        {
            enhancement.ForceReset();
        }
    }

    private void SetGroupToMaxLevel(WorkshopDisplay[] upgrades)
    {
        foreach (WorkshopDisplay upgrade in upgrades)
        {
            upgrade.ForceToMax();
        }
    }
}
