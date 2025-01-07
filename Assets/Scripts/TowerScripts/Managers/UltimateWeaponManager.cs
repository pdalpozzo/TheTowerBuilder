using System.Collections;
using System.Collections.Generic;
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

    public int UnlockedCount {  get { return _unlockedCount; } }
    public UltimateWeapon BlackHole { get { return _blackHole; } }
    public UltimateWeapon ChainLightning { get { return _chainLightning; } }
    public UltimateWeapon ChronoField { get { return _chronoField; } }
    public UltimateWeapon DeathWave { get { return _deathWave; } }
    public UltimateWeapon GoldenTower { get { return _goldenTower; } }
    public UltimateWeapon InnerLandMines { get { return _innerLandMines; } }
    public UltimateWeapon PoisonSwamp { get { return _poisonSwamp; } }
    public UltimateWeapon SmartMissles { get { return _smartMissiles; } }
    public UltimateWeapon Spotlight { get { return _spotlight; } }

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
