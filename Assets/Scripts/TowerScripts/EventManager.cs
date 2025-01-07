using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    // card events
    public static event Action<int, int> OnCardUnlockedLimitChange; // triggered by card manager
    public static event Action OnEquippedCardsChange;               // triggered by card manager
    public static event Action<Card> OnCardSelectionChange;         // triggered by card visual control
    public static event Action<Card> OnAnyCardChange;               // triggered by card
    public static event Action OnCardForceReset;                    // triggered by card mass control
    public static event Action OnCardForceMax;                      // triggered by card mass control

    // ultimate weapon events
    public static event Action<UltimateWeaponType, bool> OnUltimateWeaponStatusChange;  // triggered by ultimate weapon
    public static event Action<bool> OnUltimateWeaponPlusAvailable;                     // triggered by ultimate weapon manager

    // perk events
    public static event Action<Perk> OnPerkBanChange;           // triggered by perk status control
    public static event Action<Perk> OnPerkPriorityChange;      // triggered by perk status control
    public static event Action<Perk> OnPerkStatusChange;        // triggered by perk
    public static event Action<int> OnPerkPresetChange;         // triggered by perk status control
    public static event Action OnPerkPresetUpdate;              // triggered by perk manager
    
    // upgrade events
    public static event Action OnUpgradeForceUnlock;                    // triggered by workshop panel control
    public static event Action OnUpgradeForceReset;                     // triggered by workshop panel control
    public static event Action<UnlockCategory, bool> OnUpgradeUnlock;   // triggered by workshop upgrade display
    public static event Action OnUpgradeForceMax;                       // triggered by workshop upgrade display

    // enhancement events
    public static event Action OnEnhancementForceUnlock;        // triggered by workshop panel control
    public static event Action OnEnhancementForceReset;         // triggered by workshop panel control
    
    // theme events
    public static event Action OnThemeStatusChange;             // triggered by theme
    public static event Action OnThemeBonusChange;              // triggered by theme manager

    // relic events
    public static event Action OnRelicStatusChange;             // triggered by relic
    public static event Action OnRelicBonusChange;              // triggered by relic manager

    // module events
    public static event Action OnModuleRarityChange;            // triggered by module slot
    public static event Action<SubEffect> OnSubEffectChange;    // triggered by sub effect visual control
    public static event Action<ModuleType, bool> OnSubEffectLimitChange;    // triggered by module slot

    // stat events
    public static event Action<Stat> OnAnyStatChange;           // triggered by devirved stats
    public static event Action<Stat> OnWorkshopChange;          // triggered by workshop upgrade visual

    // calculation events
    public static event Action OnCalculationChange;             // triggered by any calculation

    // lab events
    public static event Action<Lab> OnAnyLabChange;             // triggered by lab

    // pack events
    public static event Action<Pack> OnAnyPackChange;           // triggered by pack control

    // effect events
    public static event Action<Effect> OnAnyEffectChange;       // triggered by ???

    public static void CardUnlockedLimitChange(int max, int unlocked)
    {
        //Debug.Log("Card Unlock Limit Change");
        OnCardUnlockedLimitChange?.Invoke(max, unlocked);
    }

    public static void EquippedCardsChange()
    {
        //Debug.Log("Equipped Cards Change");
        OnEquippedCardsChange?.Invoke();
    }

    public static void CardSelectionChange(Card card)
    {
        //Debug.Log("Card Selection Change");
        OnCardSelectionChange?.Invoke(card);
    }

    public static void CardChanged(Card card)
    {
        //Debug.Log("Card Changed");
        OnAnyCardChange?.Invoke(card);
    }

    public static void CardForceReset()
    {
        //Debug.Log("Card Force Reset");
        OnCardForceReset?.Invoke();
    }

    public static void CardForceMax()
    {
        //Debug.Log("Card Force Max");
        OnCardForceMax?.Invoke();
    }

    public static void UltimateWeaponStatusChange(UltimateWeaponType ultimateWeapon, bool isOn)
    {
        //Debug.Log("Ultimate Weapon Status Change");
        OnUltimateWeaponStatusChange?.Invoke(ultimateWeapon, isOn);
    }

    public static void UltimateWeaponPlusAvailable(bool available)
    {
        //Debug.Log("Ultimate Weapon Plus Available");
        OnUltimateWeaponPlusAvailable?.Invoke(available);
    }

    public static void PerkBanChange(Perk perk)
    {
        //Debug.Log("Perk Ban Change");
        OnPerkBanChange?.Invoke(perk);
    }

    public static void PerkPriorityChange(Perk perk)
    {
        //Debug.Log("Perk Priority Change");
        OnPerkPriorityChange?.Invoke(perk);
    }

    public static void PerkStatusChange(Perk perk)
    {
        //Debug.Log("Perk Status Change");
        OnPerkStatusChange?.Invoke(perk);
    }

    public static void PerkPresetChange(int presetSlot)
    {
        //Debug.Log("Perk Preset Change");
        OnPerkPresetChange?.Invoke(presetSlot);
    }

    public static void PerkPresetUpdate()
    {
        //Debug.Log("Perk Preset Update");
        OnPerkPresetUpdate?.Invoke();
    }

    public static void UpgradeForceUnlock()
    {
        //Debug.Log("Upgrade Force Unlock");
        OnUpgradeForceUnlock?.Invoke();
    }

    public static void UpgradeForceReset()
    {
        //Debug.Log("Upgrade Force Reset");
        OnUpgradeForceReset?.Invoke();
    }

    public static void UpgradeUnlock(UnlockCategory group, bool isUnlocked)
    {
        //Debug.Log("Upgrade Unlock");
        OnUpgradeUnlock?.Invoke(group, isUnlocked);
    }

    public static void UpgradeForceMax()
    {
        //Debug.Log("Upgrade Force Max");
        OnUpgradeForceMax?.Invoke();
    }

    public static void EnhancementForceUnlock()
    {
        //Debug.Log("Enhancement Force Unlock");
        OnEnhancementForceUnlock?.Invoke();
    }

    public static void EnhancementForceReset()
    {
        //Debug.Log("Enhancement Force Reset");
        OnEnhancementForceReset?.Invoke();
    }

    public static void ThemeStatusChange()
    {
        //Debug.Log("Theme Status Change");
        OnThemeStatusChange?.Invoke();
    }

    public static void ThemeBonusChange()
    {
        //Debug.Log("Theme Bonus Change");
        OnThemeBonusChange?.Invoke();
    }

    public static void RelicStatusChange()
    {
        //Debug.Log("Relic Status Change");
        OnRelicStatusChange?.Invoke();
    }

    public static void RelicBonusChange()
    {
        //Debug.Log("Relic Bonus Change");
        OnRelicBonusChange?.Invoke();
    }

    public static void ModuleSlotRarityChange()
    {
        //Debug.Log("Module Slot Rarity Change");
        OnModuleRarityChange?.Invoke();
    }

    public static void SubEffectChange(SubEffect subEffect)
    {
        //Debug.Log("Sub Effect Change");
        OnSubEffectChange?.Invoke(subEffect);
    }

    public static void SubEffectLimitChange(ModuleType type, bool isFull)
    {
        //Debug.Log("Sub Effect Limit Change: " + type + isFull);
        OnSubEffectLimitChange?.Invoke(type, isFull);
    }

    public static void StatChanged(Stat stat)
    {
        //Debug.Log("Stat Changed");
        OnAnyStatChange?.Invoke(stat); 
    }

    public static void WorkshopChange(Stat stat)
    {
        //Debug.Log("Workshop Change");
        OnWorkshopChange?.Invoke(stat);
    }

    public static void CalculationChanged()
    {
        //Debug.Log("Calculation Changed");
        OnCalculationChange?.Invoke(); 
    }

    public static void LabChanged(Lab lab)
    {
        //Debug.Log("Lab Changed");
        OnAnyLabChange?.Invoke(lab);
    }

    public static void PackChanged(Pack pack)
    {
        //Debug.Log("Pack Changed");
        OnAnyPackChange?.Invoke(pack);
    }

    public static void EffectChanged(Effect effect)
    {
        //Debug.Log("Effect Changed");
        OnAnyEffectChange?.Invoke(effect);
    }

}
