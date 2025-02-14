using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubEffectVisualControl : MonoBehaviour
{
    [SerializeField] private SubEffect _subEffect;
    [SerializeField] private OnOffToggleControl _toggle;
    [SerializeField] private TextMeshProUGUI _rarityText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _effectText;
    [SerializeField] private Button _down;
    [SerializeField] private Button _up;
    [SerializeField] private Image _rarityBorder;
    [SerializeField] private GameObject _fade;

    private bool _moduleSlotsAreFull = false;

    private void Start()
    {
        EventManager.OnSubEffectLimitChange += SubEffectLimit;    // triggered by module slot
    }

    public void RarityUp()
    {
        Rarity newRarity = _subEffect.Rarity + 1;
        int enumCount = Enum.GetNames(typeof(Rarity)).Length;
        if ((int)newRarity >= enumCount) newRarity = Rarity.ANCESTRAL;
        _subEffect.ChangeRarity(newRarity);
        SubEffectRarityChange();
    }

    public void RarityDown()
    {
        Rarity newRarity = _subEffect.Rarity - 1;
        if (newRarity < _subEffect.BaseRarity) newRarity = _subEffect.BaseRarity;
        _subEffect.ChangeRarity(newRarity);
        SubEffectRarityChange();
    }

    public void ToggleSubEffect()
    {
        EventManager.SubEffectEquipChange(_subEffect);
    }

    private void SubEffectRarityChange()
    {
        EventManager.SubEffectRarityChange(_subEffect);
    }

    private void SubEffectLimit(ModuleType type, bool isFull)
    {
        if (_subEffect.ModuleType != type) return;
        _moduleSlotsAreFull = isFull;
        if (_moduleSlotsAreFull)
        {
            if(!_subEffect.IsEquipped) _toggle.SetUnlock(false);
        }
    }

    private void Update()
    {
        _toggle.SetToggle(_subEffect.IsEquipped);

        _effectText.color = RarityColors.GetColor(_subEffect.Rarity);
        _valueText.color = RarityColors.GetColor(_subEffect.Rarity);
        _rarityText.color = RarityColors.GetColor(_subEffect.Rarity);
        _rarityBorder.color = RarityColors.GetColor(_subEffect.Rarity);

        _effectText.text = _subEffect.Name;
        _valueText.text = _subEffect.GetDescription();
        _rarityText.text = Enum.GetName(typeof(Rarity), _subEffect.Rarity);

        _up.interactable = (_subEffect.Rarity != Rarity.ANCESTRAL);
        _down.interactable = (_subEffect.Rarity != _subEffect.BaseRarity);

        if (_fade != null)
            _fade.SetActive((_moduleSlotsAreFull && !_subEffect.IsEquipped) || (_subEffect.ModuleRarity < _subEffect.BaseRarity));
    }
}
