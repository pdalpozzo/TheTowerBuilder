using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBonus : Stat
{
    [SerializeField] private Card _coinsCard;                   // permanant
    [SerializeField] private ThemeManager _themeManager;        // permanant
    [SerializeField] private Perk _allCoinsBonusMulti;          // in round
    [SerializeField] private Perk _moreCoinsLessTowerHealth;    // in round
    [SerializeField] private Pack _disableAds;                  // permanant
    [SerializeField] private Pack _starterPack;                 // permanant
    [SerializeField] private Pack _epicPack;                    // permanant
    [SerializeField] private ModuleSlot _moduleSlot;            // permanant
    [SerializeField] private RelicManager _relicManager;        // permanant

    // Ultimate Weapon Bonuses
    [SerializeField] private Stat _blackHoleCoinBonus;
    [SerializeField] private Stat _deathWaveCoinBonus;
    [SerializeField] private Stat _spotlightCoinBonus;
    [SerializeField] private Stat _goldenTowerMultiplier;
    private bool _blackHoleIsOn = false;
    private bool _deathWaveIsOn = false;
    private bool _spotlightIsOn = false;
    private bool _goldenTowerIsOn = false;

    //tier

    private float _base = 0;

    private new void Start()
    {
        base.Start();
        EventManager.OnAnyCardChange += UpdateValue;
        EventManager.OnPerkStatusChange += UpdateValue;
        EventManager.OnAnyPackChange += UpdateValue;
        EventManager.OnThemeBonusChange += UpdateValue;
        EventManager.OnRelicBonusChange += UpdateValue;
        //EventManager.OnModuleSlotChange += UpdateValue;
        EventManager.OnAnyStatChange += CoinBonusChanged;
        //EventManager.OnUltimateWeaponStatusChange += UpdateValue;
    }

    private void UpdateValue(Card card)
    {
        if (card == _coinsCard) UpdateValue();
    }

    private void UpdateValue(ModuleSlot slot)
    {
        if (slot == _moduleSlot) UpdateValue();
    }

    private void UpdateValue(Perk perk)
    {
        if (perk == _allCoinsBonusMulti) UpdateValue();
        if (perk == _moreCoinsLessTowerHealth) UpdateValue();
    }

    private void UpdateValue(Pack pack)
    {
        if (pack == _disableAds) UpdateValue();
        if (pack == _starterPack) UpdateValue();
        if (pack == _epicPack) UpdateValue();
    }

    private void CoinBonusChanged(Stat stat)
    {
        if (stat == _blackHoleCoinBonus) UpdateValue();
        if (stat == _deathWaveCoinBonus) UpdateValue();
        if (stat == _spotlightCoinBonus) UpdateValue();
        if (stat == _goldenTowerMultiplier) UpdateValue();
    }

    private void UpdateValue(UltimateWeaponType uwType, bool isOn)
    {
        switch (uwType)
        {
            case UltimateWeaponType.BLACK_HOLE:
                _blackHoleIsOn = isOn;
                break;
            case UltimateWeaponType.DEATH_WAVE:
                _deathWaveIsOn = isOn;
                break;
            case UltimateWeaponType.SPOTLIGHT:
                _spotlightIsOn = isOn;
                break;
            case UltimateWeaponType.GOLDEN_TOWER:
                _goldenTowerIsOn = isOn;
                break;
        }
    }

    protected override void UpdateValue()
    {
        // calculate value
        UpdateBase();
        float additional = 0;
        float multiplier = 1;

        // permanant buffs
        multiplier *= _enhancement.Value;
        //multiplier *= (1 + _moduleSlot.Value);
        multiplier *= (1 + _relicManager.CoinBonus);
        multiplier *= (1 + _themeManager.TotalBonus);
        if (_disableAds.IsOn) multiplier *= _disableAds.Value;
        if (_starterPack.IsOn) multiplier *= _starterPack.Value;
        if (_epicPack.IsOn) multiplier *= _epicPack.Value;
        if (_coinsCard.IsEquipped) multiplier *= _coinsCard.Value;

        _value = multiplier * (_base + additional);

        // in round buffs
        if (!_allCoinsBonusMulti.IsBanned) 
            multiplier *= _allCoinsBonusMulti.Value; //check if banned

        if (!_moreCoinsLessTowerHealth.IsBanned) 
            multiplier *= _moreCoinsLessTowerHealth.Value;

        _inRoundValue = multiplier * (_base + additional);

        // conditional buffs
        if (_blackHoleIsOn) multiplier *= _blackHoleCoinBonus.Value;
        if (_deathWaveIsOn) multiplier *= _deathWaveCoinBonus.Value;
        if (_spotlightIsOn) multiplier *= _spotlightCoinBonus.Value;
        if (_goldenTowerIsOn) multiplier *= _goldenTowerMultiplier.Value;
        _conditionalValue = multiplier * (_base + additional);

        CreateDescriptions();
        EventManager.StatChanged(this);
    }

    private void UpdateBase()
    {
        _base = 1;
    }
}
