using UnityEngine;
using UnityEngine.UI;

public class MainPanelControl : MonoBehaviour
{
    [SerializeField] private GameObject[] _displayPanels;
    [SerializeField] private Toggle[] _panelButtons;
    [SerializeField] private PANEL _startPanel = PANEL.WORKSHOP;

    public enum PANEL { WORKSHOP, ULTIMATEWEAPONS, LAB, MODULES, CARDS,PERKS, THEMES, BOTSPACKS, RELICS, ABOUT};
    private int _pageSelected = 0;

    private void Start()
    {
        _pageSelected = (int)_startPanel;
        _panelButtons[_pageSelected].isOn = true;
        UpdatePanel();
    }

    private void UpdatePanel()
    {
        foreach (GameObject panel in _displayPanels)
        {
            panel.SetActive(false);
        }

        _displayPanels[_pageSelected].SetActive(true);
    }

    public void WorkshopPressed()
    {
        _pageSelected = (int)PANEL.WORKSHOP;
        UpdatePanel();
    }

    public void UltimateWeaponsPressed()
    {
        _pageSelected = (int)PANEL.ULTIMATEWEAPONS;
        UpdatePanel();
    }

    public void CardsPressed()
    {
        _pageSelected = (int)PANEL.CARDS;
        UpdatePanel();
    }

    public void LabPressed()
    {
        _pageSelected = (int)PANEL.LAB;
        UpdatePanel();
    }

    public void RelicPressed()
    {
        _pageSelected = (int)PANEL.RELICS;
        UpdatePanel();
    }

    public void PerksPressed()
    {
        _pageSelected = (int)PANEL.PERKS;
        UpdatePanel();
    }

    public void ThemesPressed()
    {
        _pageSelected = (int)PANEL.THEMES;
        UpdatePanel();
    }

    public void ModulesPressed()
    {
        _pageSelected = (int)PANEL.MODULES;
        UpdatePanel();
    }

    public void BotsPacksPressed()
    {
        _pageSelected = (int)PANEL.BOTSPACKS;
        UpdatePanel();
    }

    public void AboutPressed()
    {
        _pageSelected = (int)PANEL.ABOUT;
        UpdatePanel();
    }
}
