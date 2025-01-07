using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabManager : MonoBehaviour
{
    // main reserach
    [SerializeField] private Lab _gameSpeed;
    [SerializeField] private Lab _startingCash;
    [SerializeField] private Lab _workshopAttackDiscount;
    [SerializeField] private Lab _workshopDefenseDiscount;
    [SerializeField] private Lab _workshopUtiliyDiscount;
    [SerializeField] private Lab _labsCoinDiscount;
    [SerializeField] private Lab _labSpeed;
    [SerializeField] private Lab _buyMultiplier;
    [SerializeField] private Lab _moreRoundStats;
    [SerializeField] private Lab _targetPriority;
    [SerializeField] private Lab _cardPresets;
    [SerializeField] private Lab _workshopRespec;
    [SerializeField] private Lab _rerollDailyMissions;
    [SerializeField] private Lab _workshopEnhancement;
    // attack reserach
    [SerializeField] private Lab _damage;
    [SerializeField] private Lab _attackSpeed;
    [SerializeField] private Lab _criticalFactor;
    [SerializeField] private Lab _range;
    [SerializeField] private Lab _damagePerMeter;
    [SerializeField] private Lab _superCritChance;
    [SerializeField] private Lab _superCritMulti;
    [SerializeField] private Lab _maxRendArmorMultiplier;
    [SerializeField] private Lab _lightSpeedShots;
    // defense reserach
    [SerializeField] private Lab _health;
    [SerializeField] private Lab _healthRegen;
    [SerializeField] private Lab _defenseAbsolute;
    [SerializeField] private Lab _defensePct;
    [SerializeField] private Lab _orbSpeed;
    [SerializeField] private Lab _landMineDamage;
    [SerializeField] private Lab _landMineDecay;
    [SerializeField] private Lab _shockwaveSize;
    [SerializeField] private Lab _orbBossHit;
    [SerializeField] private Lab _wallHealth;
    [SerializeField] private Lab _wallRebuild;
    [SerializeField] private Lab _wallRegen;
    [SerializeField] private Lab _wallThorn;
    [SerializeField] private Lab _wallInvincibility;
    [SerializeField] private Lab _wallFortification;
    // utility reserach
    [SerializeField] private Lab _cashBonus;
    [SerializeField] private Lab _cashPerWave;
    [SerializeField] private Lab _coinsPerKillBonus;
    [SerializeField] private Lab _coinsPerWave;
    [SerializeField] private Lab _interest;
    [SerializeField] private Lab _maxInterest;
    [SerializeField] private Lab _packageAfterBoss;
    [SerializeField] private Lab _recoveryPackageAmount;
    [SerializeField] private Lab _recoveryPackageMax;
    [SerializeField] private Lab _recoveryPackageChance;
    [SerializeField] private Lab _enemyAttackLevelSkip;
    [SerializeField] private Lab _enemyHealthLevelSkip;
    // ultimate weapon reserach
    [SerializeField] private Lab _missilesDespawnTime;
    [SerializeField] private Lab _missilesExplosion;
    [SerializeField] private Lab _missilesRadius;
    [SerializeField] private Lab _chronoFieldDuration;
    [SerializeField] private Lab _chronoFieldDamageReduction;
    [SerializeField] private Lab _chronoFieldReductionPct;
    [SerializeField] private Lab _swampRadius;
    [SerializeField] private Lab _swampStun;
    [SerializeField] private Lab _swampStunChance;
    [SerializeField] private Lab _swampStunTime;
    [SerializeField] private Lab _goldenTowerBonus;
    [SerializeField] private Lab _goldenTowerDuration;
    [SerializeField] private Lab _chainLightningShock;
    [SerializeField] private Lab _shockChance;
    [SerializeField] private Lab _shockMultiplier;
    [SerializeField] private Lab _deathWaveHealth;
    [SerializeField] private Lab _deathWaveCoinBonus;
    [SerializeField] private Lab _innerMineBlastRadius;
    [SerializeField] private Lab _innerMineRotationSpeed;
    [SerializeField] private Lab _chronoFieldRange;
    [SerializeField] private Lab _missleAmplifier;
    [SerializeField] private Lab _missileBarrage;
    [SerializeField] private Lab _missileBarrageQuantity;
    [SerializeField] private Lab _innerMineStun;
    [SerializeField] private Lab _blackHoleDamage;
    [SerializeField] private Lab _extraBlackHole;
    [SerializeField] private Lab _blackHoleCoinsBonus;
    [SerializeField] private Lab _spotlightCoinBonus;
    [SerializeField] private Lab _spotlightMissiles;
    [SerializeField] private Lab _blackHoleDisableRangedEnemies;
    [SerializeField] private Lab _rechargeMissileBarrage;
    // card reserach
    [SerializeField] private Lab _secondWindBlast;
    [SerializeField] private Lab _doubleDeathRay;
    [SerializeField] private Lab _extraOrbAdjuster;
    [SerializeField] private Lab _extraExtraOrbs;
    [SerializeField] private Lab _energyShieldExtraHit;
    [SerializeField] private Lab _superTowerBonus;
    [SerializeField] private Lab _rechargeSecondWind;
    [SerializeField] private Lab _rechargeDemonMode;
    [SerializeField] private Lab _rechargeNuke;
    // perk reserach
    [SerializeField] private Lab _unlockPerks;
    [SerializeField] private Lab _wavesRequired;
    [SerializeField] private Lab _autoPickPerks;
    [SerializeField] private Lab _standardPerksBonus;
    [SerializeField] private Lab _perkOptionQuantity;
    [SerializeField] private Lab _firstPerkChoice;
    [SerializeField] private Lab _banPerks;
    [SerializeField] private Lab _improveTradeOffPerks;
    // bot reserach
    [SerializeField] private Lab _flameBotFrequency;
    [SerializeField] private Lab _thunderBotFrequency;
    [SerializeField] private Lab _goldenBotFrequency;
    [SerializeField] private Lab _amplifyBotFrequency;
    // enemies reserach
    [SerializeField] private Lab _commonEnemyHealth;
    [SerializeField] private Lab _commonEnemyAttack;
    [SerializeField] private Lab _fastEnemyHealth;
    [SerializeField] private Lab _fastEnemyAttack;
    [SerializeField] private Lab _fastEnemySpeed;
    [SerializeField] private Lab _tankEnemyHealth;
    [SerializeField] private Lab _tankEnemyAttack;
    [SerializeField] private Lab _rangedEnemyHealth;
    [SerializeField] private Lab _rangedEnemyAttack;
    [SerializeField] private Lab _bossHealth;
    [SerializeField] private Lab _bossAttack;
    [SerializeField] private Lab _protectorHealth;
    [SerializeField] private Lab _protectorRadius;
    [SerializeField] private Lab _protectorDamageReduction;
    // module reserach
    [SerializeField] private Lab _commonDropChance;
    [SerializeField] private Lab _rerollShards;
    [SerializeField] private Lab _dailyMissionShards;
    [SerializeField] private Lab _moduleShardCosts;
    [SerializeField] private Lab _moduleCoinCost;
    [SerializeField] private Lab _rareDropChance;
    [SerializeField] private Lab _unmergeModule;

}
