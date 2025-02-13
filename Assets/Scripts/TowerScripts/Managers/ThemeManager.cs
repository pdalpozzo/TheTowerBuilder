using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    private const float BACKGROUND_BONUS = 0.008f;
    private const float TOWER_BONUS = 0.004f;
    private const float SONG_BONUS = 0.006f;

    [SerializeField] private float _backgroundBonus = 0;
    [SerializeField] private float _towerBonus = 0;
    [SerializeField] private float _songBonus = 0;

    [SerializeField] private int _activeBackgrounds = 0;
    [SerializeField] private int _activeTowers = 0;
    [SerializeField] private int _activeSongs = 0;

    // background themes
    [SerializeField] private Theme[] _backgroundThemes;
    // tower themes
    [SerializeField] private Theme[] _towerThemes;
    // song themes
    [SerializeField] private Theme[] _songThemes;

    private int _additionalTowers = 0;
    private int _additionalBackgrounds = 0;
    private int _additionalSongs = 0;

    public int BackgroundCount { get { return _backgroundThemes.Length; } }
    public int TowerCount { get { return _towerThemes.Length; } }
    public int SongCount { get { return _songThemes.Length; } }
    public int ActiveBackgrounds { get { return _activeBackgrounds; } }
    public int ActiveTowers { get { return _activeTowers; } }
    public int ActiveSongs { get { return _activeSongs; } }
    public float BackgroundBonus { get { return _backgroundBonus; } }
    public float TowerBonus { get { return _towerBonus; } }
    public float SongBonus { get { return _songBonus; } }
    public float TotalBonus { get { return (_towerBonus + _backgroundBonus + _songBonus); } }

    private void Update()
    {
        _activeBackgrounds = 0;
        foreach (Theme theme in _backgroundThemes)
        {
            if(theme.IsOn) _activeBackgrounds++;
        }
        _backgroundBonus = ((_activeBackgrounds + _additionalBackgrounds) * BACKGROUND_BONUS);

        _activeTowers = 0;
        foreach (Theme theme in _towerThemes)
        {
            if (theme.IsOn) _activeTowers++;
        }
        _towerBonus = ((_activeTowers + _additionalTowers) * TOWER_BONUS);

        _activeSongs = 0;
        foreach (Theme theme in _songThemes)
        {
            if (theme.IsOn) _activeSongs++;
        }
        _songBonus = ((_activeSongs + _additionalSongs) * SONG_BONUS);

        EventManager.ThemeBonusChange();
    }

    public void SetAdditionalTowers(int towers)
    {
        _additionalTowers = towers;
    }

    public void SetAdditionalBackgrounds(int backgrounds)
    {
        _additionalBackgrounds = backgrounds;
    }

    public void SetAdditionalSongs(int songs)
    {
        _additionalSongs = songs;
    }

    public void ForceAll(bool isOn)
    {

        foreach (Theme theme in _backgroundThemes)
        {
            theme.ChangeActive(isOn);
        }

        foreach (Theme theme in _towerThemes)
        {
            theme.ChangeActive(isOn);
        }

        foreach (Theme theme in _songThemes)
        {
            theme.ChangeActive(isOn);
        }
    }
}
