using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class RelicMassControl : MonoBehaviour
{
    [SerializeField] private RelicManager _relics;

    [SerializeField] private TextMeshProUGUI _towerDamageText;
    [SerializeField] private TextMeshProUGUI _attackSpeedText;
    [SerializeField] private TextMeshProUGUI _critChanceText;
    [SerializeField] private TextMeshProUGUI _critFactorText;
    //[SerializeField] private TextMeshProUGUI _rangeText;
    [SerializeField] private TextMeshProUGUI _damagePerMeterText;
    [SerializeField] private TextMeshProUGUI _superCritChanceText;
    //[SerializeField] private TextMeshProUGUI _superCritFactorText;

    [SerializeField] private TextMeshProUGUI _towerHealthText;
    //[SerializeField] private TextMeshProUGUI _healthRegenText;
    [SerializeField] private TextMeshProUGUI _defenseAbsoluteText;
    //[SerializeField] private TextMeshProUGUI _deathDefyText;
    //[SerializeField] private TextMeshProUGUI _wallHealthText;
    //[SerializeField] private TextMeshProUGUI _wallRebuildText;

    [SerializeField] private TextMeshProUGUI _coinBonusText;
    [SerializeField] private TextMeshProUGUI _freeAttackUpgradeText;
    [SerializeField] private TextMeshProUGUI _freeDefenseUpgradeText;
    //[SerializeField] private TextMeshProUGUI _freeUtilityUpgradeText;
    //[SerializeField] private TextMeshProUGUI _recoveryAmountText;
    //[SerializeField] private TextMeshProUGUI _maxRecoveryText;
    //[SerializeField] private TextMeshProUGUI _packageChanceText;
    //[SerializeField] private TextMeshProUGUI _enemyAttackLevelSkipText;
    //[SerializeField] private TextMeshProUGUI _enemyHealthLevelSkipText;

    [SerializeField] private TextMeshProUGUI _labSpeedText;
    [SerializeField] private TextMeshProUGUI _botRangeText;
    [SerializeField] private TextMeshProUGUI _ultimateDamageText;

    private void Awake()
    {
        EventManager.OnRelicBonusChange += UpdateVisuals;   // triggered by relic manager
    }

    private void Start()
    {
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        int decimals = 0;
        StringFormatType format = StringFormatType.PERCENT;

        _towerDamageText.text = GetStringFormat(_relics.TowerDamage, format, decimals);
        _attackSpeedText.text = GetStringFormat(_relics.AttackSpeed, format, decimals);
        _critChanceText.text = GetStringFormat(_relics.CritChance, format, decimals);
        _critFactorText.text = GetStringFormat(_relics.CritFactor, format, decimals);
        //_rangeText.text = GetStringFormat(_relics.Range, format, decimals);
        _damagePerMeterText.text = GetStringFormat(_relics.DamagePerMeter, format, decimals);
        _superCritChanceText.text = GetStringFormat(_relics.SuperCritChance, format, decimals);
        //_superCritFactorText.text = GetStringFormat(_relics.SuperCritFactor, format, decimals);

        _towerHealthText.text = GetStringFormat(_relics.TowerHealth, format, decimals);
        //_healthRegenText.text = GetStringFormat(_relics.HealthRegen, format, decimals);
        _defenseAbsoluteText.text = GetStringFormat(_relics.DefenseAbsolute, format, decimals);
        //_deathDefyText.text = GetStringFormat(_relics.DeathDefy, format, decimals);
        //_wallHealthText.text = GetStringFormat(_relics.WallHealth, format, decimals);
        //_wallRebuildText.text = GetStringFormat(_relics.WallRebuild, format, decimals);

        _coinBonusText.text = GetStringFormat(_relics.CoinBonus, format, decimals);
        _freeAttackUpgradeText.text = GetStringFormat(_relics.FreeAttackUpgrade, format, decimals);
        _freeDefenseUpgradeText.text = GetStringFormat(_relics.FreeDefenseUpgrade, format, decimals);
        //_freeUtilityUpgradeText.text = GetStringFormat(_relics.FreeUtilityUpgrade, format, decimals);
        //_recoveryAmountText.text = GetStringFormat(_relics.RecoveryAmount, format, decimals);
        //_maxRecoveryText.text = GetStringFormat(_relics.MaxRecovery, format, decimals);
        //_packageChanceText.text = GetStringFormat(_relics.PackageChance, format, decimals);
        //_enemyAttackLevelSkipText.text = GetStringFormat(_relics.EnemeyAttackLevelSkip, format, decimals);
        //_enemyHealthLevelSkipText.text = GetStringFormat(_relics.EnemeyHealthLevelSkip, format, decimals);

        _labSpeedText.text = GetStringFormat(_relics.LabSpeed, format, decimals);
        _botRangeText.text = GetStringFormat(_relics.BotRange, StringFormatType.DISTANCE, decimals);
        _ultimateDamageText.text = GetStringFormat(_relics.UltimateDamage, format, decimals);
    }

    public void AllOn()
    {
        _relics.ForceAll(true);
    }

    public void AllOff()
    {
        _relics.ForceAll(false);
    }

    //private float GetInput(TMP_InputField inputField)
    //{
    //    int input = 0;
    //    if (inputField.text != null) input = int.Parse(inputField.text);
    //    if (input < 0) input = 0;
    //    inputField.text = input.ToString();
    //    float percent = (float)input / 100;
    //    return percent;
    //}

    //public void SetAdditionalLabSpeed()
    //{
    //    float input = GetInput(_additionalLabSpeedInput);
    //    _relics.SetAdditionalLabSpeed(input);
    //}

    private string GetStringFormat(float value, StringFormatType format, int decimalPlaces)
    {
        return StringFormating.Format(value, format, decimalPlaces);
    }
}
