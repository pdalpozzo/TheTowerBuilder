using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class RelicMassControl : MonoBehaviour
{
    [SerializeField] private RelicManager _relics;

    [SerializeField] private TMP_InputField _additionalLabSpeedInput;
    [SerializeField] private TMP_InputField _additionalTowerDamageInput;
    [SerializeField] private TMP_InputField _additionalCritFactorInput;
    [SerializeField] private TMP_InputField _additionalDamagePerMeterInput;
    [SerializeField] private TMP_InputField _additionalTowerHealthInput;
    [SerializeField] private TMP_InputField _additionalDefenseAbsoluteInput;
    [SerializeField] private TMP_InputField _additionalCoinBonusInput;

    [SerializeField] private TextMeshProUGUI _labSpeedText;
    [SerializeField] private TextMeshProUGUI _towerDamageText;
    [SerializeField] private TextMeshProUGUI _critFactorText;
    [SerializeField] private TextMeshProUGUI _damagePerMeterText;
    [SerializeField] private TextMeshProUGUI _towerHealthText;
    [SerializeField] private TextMeshProUGUI _defenseAbsoluteText;
    [SerializeField] private TextMeshProUGUI _coinBonusText;

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
        _labSpeedText.text = StringFormating.Format(_relics.LabSpeed, format, decimals);
        _towerDamageText.text = StringFormating.Format(_relics.TowerDamage, format, decimals);
        _critFactorText.text = StringFormating.Format(_relics.CritFactor, format, decimals);
        _damagePerMeterText.text = StringFormating.Format(_relics.DamagePerMeter, format, decimals);
        _towerHealthText.text = StringFormating.Format(_relics.TowerHealth, format, decimals);
        _defenseAbsoluteText.text = StringFormating.Format(_relics.DefenseAbsolute, format, decimals);
        _coinBonusText.text = StringFormating.Format(_relics.CoinBonus, format, decimals);
    }

    private float GetInput(TMP_InputField inputField)
    {
        int input = 0;
        if (inputField.text != null) input = int.Parse(inputField.text);
        if (input < 0) input = 0;
        inputField.text = input.ToString();
        float percent = (float)input / 100;
        return percent;
    }

    public void AllOn()
    {
        _relics.ForceAll(true);
    }

    public void AllOff()
    {
        _relics.ForceAll(false);
    }

    public void SetAdditionalLabSpeed()
    {
        float input = GetInput(_additionalLabSpeedInput);
        _relics.SetAdditionalLabSpeed(input);
    }

    public void SetAdditionalTowerDamage()
    {
        float input = GetInput(_additionalTowerDamageInput);
        _relics.SetAdditionalTowerDamage(input);
    }

    public void SetAdditionalCritFactor()
    {
        float input = GetInput(_additionalCritFactorInput);
        _relics.SetAdditionalCritFactor(input);
    }

    public void SetAdditionalDamagePerMeter()
    {
        float input = GetInput(_additionalDamagePerMeterInput);
        _relics.SetAdditionalDamagePerMeter(input);
    }

    public void SetAdditionalTowerHealth()
    {
        float input = GetInput(_additionalTowerHealthInput);
        _relics.SetAdditionalTowerHealth(input);
    }

    public void SetAdditionalDefenseAbsolute()
    {
        float input = GetInput(_additionalDefenseAbsoluteInput);
        _relics.SetAdditionalDefenseAbsolute(input);
    }

    public void SetAdditionalCoinBonus()
    {
        float input = GetInput(_additionalCoinBonusInput);
        _relics.SetAdditionalCoinBonus(input);
    }


}
