using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    [SerializeField] private float _labSpeed = 0f;
    [SerializeField] private float _towerDamage = 0f;
    [SerializeField] private float _critFactor = 0f;
    [SerializeField] private float _damagePerMeter = 0f;
    [SerializeField] private float _towerHealth = 0f;
    [SerializeField] private float _defenseAbsolute = 0f;
    [SerializeField] private float _coinBonus = 0f;

    // rare relics
    [SerializeField] private Relic[] _rare;

    // epic relics
    [SerializeField] private Relic[] _epic;

    // legendary relics
    [SerializeField] private Relic[] _legendary;

    private float _additionalLabSpeed = 0f;
    private float _additionalTowerDamage = 0f;
    private float _additionalCritFactor = 0f;
    private float _additionalDamagePerMeter = 0f;
    private float _additionalTowerHealth = 0f;
    private float _additionalDefenseAbsolute = 0f;
    private float _additionalCoinBonus = 0f;

    public float LabSpeed { get { return _labSpeed; } }
    public float TowerDamage { get { return _towerDamage; } }
    public float CritFactor { get { return _critFactor; } }
    public float DamagePerMeter { get { return _damagePerMeter; } }
    public float TowerHealth { get { return _towerHealth; } }
    public float DefenseAbsolute { get { return _defenseAbsolute; } }
    public float CoinBonus { get { return _coinBonus; } }

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
        _labSpeed = 0f + _additionalLabSpeed;
        _towerDamage = 0f + _additionalTowerDamage;
        _critFactor = 0f + _additionalCritFactor;
        _damagePerMeter = 0f + _additionalDamagePerMeter;
        _towerHealth = 0f + _additionalTowerHealth;
        _defenseAbsolute = 0f + _additionalDefenseAbsolute;
        _coinBonus = 0f + _additionalCoinBonus;

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
                case RelicType.CRIT_FACTOR:
                    _critFactor += item.Value;
                    break;
                case RelicType.DAMAGE_PER_METER:
                    _damagePerMeter += item.Value;
                    break;
                case RelicType.HEALTH:
                    _towerHealth += item.Value;
                    break;
                case RelicType.DEFENSE_ABSOLUTE:
                    _defenseAbsolute += item.Value;
                    break;
                case RelicType.COINS:
                    _coinBonus += item.Value;
                    break;
                default:
                    _labSpeed += item.Value;
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

    public void SetAdditionalLabSpeed(float additional)
    {
        _additionalLabSpeed = additional;
        RelicStatusChange();
    }

    public void SetAdditionalTowerDamage(float additional)
    {
        _additionalTowerDamage = additional;
        RelicStatusChange();
    }

    public void SetAdditionalCritFactor(float additional)
    {
        _additionalCritFactor = additional;
        RelicStatusChange();
    }

    public void SetAdditionalDamagePerMeter(float additional)
    {
        _additionalDamagePerMeter = additional;
        RelicStatusChange();
    }

    public void SetAdditionalTowerHealth(float additional)
    {
        _additionalTowerHealth = additional;
        RelicStatusChange();
    }

    public void SetAdditionalDefenseAbsolute(float additional)
    {
        _additionalDefenseAbsolute = additional;
        RelicStatusChange();
    }

    public void SetAdditionalCoinBonus(float additional)
    {
        _additionalCoinBonus = additional;
        RelicStatusChange();
    }
}
