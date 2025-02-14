using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // card events
    public static event Action<int, int> OnCardUnlockedLimitChange; // triggered by card manager
    public static event Action OnEquippedCardsChange;               // triggered by card manager
    public static event Action<Card> OnCardSelectionChange;         // triggered by card visual control
    public static event Action<Card> OnAnyCardChange;               // triggered by card
    public static event Action OnCardForceReset;                    // triggered by card mass control
    public static event Action OnCardForceMax;                      // triggered by card mass control
    public static event Action<int> OnCardPresetChange;             // triggered by card mass control
    public static event Action<CardMastery> OnAnyMasteryChange;     // triggered by card mastery

    // ultimate weapon events
    public static event Action<UltimateWeaponType, bool> OnUltimateWeaponStatusChange;  // triggered by ultimate weapon
    public static event Action<bool> OnUltimateWeaponPlusAvailable;                     // triggered by ultimate weapon manager

    // perk events
    public static event Action<Perk> OnPerkBanChange;           // triggered by perk status control
    public static event Action<Perk> OnPerkPriorityChange;      // triggered by perk status control
    public static event Action<Perk> OnPerkStatusChange;        // triggered by perk
    public static event Action<int> OnPerkPresetChange;         // triggered by perk status control
    
    // upgrade events
    public static event Action OnUpgradeForceUnlock;                    // triggered by workshop panel control
    public static event Action OnUpgradeForceReset;                     // triggered by workshop panel control
    public static event Action<UnlockCategory, bool> OnUpgradeUnlock;   // triggered by workshop upgrade display
    public static event Action OnUpgradeForceMax;                       // triggered by workshop upgrade display

    // enhancement events
    public static event Action OnEnhancementForceUnlock;        // triggered by workshop panel control
    public static event Action OnEnhancementForceReset;         // triggered by workshop panel control
    
    // theme events
    public static event Action OnThemeBonusChange;              // triggered by theme manager

    // relic events
    public static event Action OnRelicStatusChange;             // triggered by relic
    public static event Action OnRelicBonusChange;              // triggered by relic manager

    // module events
    public static event Action OnModuleRarityChange;                        // triggered by module slot
    public static event Action<SubEffect> OnSubEffectEquipChange;           // triggered by sub effect visual control
    public static event Action<SubEffect> OnSubEffectRarityChange;          // triggered by sub effect visual control
    public static event Action<ModuleType, bool> OnSubEffectLimitChange;    // triggered by module slot

    // stat events
    public static event Action<Stat> OnAnyStatChange;           // triggered by devirved stats
    public static event Action<Stat> OnWorkshopChange;          // triggered by workshop upgrade visual

    // lab events
    public static event Action<Lab> OnAnyLabChange;             // triggered by lab

    // pack events
    public static event Action<Pack> OnAnyPackChange;           // triggered by pack control

    // effect events
    public static event Action<Effect> OnAnyEffectChange;       // triggered by ???

    // bot events
    public static event Action<Bot> OnAnyBotChange;             // triggered by bot


    public static void CardUnlockedLimitChange(int max, int unlocked)
    {
        OnCardUnlockedLimitChange?.Invoke(max, unlocked);
    }

    public static void EquippedCardsChange()
    {
        OnEquippedCardsChange?.Invoke();
    }

    public static void CardSelectionChange(Card card)
    {
        OnCardSelectionChange?.Invoke(card);
    }

    public static void CardChanged(Card card)
    {
        OnAnyCardChange?.Invoke(card);
    }

    public static void CardForceReset()
    {
        OnCardForceReset?.Invoke();
    }

    public static void CardForceMax()
    {
        OnCardForceMax?.Invoke();
    }

    public static void CardPresetChange(int presetSlot)
    {
        OnCardPresetChange?.Invoke(presetSlot);
    }

    public static void MasteryChange(CardMastery mastery)
    {
        OnAnyMasteryChange?.Invoke(mastery);
    }

    public static void UltimateWeaponStatusChange(UltimateWeaponType ultimateWeapon, bool isOn)
    {
        OnUltimateWeaponStatusChange?.Invoke(ultimateWeapon, isOn);
    }

    public static void UltimateWeaponPlusAvailable(bool available)
    {
        OnUltimateWeaponPlusAvailable?.Invoke(available);
    }

    public static void PerkBanChange(Perk perk)
    {
        OnPerkBanChange?.Invoke(perk);
    }

    public static void PerkPriorityChange(Perk perk)
    {
        OnPerkPriorityChange?.Invoke(perk);
    }

    public static void PerkStatusChange(Perk perk)
    {
        OnPerkStatusChange?.Invoke(perk);
    }

    public static void PerkPresetChange(int presetSlot)
    {
        OnPerkPresetChange?.Invoke(presetSlot);
    }

    public static void UpgradeForceUnlock()
    {
        OnUpgradeForceUnlock?.Invoke();
    }

    public static void UpgradeForceReset()
    {
        OnUpgradeForceReset?.Invoke();
    }

    public static void UpgradeUnlock(UnlockCategory group, bool isUnlocked)
    {
        OnUpgradeUnlock?.Invoke(group, isUnlocked);
    }

    public static void UpgradeForceMax()
    {
        OnUpgradeForceMax?.Invoke();
    }

    public static void EnhancementForceUnlock()
    {
        OnEnhancementForceUnlock?.Invoke();
    }

    public static void EnhancementForceReset()
    {
        OnEnhancementForceReset?.Invoke();
    }

    public static void ThemeBonusChange()
    {
        OnThemeBonusChange?.Invoke();
    }

    public static void RelicStatusChange()
    {
        OnRelicStatusChange?.Invoke();
    }

    public static void RelicBonusChange()
    {
        OnRelicBonusChange?.Invoke();
    }

    public static void ModuleSlotRarityChange()
    {
        OnModuleRarityChange?.Invoke();
    }

    public static void SubEffectEquipChange(SubEffect subEffect)
    {
        OnSubEffectEquipChange?.Invoke(subEffect);
    }

    public static void SubEffectRarityChange(SubEffect subEffect)
    {
        OnSubEffectRarityChange?.Invoke(subEffect);
    }

    public static void SubEffectLimitChange(ModuleType type, bool isFull)
    {
        OnSubEffectLimitChange?.Invoke(type, isFull);
    }

    public static void StatChanged(Stat stat)
    {
        OnAnyStatChange?.Invoke(stat); 
    }

    public static void WorkshopChange(Stat stat)
    {
        OnWorkshopChange?.Invoke(stat);
    }

    public static void LabChanged(Lab lab)
    {
        OnAnyLabChange?.Invoke(lab);
    }

    public static void PackChanged(Pack pack)
    {
        OnAnyPackChange?.Invoke(pack);
    }

    public static void EffectChanged(Effect effect)
    {
        OnAnyEffectChange?.Invoke(effect);
    }

    public static void BotChanged(Bot bot)
    {
        OnAnyBotChange?.Invoke(bot);
    }
}
