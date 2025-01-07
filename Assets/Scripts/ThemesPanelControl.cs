using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemesPanelControl : MonoBehaviour
{
    // NOTE: the toggle.isOn on this gameobject is reversed, and actually is used as toggle.isOff
    // The item is a simple toggle object, if I wanted to correct this, I would need to create a new
    // script just to handle the fade image of the theme, requiring another script.
    [SerializeField] private ThemeManager _themes;
    [SerializeField] private GameObject _towerThemes;
    [SerializeField] private GameObject _backgroundThemes;
    [SerializeField] private GameObject _songThemes;
    [SerializeField] private Toggle _towerButton;
    [SerializeField] private Toggle _backgroundButton;
    [SerializeField] private Toggle _songButton;
    [SerializeField] private TextMeshProUGUI _totalCoinBonus;
    [SerializeField] private TMP_InputField _additionalTowersInput;
    [SerializeField] private TMP_InputField _additionalBackgroundInput;
    [SerializeField] private TMP_InputField _additionalSongInput;

    private void Awake()
    {
        EventManager.OnThemeStatusChange += UpdateBonuses;   // triggered by theme
    }

    private void Start()
    {
        ToggleThemes();
        UpdateBonuses();
    }

    public void ToggleThemes()
    {
        _towerThemes.SetActive(_towerButton.isOn);
        _backgroundThemes.SetActive(_backgroundButton.isOn);
        _songThemes.SetActive(_songButton.isOn);
    }

    private void UpdateBonuses()
    {
        _totalCoinBonus.text = "+" + _themes.TotalBonus.ToString("P1");
    }

    public void AllOn()
    {
        _themes.ForceAll(true);
    }

    public void AllOff()
    {
        _themes.ForceAll(false);
    }

    public void SetAdditionalTowers()
    {
        int input = 0;
        if (_additionalTowersInput.text != null) input = int.Parse(_additionalTowersInput.text);
        if (input < 0) input = 0;
        _additionalTowersInput.text = input.ToString();
        _themes.SetAdditionalTowers(input);
        UpdateBonuses();
    }

    public void SetAdditionalBackgrounds()
    {
        int input = 0;
        if (_additionalBackgroundInput.text != null) input = int.Parse(_additionalBackgroundInput.text);
        if (input < 0) input = 0;
        _additionalBackgroundInput.text = input.ToString();
        _themes.SetAdditionalBackgrounds(input);
        UpdateBonuses();
    }

    public void SetAdditionalSongs()
    {
        int input = 0;
        if (_additionalSongInput.text != null) input = int.Parse(_additionalSongInput.text);
        if (input < 0) input = 0;
        _additionalSongInput.text = input.ToString();
        _themes.SetAdditionalSongs(input);
        UpdateBonuses();
    }
}
