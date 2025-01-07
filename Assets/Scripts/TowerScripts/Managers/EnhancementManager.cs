using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementManager : MonoBehaviour
{
    // attack enhancements
    [SerializeField] private Enhancement _damage;
    [SerializeField] private Enhancement _rendArmorMax;
    [SerializeField] private Enhancement _criticalFactor;
    [SerializeField] private Enhancement _damagePerMeter;
    [SerializeField] private Enhancement _superCritMulti;
    [SerializeField] private Enhancement _attackSpeed;
    // defense enhancements
    [SerializeField] private Enhancement _health;
    [SerializeField] private Enhancement _healthRegen;
    [SerializeField] private Enhancement _wallHealth;
    [SerializeField] private Enhancement _landmineDamage;
    [SerializeField] private Enhancement _defenseAbsolute;
    [SerializeField] private Enhancement _orbSize;
    // utility enhancements
    [SerializeField] private Enhancement _cashBonus;
    [SerializeField] private Enhancement _coinBonus;
    [SerializeField] private Enhancement _cellsPerKillBonus;
    [SerializeField] private Enhancement _freeUpgrades;
    [SerializeField] private Enhancement _recoveryPackages;
    [SerializeField] private Enhancement _enemyLevelSkips;
}
