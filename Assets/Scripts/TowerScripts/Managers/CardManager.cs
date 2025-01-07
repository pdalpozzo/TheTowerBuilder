using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private int _unlockedSlots = 9;                         // slots unlocked
    [SerializeField] private int _maxSlots = 19;            // max slots in the game
    [SerializeField] private List<Card> _equippedCards;     // cards equipped

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

    public int MaxSlots { get { return _maxSlots; } }
    public int UnlockedSlots { get { return _unlockedSlots; } }

    private void Awake()
    {
        EventManager.OnCardSelectionChange += AssignCardSlot;   // triggered by card visual control
    }

    private void Start()
    {
        AddDummyCard();
        Trigger_UnlockedLimitChange();
    }

    public void ChangeSlotLimit(TMP_InputField inputField)
    {
        int input = 0;
        if (inputField.text != null) input = int.Parse(inputField.text);

        input = ValidateInput(input, _maxSlots);

        if (input < _unlockedSlots)
        {
            for (int i = _equippedCards.Count - 1; i > input; i--)
            {
                _equippedCards[i].AssignSlot(0);    // 0 is assigned when the card does not have a slot, aka is not equipped
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
            if (card.Slot != 0) _equippedCards.RemoveAt(card.Slot);
            card.AssignSlot(0);                     // 0 is assigned when the card does not have a slot, aka is not equipped
            UpdateEquippedSlotNumbers();
            Trigger_EquippedCardsChange();
            return;
        }
        if (card.Level == 0) return;
        if (_equippedCards.Count - 1 >= _unlockedSlots) return;

        _equippedCards.Add(card);                   // add card
        card.AssignSlot(_equippedCards.Count - 1);  // minus 1 because of dummy at index 0
        Trigger_EquippedCardsChange();
    }

    private void AddDummyCard()
    {
        // add dummy card so all non equipped cards can be set to 0
        // and the indexes in the list will match to card slot numbers
        Card dummy = gameObject.AddComponent<Card>();
        _equippedCards.Add(dummy);
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
        for (int i = 1; i < _equippedCards.Count; i++)
        {
            _equippedCards[i].AssignSlot(i);
        }
    }






}
