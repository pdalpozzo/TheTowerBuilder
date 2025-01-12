using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardVisualControl : MonoBehaviour
{
    /// <summary>
    ///  old script
    /// </summary>
    [SerializeField] private Card _card;
    [SerializeField] private Color _normal;
    [SerializeField] private Color _yellow;
    [SerializeField] private Color _purple;
    [SerializeField] private Button _star1;
    [SerializeField] private Button _star2;
    [SerializeField] private Button _star3;
    [SerializeField] private Button _star4;
    [SerializeField] private Button _star5;
    [SerializeField] private Button _star6;
    [SerializeField] private Button _star7;
    [SerializeField] private Image _img1;
    [SerializeField] private Image _img2;
    [SerializeField] private Image _img3;
    [SerializeField] private Image _img4;
    [SerializeField] private Image _img5;
    [SerializeField] private Image _img6;
    [SerializeField] private Image _img7;
    [SerializeField] private Image _border;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _slotNumberText;
    [SerializeField] private GameObject _slot;
    [SerializeField] private GameObject _fade;

    private void Awake()
    {
        EventManager.OnEquippedCardsChange += UpdateSlotNumber; // triggered by cards holder
    }

    private void Start()
    {
        _nameText.text = _card.Name;
        _icon.sprite = _card.Icon;
        this.GetComponent<Image>().color = RarityColors.GetColor(_card.Rarity);
        _border.color = RarityColors.GetColor(_card.Rarity);
        UpdateStars();
        UpdateSlotNumber();
    }

    public void EquipChange()
    {
        Trigger_CardSelectionChange();
    }

    public void ChangeLevel(int level)
    {
        if (_card.Level == level) level--;
        _card.NewLevel(level);
        if (_card.IsEquipped && _card.Level == 0)
        {
            Trigger_CardSelectionChange();
        }
        UpdateStars();
    }

    // could be in update
    public void UpdateSlotNumber()
    {
        _slot.SetActive(_card.IsEquipped);
        _slotNumberText.text = (_card.IsEquipped) ? (_card.Slot + 1).ToString("N0") : "0";
    }
    
    // trigger when the card UI has been click to assign the card to a slot
    private void Trigger_CardSelectionChange()
    {
        EventManager.CardSelectionChange(_card);
    }

    // could be in update
    private void UpdateStars()
    {
        //_slot.SetActive(_card.IsEquipped);
        _fade.SetActive((_card.Level == 0) ? true : false);
        _star1.image.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow;
        _star2.image.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow;
        _star3.image.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow;
        _star4.image.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow;
        _star5.image.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow;
        _star6.image.color = (_card.Level == 7) ? _purple : _yellow;
        _img1.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow;
        _img2.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow;
        _img3.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow;
        _img4.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow;
        _img5.color = (_card.Level < 6) ? _normal : (_card.Level == 7) ? _purple : _yellow; 
        _img6.color = (_card.Level == 7) ? _purple : _yellow;
        _img1.gameObject.SetActive((_card.Level >= 1) ? true : false);
        _img2.gameObject.SetActive((_card.Level >= 2) ? true : false);
        _img3.gameObject.SetActive((_card.Level >= 3) ? true : false);
        _img4.gameObject.SetActive((_card.Level >= 4) ? true : false);
        _img5.gameObject.SetActive((_card.Level >= 5) ? true : false);
        _img6.gameObject.SetActive((_card.Level >= 6) ? true : false);
        _img7.gameObject.SetActive((_card.Level == 7) ? true : false);
    }
}
