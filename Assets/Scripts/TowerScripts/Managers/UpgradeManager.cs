using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // attack upgrades
    [SerializeField] private Upgrade _damage;
    [SerializeField] private Upgrade _attackSpeed;
    [SerializeField] private Upgrade _criticalChance;
    [SerializeField] private Upgrade _criticalFactor;
    [SerializeField] private Upgrade _range;
    [SerializeField] private Upgrade _damagePerMeter;
    [SerializeField] private Upgrade _multishotChance;
    [SerializeField] private Upgrade _multishotTargets;
    [SerializeField] private Upgrade _rapidFireChance;
    [SerializeField] private Upgrade _rapidFireDuration;
    [SerializeField] private Upgrade _bounceShotChance;
    [SerializeField] private Upgrade _bounceShotTargets;
    [SerializeField] private Upgrade _bounceShotRange;
    [SerializeField] private Upgrade _superCriticalChance;
    [SerializeField] private Upgrade _superCriticalMulti;
    [SerializeField] private Upgrade _rendArmorChance;
    [SerializeField] private Upgrade _rendArmorMulti;
    // defense upgrades
    [SerializeField] private Upgrade _health;
    [SerializeField] private Upgrade _healthRegen;
    [SerializeField] private Upgrade _defensePct;
    [SerializeField] private Upgrade _defenseAbsolute;
    [SerializeField] private Upgrade _thornDamage;
    [SerializeField] private Upgrade _lifesteal;
    [SerializeField] private Upgrade _knockbackChance;
    [SerializeField] private Upgrade _knockbackForce;
    [SerializeField] private Upgrade _orbSpeed;
    [SerializeField] private Upgrade _orbs;
    [SerializeField] private Upgrade _shockwaveSize;
    [SerializeField] private Upgrade _shockwaveFrequency;
    [SerializeField] private Upgrade _landmineChance;
    [SerializeField] private Upgrade _landmineDamage;
    [SerializeField] private Upgrade _landmineRadius;
    [SerializeField] private Upgrade _deathDefy;
    [SerializeField] private Upgrade _wallHealth;
    [SerializeField] private Upgrade _wallRebuild;
    // utility upgrades
    [SerializeField] private Upgrade _cashBonus;
    [SerializeField] private Upgrade _cashPerWave;
    [SerializeField] private Upgrade _coinsPerKill;
    [SerializeField] private Upgrade _coinsPerWave;
    [SerializeField] private Upgrade _freeAttackUpgrades;
    [SerializeField] private Upgrade _freeDefenseUpgrades;
    [SerializeField] private Upgrade _freeUtilityUpgrades;
    [SerializeField] private Upgrade _interestPerWave;
    [SerializeField] private Upgrade _recoveryAmount;
    [SerializeField] private Upgrade _maxRecovery;
    [SerializeField] private Upgrade _packageChance;
    [SerializeField] private Upgrade _enemyAttackLevelSkip;
    [SerializeField] private Upgrade _enemyHealthLevelSkip;
}
