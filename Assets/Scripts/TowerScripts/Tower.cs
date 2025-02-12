using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour
{
    private string[] _thousandSymbols = { "", "K", "M", "B", "T", "q", "Q", "s", "S", "o", "n", "d", "u", "D" };
    // current values
    //private float _averageHitMinRange = 0;          // single hit at min range, not including crit
    //private float _averageHitMaxRange = 0;          // single hit at max range, not including crit
    //private float _damageMultiplier = 1;            // damage multiplier from all sources, affects all damage
    //private float _projectileDamageMultiplier = 1;  // projetile damage multiplier from all sources, only affects projectile damage
    //private float _critDamageMultiplier = 1;        // crit damage multiplier from all sources
    //private float _superCritDamageMultiplier = 1;   // super crit damage multiplier from all sources

    //private float _basicHit = 0;                    // basic hit damage
    //private float _critHit = 0;                     // crit damage
    //private float _superCritHit = 0;                // super crit damage
    //private float _averageDamage = 0;               // hit at max range, including crit, super crit, bounce shot, rapid fire, multishot
    //private float _averageDamagePerSecond = 0;      // dps, including crit
    //private float _rapidFireUptime = 0;             // rapid fire uptime (rough)
    //private float _totalAttackSpeed = 0;            // total attack speed

    //private float _totalDamageReducation = 0;       // total damage reduction
    //private float _totalDefenseAbsolute = 0;        // total defense absolute value
    //private float _maxNoDamageHit = 0;              // the max hit the tower can take without taking damage
    //private float _maxSurvivableHit = 0;            // the max hit the tower can take considering health, recovery amount and damage reduction
    //private float _wallMaxSurvivableHit = 0;        // the max hit the wall can take considering wall health and wall fortification

    //[SerializeField] private GameObject _finalCalculationPanel;
    //[SerializeField] private GameObject _calculationPrefab;
    //private List<GameObject> _calculations;
    // attack calculations
    //[SerializeField] private Calculation _maxRangeCalc;
    //[SerializeField] private Calculation _basicHitCalc;
    //[SerializeField] private Calculation _criticalChanceCalc;
    //[SerializeField] private Calculation _criticalHitCalc;
    //[SerializeField] private Calculation _superCritChanceCalc;
    //[SerializeField] private Calculation _superCritHitCalc;
    //[SerializeField] private Calculation _averageHitCalc;
    //// attack speed calculations
    //[SerializeField] private Calculation _attackSpeedCalc;
    //[SerializeField] private Calculation _averageDPSCalc;
    //[SerializeField] private Calculation _rapidFireUptimeCalc;
    //// defense calculations
    //[SerializeField] private Calculation _defensePctCalc;
    //[SerializeField] private Calculation _defenseAbsoluteCalc;
    //[SerializeField] private Calculation _chronoFieldDRCalc;
    //[SerializeField] private Calculation _totalDamageReductionCalc;
    //[SerializeField] private Calculation _maxSurvivableHitCalc;
    //[SerializeField] private Calculation _wallMaxSurvivableHitCalc;


    [SerializeField] private BotManager _bots;
    [SerializeField] private CardManager _cards;
    [SerializeField] private EnhancementManager _enhancements;
    [SerializeField] private LabManager _labs;
    [SerializeField] private ModuleManager _modules;
    [SerializeField] private PackManager _packs;
    [SerializeField] private PerkManager _perks;
    [SerializeField] private RelicManager _relics;
    [SerializeField] private ThemeManager _themes;
    [SerializeField] private UltimateWeaponManager _ultimateWeapons;
    [SerializeField] private UpgradeManager _upgrades;

    [SerializeField] private Stat[] _damageStats;
    [SerializeField] private Stat[] _defenseStats;
    [SerializeField] private Stat[] _utilityStats;

    //void Update()
    //{

    //}

    void Update()
    {
        DamageCalculations();
        DefenseCalculations();

        UpdateDisplays();
    }

    private string GetLargeNumber(float value)
    {
        int counter = 0;
        while (value > 999)
        {
            value /= 1000;
            counter++;
        }
        return value.ToString("F2") + _thousandSymbols[counter];
    }
    
    private void UpdateDisplays()
    {
        //_maxRangeCalc.Value.text = _range.Value.ToString("F2") + "m";
        //_basicHitCalc.Value.text = GetLargeNumber(_basicHit);
        //_criticalChanceCalc.Value.text = _criticalChance.Value.ToString("P1");
        //_criticalHitCalc.Value.text = GetLargeNumber(_critHit);
        //_superCritChanceCalc.Value.text = _superCriticalChance.Value.ToString("P1");
        //_superCritHitCalc.Value.text = GetLargeNumber(_superCritHit);
        //_averageHitCalc.Value.text = GetLargeNumber(_averageDamage);

        //_attackSpeedCalc.Value.text = _totalAttackSpeed.ToString("F2");
        //_averageDPSCalc.Value.text = GetLargeNumber(_averageDamagePerSecond);
        //_rapidFireUptimeCalc.Value.text = _rapidFireUptime.ToString("P1");

        //_defensePctCalc.Value.text = _defensePct.Value.ToString("P1");
        //_defenseAbsoluteCalc.Value.text = GetLargeNumber(_defenseAbsolute.Value);
        //_chronoFieldDRCalc.Value.text = "25%";

        //_totalDamageReductionCalc.Value.text = _totalDamageReducation.ToString("P1");
        //_maxSurvivableHitCalc.Value.text = GetLargeNumber(_maxSurvivableHit);
        //_wallMaxSurvivableHitCalc.Value.text = GetLargeNumber(_wallMaxSurvivableHit);
    }

    private void DamageCalculations()
    {
        CalculateDamageMultipliers();
        CalculateAverageHit();
        CalculateAttackSpeed();
    }

    private void CalculateDamageMultipliers()
    {
        // BASE DAMAGE MULTIPLIER
        // example      x4   * x1.2        * (1 + 35%)   * (1 + 73%)    * 1.68 * 1   = 4 * 1.2 * 1.35 * 1.73 * 1.68 * 1 = 18.833472 = 1883.35%
        // multiplier = card * enhancement * (1 + relic) * (1 + module) * lab * perk
        //_damageMultiplier = 1;                                              // base
        //if (_damageCard.IsEquipped) _damageMultiplier *= _damageCard.Value; // card
        //_damageMultiplier *= _damageEnhancement.Value;                      // enhancement
        // relic
        // module
        // lab
        // perk x1.8 damage

        //if (_berserkCard.IsEquipped) _damageMultiplier *= _berserkCard.Value;
        //if (_demonModeCard.IsEquipped) _damageMultiplier *= _demonModeCard.Value;
        // spotlight multiplier
        // chain ligthning shock adds multiplier
        // perk spotlight damage x1.5
        // spotlight sub module effect
        // trade off perk -enemey damage for -damage
        // trade off perk +damage for +boss health
        // has amplify bot damage bonus

        //_projectileDamageMultiplier = _damageMultiplier;
        //if (_superTowerCard.IsEquipped) _projectileDamageMultiplier *= _superTowerCard.Value;

        // CRIT DAMAGE MULTIPLIER
        //_critDamageMultiplier = 1 * _criticalFactor.Value * _criticalFactorEnhancement.Value;
        // has relic bonus
        // has lab bonus
        

        // SUPER CRIT DAMAGE MULTIPLIER
        //_superCritDamageMultiplier = 1 * _critDamageMultiplier * _superCriticalMulti.Value * _superCritMultiEnhancement.Value;
        // has lab bonus
    }

    private void CalculateAverageHit()
    {
        // range has a card
        // damage per meter has relic bonus
        // AVERAGE HIT RANGES
        //_averageHitMinRange = _damage.Value * _projectileDamageMultiplier * ((1 + _damagePerMeter.Value) * _range.BaseValue);     // minimum range set to 1
        //_averageHitMaxRange = _damage.Value * _projectileDamageMultiplier * ((1 + _damagePerMeter.Value) * _range.Value);         // maximum range given from range value
        
        // HIT FOR DAMAGE TYPES
        //_basicHit = _averageHitMaxRange;
        //_critHit = _averageHitMaxRange * _critDamageMultiplier;
        //_superCritHit = _averageHitMaxRange * _superCritDamageMultiplier;

        //float baseHitChance, critHitChance, superCritHitChance = 0;

        //critHitChance = _criticalChance.Value;
        //if (_criticalChanceCard.IsEquipped) critHitChance += _criticalChanceCard.Value;
        // has module sub effect


        //baseHitChance = 1 - critHitChance;
        //superCritHitChance = critHitChance * _superCriticalChance.Value; 
        // has lab for super crit chance

        //critHitChance = critHitChance - superCritHitChance;

        //_averageDamage = (_basicHit * baseHitChance) + (_critHit * critHitChance) + (_superCritHit * superCritHitChance);
    }

    private void CalculateAttackSpeed()
    {

        // AVERAGE DAMAGE PER SECOND
        //_totalAttackSpeed = _attackSpeed.Value * _attackSpeedEnhancement.Value;
        //if (_attackSpeedCard.IsEquipped ) _totalAttackSpeed *= _attackSpeedCard.Value;
        // has module sub effect, rapid fire 

        // very rough calculations because probability doesnt work like that
        //_rapidFireUptime = (_rapidFireChance.Value * _totalAttackSpeed);
        //if (_rapidFireUptime > 1) _rapidFireUptime = 1;

        //_averageDamagePerSecond = (_averageDamage * _totalAttackSpeed * (1 - _rapidFireUptime)) + (_averageDamage * _totalAttackSpeed * _rapidFireUptime);
    }

    private void DefenseCalculations()
    {
        CalculateDamageReduction();
        CalculateSurvivableHits();
    }

    private void CalculateDamageReduction()
    {
        // TOWER DAMAGE REDUCTION
        //defense %
        //chrono field reduction
        
        //float chronofieldReduction = 0.25f; // 25% is max
        //float cappedDefPct = _defensePct.Value; 
        // has module sub effect
        // has lab
        //if (_extraDefenseCard.IsEquipped) cappedDefPct += _extraDefenseCard.Value;

        //// capped at 98%
        //if (cappedDefPct > 0.98f) cappedDefPct = 0.98f;

        //_totalDamageReducation = cappedDefPct + ((1 - cappedDefPct) * chronofieldReduction);
    }

    private void CalculateSurvivableHits()
    {
        //_totalDefenseAbsolute = _defenseAbsolute.Value * _defenseAbsoluteEnhancement.Value;
        //// has relic
        //// has module sub effect
        //// has lab
        //if (_fortressCard.IsEquipped) _totalDefenseAbsolute *= _fortressCard.Value;

        //// noDamageHit = defAbs / (1 - totalDR)
        //_maxNoDamageHit = _totalDefenseAbsolute / (1 - _totalDamageReducation);


        //// TOWER MAX SURVIVABLE HIT
        ////health
        //float maxHealth = _health.Value * _healthEnhancement.Value ;
        //if (_healthCard.IsEquipped) maxHealth *= _healthCard.Value;
        //// has relics
        //// has lab
        //// has perks
        //// has module
        //// has death wave health bonus from lab

        //float healthAtMaxRecovery = maxHealth * (1 + _maxRecovery.Value);
        //_maxSurvivableHit = healthAtMaxRecovery + _maxNoDamageHit;

        //// WALL MAX SURVIVABLE HIT
        ////wall health
        //float maxWallHealth = maxHealth * _wallHealth.Value * _wallHealthEnhancement.Value;
        //// has lab
        //// has sub module effect

        ////wall fortification lab
        //float wallFortification = 12f; // 1200% is max
        //float wallHealthAtMaxFortification = maxWallHealth * (1 + wallFortification);
        //_wallMaxSurvivableHit = wallHealthAtMaxFortification;

    }

}

