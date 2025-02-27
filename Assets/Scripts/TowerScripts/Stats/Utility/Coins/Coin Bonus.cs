using UnityEngine;

public class CoinBonus : Stat
{
    [SerializeField] private Card _coinsCard;                   // permanant
    [SerializeField] private Stat _coinsCardValue;              // permanant
    [SerializeField] private ThemeManager _themeManager;        // permanant
    [SerializeField] private Pack _disableAds;                  // permanant
    [SerializeField] private Pack _starterPack;                 // permanant
    [SerializeField] private Pack _epicPack;                    // permanant
    [SerializeField] private ModuleSlot _moduleSlot;            // permanant

    [SerializeField] private Perk _allCoinsBonusMulti;          // in round
    [SerializeField] private Perk _moreCoinsLessTowerHealth;    // in round

    // Ultimate Weapon Bonuses
    [SerializeField] private Stat _blackHoleCoinBonus;
    [SerializeField] private Stat _deathWaveCoinBonus;
    [SerializeField] private Stat _spotlightCoinBonus;
    [SerializeField] private Stat _goldenTowerMultiplier;
    [SerializeField] private UltimateWeapon _blackHole;
    [SerializeField] private UltimateWeapon _deathWave;
    [SerializeField] private UltimateWeapon _spotlight;
    [SerializeField] private UltimateWeapon _goldenTower;

    //tier

    private void Update()
    {
        ResetValues();
        UpdateBase();
        PermanentBuffs();
        InRoundBuffs();
        ConditionalBuffs();
        CreateDescriptions();
    }

    private void PermanentBuffs()
    {
        _multiplier *= _enhancement.Value;
        _multiplier *= (1 + _relicManager.CoinBonus);
        _multiplier *= (1 + _themeManager.TotalBonus);
        if (_moduleSlot.EquippedModule != _moduleSlot.ModuleList[0]) _multiplier *= _moduleSlot.Value;
        if (_disableAds.IsOn) _multiplier *= _disableAds.Value;
        if (_starterPack.IsOn) _multiplier *= _starterPack.Value;
        if (_epicPack.IsOn) _multiplier *= _epicPack.Value;
        if (_coinsCard.IsEquipped) _multiplier *= _coinsCardValue.Value;

        CreateValue();
    }

    private void InRoundBuffs()
    {
        if (!_allCoinsBonusMulti.IsBanned)
            _multiplier *= _allCoinsBonusMulti.Value; //check if banned

        if (!_moreCoinsLessTowerHealth.IsBanned)
            _multiplier *= _moreCoinsLessTowerHealth.Value;

        CreateInRoundValue();
    }

    private void ConditionalBuffs()
    {
        if (_blackHole.IsOn) _multiplier *= _blackHoleCoinBonus.Value;
        if (_deathWave.IsOn) _multiplier *= _deathWaveCoinBonus.Value;
        if (_spotlight.IsOn) _multiplier *= _spotlightCoinBonus.Value;
        if (_goldenTower.IsOn) _multiplier *= _goldenTowerMultiplier.Value;
        CreateConditionalValue();
    }

    private void UpdateBase()
    {
        _base = 1;
    }
}
