using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.CullingGroup;

public class BotControl : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private Tooltip _tooltip;

    [SerializeField] private EffectVisualControl _effectOne;
    [SerializeField] private EffectVisualControl _effectTwo;
    [SerializeField] private EffectVisualControl _effectThree;
    [SerializeField] private EffectVisualControl _effectFour;

    [SerializeField] private TextMeshProUGUI _botNameText;
    
    [SerializeField] private OnOffToggleControl _mainToggleControl;

    [SerializeField] private Image _icon;
    [SerializeField] private Image _fade;

    private void Start()
    {
        _botNameText.text = _bot.Name;
        _icon.sprite = _bot.Icon;

        UpdateFade(_fade, _mainToggleControl.IsOn);

        _tooltip.SetMessage(_bot.TooltipMessage);
    }

    private void UpdateFade(Image fade, bool isOn)
    {
        if (fade != null) fade.gameObject.SetActive(!isOn);
    }

    public void ToggleBot()
    {
        UpdateFade(_fade, _mainToggleControl.IsOn);

        _effectOne.SetInteraction(_mainToggleControl.IsOn);
        _effectTwo.SetInteraction(_mainToggleControl.IsOn);
        _effectThree.SetInteraction(_mainToggleControl.IsOn);
        _effectFour.SetInteraction(_mainToggleControl.IsOn);
        _bot.ChangeActive(_mainToggleControl.IsOn);
    }
}
