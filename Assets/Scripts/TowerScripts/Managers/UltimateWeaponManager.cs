using UnityEngine;

public class UltimateWeaponManager : MonoBehaviour
{
    private int _numberOfUltimateWeapons = 9;
    private int _unlockedCount = 0;
    private bool _allUnlocked = false;

    [SerializeField] private UltimateWeapon _blackHole;
    [SerializeField] private UltimateWeapon _chainLightning;
    [SerializeField] private UltimateWeapon _chronoField;
    [SerializeField] private UltimateWeapon _deathWave;
    [SerializeField] private UltimateWeapon _goldenTower;
    [SerializeField] private UltimateWeapon _innerLandMines;
    [SerializeField] private UltimateWeapon _poisonSwamp;
    [SerializeField] private UltimateWeapon _smartMissiles;
    [SerializeField] private UltimateWeapon _spotlight;

    private void Awake()
    {
        EventManager.OnUltimateWeaponStatusChange += UltimateWeaponStatus;  // triggered by ultimate weapon
    }

    private void Start()
    {
        CheckUnlockedCount();
    }

    private void UltimateWeaponStatus(UltimateWeaponType ultimateWeapon, bool isOn)
    {
        CheckUnlockedCount();
    }

    private void CheckUnlockedCount()
    {
        int total = 0;
        total = (_blackHole.IsOn)? total + 1: total;
        total = (_chainLightning.IsOn) ? total + 1 : total;
        total = (_chronoField.IsOn) ? total + 1 : total;
        total = (_deathWave.IsOn) ? total + 1 : total;
        total = (_goldenTower.IsOn) ? total + 1 : total;
        total = (_innerLandMines.IsOn) ? total + 1 : total;
        total = (_poisonSwamp.IsOn) ? total + 1 : total;
        total = (_smartMissiles.IsOn) ? total + 1 : total;
        total = (_spotlight.IsOn) ? total + 1 : total;

        _unlockedCount = total;
        _allUnlocked = (_unlockedCount == _numberOfUltimateWeapons);
        EventManager.UltimateWeaponPlusAvailable(_allUnlocked);
    }
}
