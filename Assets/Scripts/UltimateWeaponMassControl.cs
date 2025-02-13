using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateWeaponMassControl : MonoBehaviour
{
    [SerializeField] private UltimateWeaponControl _blackHole;
    [SerializeField] private UltimateWeaponControl _chainLightning;
    [SerializeField] private UltimateWeaponControl _chronoField;
    [SerializeField] private UltimateWeaponControl _deathWave;
    [SerializeField] private UltimateWeaponControl _goldenTower;
    [SerializeField] private UltimateWeaponControl _innerLandMines;
    [SerializeField] private UltimateWeaponControl _poisonSwamp;
    [SerializeField] private UltimateWeaponControl _smartMissiles;
    [SerializeField] private UltimateWeaponControl _spotlight;

    public void AllOn()
    {
        _blackHole.ForceOnUltimateWeapon();
        _chainLightning.ForceOnUltimateWeapon();
        _chronoField.ForceOnUltimateWeapon();
        _deathWave.ForceOnUltimateWeapon();
        _goldenTower.ForceOnUltimateWeapon();
        _innerLandMines.ForceOnUltimateWeapon();
        _poisonSwamp.ForceOnUltimateWeapon();
        _smartMissiles.ForceOnUltimateWeapon();
        _spotlight.ForceOnUltimateWeapon();
    }

    public void AllOff() 
    {
        _blackHole.ForceOffUltimateWeapon();
        _chainLightning.ForceOffUltimateWeapon();
        _chronoField.ForceOffUltimateWeapon();
        _deathWave.ForceOffUltimateWeapon();
        _goldenTower.ForceOffUltimateWeapon();
        _innerLandMines.ForceOffUltimateWeapon();
        _poisonSwamp.ForceOffUltimateWeapon();
        _smartMissiles.ForceOffUltimateWeapon();
        _spotlight.ForceOffUltimateWeapon();
    }
}
