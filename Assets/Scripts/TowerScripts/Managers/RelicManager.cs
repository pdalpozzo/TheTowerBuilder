using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    private float _towerDamage = 0f;
    private float _attackSpeed = 0f;
    private float _critChance = 0f;
    private float _critFactor = 0f;
    private float _range = 0f;
    private float _damagePerMeter = 0f;
    private float _superCritChance = 0f;
    private float _superCritFactor = 0f;

    private float _towerHealth = 0f;
    private float _healthRegen = 0f;
    private float _defenseAbsolute = 0f;
    private float _deathDefy = 0f;
    private float _wallHealth = 0f;
    private float _wallRebuild = 0f;

    private float _coinBonus = 0f;
    private float _freeAttackUpgrade = 0f;
    private float _freeDefenseUpgrade = 0f;
    private float _freeUtilityUpgrade = 0f;
    private float _recoveryAmount = 0f;
    private float _maxRecovery = 0f;
    private float _packageChance = 0f;
    private float _enemyAttackLevelSkip = 0f;
    private float _enemyHealthLevelSkip = 0f;

    private float _labSpeed = 0f;
    private float _botRange = 0f;
    private float _ultimateDamage = 0f;

    // rare relics
    [SerializeField] private Relic[] _rare;
    // epic relics
    [SerializeField] private Relic[] _epic;
    // legendary relics
    [SerializeField] private Relic[] _legendary;

    public float TowerDamage { get { return _towerDamage; } }
    public float AttackSpeed { get { return _attackSpeed; } }
    public float CritChance { get { return _critChance; } }
    public float CritFactor { get { return _critFactor; } }
    public float Range { get { return _range; } }
    public float DamagePerMeter { get { return _damagePerMeter; } }
    public float SuperCritChance {  get { return _superCritChance; } }
    public float SuperCritFactor {  get { return _superCritFactor; } }

    public float TowerHealth { get { return _towerHealth; } }
    public float HealthRegen {  get { return _healthRegen; } }
    public float DefenseAbsolute { get { return _defenseAbsolute; } }
    public float DeathDefy {  get { return _deathDefy; } }
    public float WallHealth { get { return _wallHealth; } }
    public float WallRebuild { get { return _wallHealth; } }

    public float CoinBonus { get { return _coinBonus; } }
    public float FreeAttackUpgrade { get { return _freeAttackUpgrade; } }
    public float FreeDefenseUpgrade { get { return _freeDefenseUpgrade; } }
    public float FreeUtilityUpgrade { get { return _freeUtilityUpgrade; } }
    public float RecoveryAmount { get { return _recoveryAmount; } }
    public float MaxRecovery { get { return _maxRecovery; } }
    public float PackageChance { get { return _packageChance; } }
    public float EnemeyAttackLevelSkip { get { return _enemyAttackLevelSkip; } }
    public float EnemeyHealthLevelSkip { get { return _enemyHealthLevelSkip; } }

    public float LabSpeed { get { return _labSpeed; } }
    public float BotRange { get { return _botRange; } }
    public float UltimateDamage { get { return _ultimateDamage; } }

    private void Awake()
    {
        EventManager.OnRelicStatusChange += RelicStatusChange;   // triggered by relic
    }

    private void Start()
    {
        UpdateBonuses(_rare);
        UpdateBonuses(_epic);
        UpdateBonuses(_legendary);
    }

    private void RelicStatusChange()
    {
        _towerDamage = 0f;
        _attackSpeed = 0f;
        _critChance = 0f;
        _critFactor = 0f;
        _range = 0f;
        _damagePerMeter = 0f;
        _superCritChance = 0f;
        _superCritFactor = 0f;

        _towerHealth = 0f;
        _healthRegen = 0f;
        _defenseAbsolute = 0f;
        _deathDefy = 0f;
        _wallHealth = 0f;
        _wallRebuild = 0f;

        _coinBonus = 0f;
        _freeAttackUpgrade = 0f;
        _freeDefenseUpgrade = 0f;
        _freeUtilityUpgrade = 0f;
        _recoveryAmount = 0f;
        _maxRecovery = 0f;
        _packageChance = 0f;
        _enemyAttackLevelSkip = 0f;
        _enemyHealthLevelSkip = 0f;

        _labSpeed = 0f;
        _botRange = 0f;
        _ultimateDamage = 0f;

        UpdateBonuses(_rare);
        UpdateBonuses(_epic);
        UpdateBonuses(_legendary);

        EventManager.RelicBonusChange();
    }

    private void UpdateBonuses(Relic[] list)
    {
        foreach (Relic item in list)
        {
            if (!item.IsOn) continue;
            switch (item.Type)
            {
                case RelicType.DAMAGE:
                    _towerDamage += item.Value;
                    break;
                case RelicType.ATTACK_SPEED:
                    _attackSpeed += item.Value;
                    break;
                case RelicType.CRIT_CHANCE:
                    _critChance += item.Value;
                    break;
                case RelicType.CRIT_FACTOR:
                    _critFactor += item.Value;
                    break;
                case RelicType.RANGE:
                    _range += item.Value;
                    break;
                case RelicType.DAMAGE_PER_METER:
                    _damagePerMeter += item.Value;
                    break;
                case RelicType.SUPER_CRIT_CHANCE:
                    _superCritChance += item.Value;
                    break;
                case RelicType.SUPER_CRIT_MULTI:
                    _superCritFactor += item.Value;
                    break;
                case RelicType.HEALTH:
                    _towerHealth += item.Value;
                    break;
                case RelicType.HEALTH_REGEN:
                    _healthRegen += item.Value;
                    break;
                case RelicType.DEFENSE_ABSOLUTE:
                    _defenseAbsolute += item.Value;
                    break;
                case RelicType.DEATH_DEFY:
                    _deathDefy += item.Value;
                    break;
                case RelicType.WALL_HEALTH:
                    _wallHealth += item.Value;
                    break;
                case RelicType.WALL_REBUILD:
                    _wallRebuild += item.Value;
                    break;
                case RelicType.COINS:
                    _coinBonus += item.Value;
                    break;
                case RelicType.FREE_ATTACK_UPGRADE:
                    _freeAttackUpgrade += item.Value;
                    break;
                case RelicType.FREE_DEFENSE_UPGRADE:
                    _freeDefenseUpgrade += item.Value;
                    break;
                case RelicType.FREE_UTILITY_UPGRADE:
                    _freeUtilityUpgrade += item.Value;
                    break;
                case RelicType.RECOVERY_AMOUNT:
                    _recoveryAmount += item.Value;
                    break;
                case RelicType.MAX_RECOVERY:
                    _maxRecovery += item.Value;
                    break;
                case RelicType.PACKAGE_CHANCE:
                    _packageChance += item.Value;
                    break;
                case RelicType.ENEMY_ATTACK_LEVEL_SKIP:
                    _enemyAttackLevelSkip += item.Value;
                    break;
                case RelicType.ENEMY_HEALTH_LEVEL_SKIP:
                    _enemyHealthLevelSkip += item.Value;
                    break;
                case RelicType.LAB_SPEED:
                    _labSpeed += item.Value;
                    break;
                case RelicType.BOT_RANGE:
                    _botRange += item.Value;
                    break;
                case RelicType.ULTIMATE_DAMAGE:
                    _ultimateDamage += item.Value;
                    break;
                default:
                    break;
            }
        }
    }

    public void ForceAll(bool isOn)
    {
        ChangeActiveList(_rare, isOn);
        ChangeActiveList(_epic, isOn);
        ChangeActiveList(_legendary, isOn);
    }

    private void ChangeActiveList(Relic[] list, bool isOn)
    {
        foreach (Relic item in list)
        {
            item.ChangeActive(isOn);
        }
    }

    //public void SetAdditionalLabSpeed(float additional)
    //{
    //    _additionalLabSpeed = additional;
    //    RelicStatusChange();
    //}
}
