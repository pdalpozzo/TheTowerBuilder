using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private int _unlockedSlots = 9;                         // slots unlocked
    [SerializeField] private int _maxSlots = 19;            // max slots in the game
    [SerializeField] private List<Card> _equippedCards;     // cards equipped

    [SerializeField] private List<Card> _cardsPresetOne;    // cards preset
    [SerializeField] private List<Card> _cardsPresetTwo;    // cards preset
    [SerializeField] private List<Card> _cardsPresetThree;  // cards preset
    [SerializeField] private List<Card> _cardsPresetFour;   // cards preset
    [SerializeField] private List<Card> _cardsPresetFive;   // cards preset

    [SerializeField] private Card _damage;
    [SerializeField] private Card _attackSpeed;
    [SerializeField] private Card _health;
    [SerializeField] private Card _healthRegen;
    [SerializeField] private Card _range;
    [SerializeField] private Card _cash;
    [SerializeField] private Card _coins;
    [SerializeField] private Card _slowAura;
    [SerializeField] private Card _criticalChance;
    [SerializeField] private Card _enemyBalance;
    [SerializeField] private Card _extraDefense;
    [SerializeField] private Card _fortress;
    [SerializeField] private Card _freeUpgrades;
    [SerializeField] private Card _extraOrb;
    [SerializeField] private Card _plasmaCannon;
    [SerializeField] private Card _criticalCoins;
    [SerializeField] private Card _waveSkip;
    [SerializeField] private Card _introSprint;
    [SerializeField] private Card _landMineStun;
    [SerializeField] private Card _recoveryPackageChance;
    [SerializeField] private Card _deathRay;
    [SerializeField] private Card _energyNet;
    [SerializeField] private Card _superTower;
    [SerializeField] private Card _secondWind;
    [SerializeField] private Card _demonMode;
    [SerializeField] private Card _energyShield;
    [SerializeField] private Card _waveAccelerator;
    [SerializeField] private Card _berserk;
    [SerializeField] private Card _ultimateCrit;
    [SerializeField] private Card _nuke;

    private int _selectedPreset = 1;

    public int MaxSlots { get { return _maxSlots; } }
    public int UnlockedSlots { get { return _unlockedSlots; } }

    private void Awake()
    {
        EventManager.OnCardSelectionChange += AssignCardSlot;   // triggered by card visual control
        EventManager.OnCardPresetChange += ChangePresetSelection;
    }

    private void Start()
    {
        Trigger_UnlockedLimitChange();
    }

    public void ChangeSlotLimit(TMP_InputField inputField)
    {
        int input = 0;
        if (inputField.text != null) input = int.Parse(inputField.text);

        input = ValidateInput(input, _maxSlots);

        if (input < _unlockedSlots)
        {
            for (int i = _equippedCards.Count - 1; i > input - 1; i--)
            {
                _equippedCards[i].AssignSlot(-1);    // -1 is assigned when the card does not have a slot, aka is not equipped
                _equippedCards.RemoveAt(i);
            }
        }
        _unlockedSlots = input;
        Trigger_UnlockedLimitChange();
        Trigger_EquippedCardsChange();
    }

    public void AssignCardSlot(Card card)
    {
        if (card.IsEquipped || card.Level == 0)     // if already equipped, unequip or level changed to 0
        {
            if (card.Slot != -1) _equippedCards.RemoveAt(card.Slot);
            card.AssignSlot(-1);                     // -1 is assigned when the card does not have a slot, aka is not equipped
            UpdateEquippedSlotNumbers();
            Trigger_EquippedCardsChange();
            return;
        }
        if (card.Level == 0) return;
        if (_equippedCards.Count >= _unlockedSlots) return;

        _equippedCards.Add(card);                   // add card
        card.AssignSlot(_equippedCards.Count - 1);      // minus 1 because of dummy at index 0
        Trigger_EquippedCardsChange();
    }

    // trigger when the unlocked card limit is changed
    private void Trigger_UnlockedLimitChange()
    {
        EventManager.CardUnlockedLimitChange(_maxSlots, _unlockedSlots);
    }

    // trigger then the equipped card list has changed
    private void Trigger_EquippedCardsChange()
    {
        EventManager.EquippedCardsChange();
    }

    private int ValidateInput(int input, int max)
    {
        if (input < 0) input = 0;
        if (input > max) input = max;
        return input;
    }

    private void UpdateEquippedSlotNumbers()
    {
        for (int i = 0; i < _equippedCards.Count; i++)
        {
            _equippedCards[i].AssignSlot(i);
        }
    }

    private void ChangePresetSelection(int presetSlot)
    {
        if (presetSlot == _selectedPreset) return;

        switch (_selectedPreset)
        {
            case 2:
                TransferCardList(_cardsPresetTwo, _equippedCards);
                break;
            case 3:
                TransferCardList(_cardsPresetThree, _equippedCards);
                break;
            case 4:
                TransferCardList(_cardsPresetFour, _equippedCards);
                break;
            case 5:
                TransferCardList(_cardsPresetFive, _equippedCards);
                break;
            default:
                TransferCardList(_cardsPresetOne, _equippedCards);
                break;
        }

        _selectedPreset = presetSlot;
        List<Card> toEquip = new List<Card>();

        switch (_selectedPreset)
        {
            case 2:
                TransferCardList(toEquip, _cardsPresetTwo);
                break;
            case 3:
                TransferCardList(toEquip, _cardsPresetThree);
                break;
            case 4:
                TransferCardList(toEquip, _cardsPresetFour);
                break;
            case 5:
                TransferCardList(toEquip, _cardsPresetFive);
                break;
            default:
                TransferCardList(toEquip, _cardsPresetOne);
                break;
        }
        TransferCardList(_equippedCards, toEquip, true);
    }

    private void TransferCardList(List<Card> toList, List<Card> fromList, bool isEquipped = false)
    {
        toList.Clear();
        if (isEquipped)
        {
            foreach (Card card in fromList)
            {
                AssignCardSlot(card);
            }
        }
        else
        {
            foreach (Card card in fromList)
            {
                card.ResetSlot();
                toList.Add(card);
            }
            Trigger_EquippedCardsChange();
        }
    }



}
