using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkStatusControl : MonoBehaviour
{
    [SerializeField] private Toggle _banButton;
    [SerializeField] private Toggle _priorityButton;

    [SerializeField] private LabVisualControl _banPerkLab;
    [SerializeField] private LabVisualControl _autoRankPerkLab;

    public void BanButtonClicked()
    {
        if (_banButton.isOn) _priorityButton.isOn = !_banButton.isOn;
    }

    public void PriorityButtonClicked()
    {
        if (_priorityButton.isOn) _banButton.isOn = !_priorityButton.isOn;
    }

    public void PerkClicked(PerkVisualControl perk)
    {
        if (_banButton.isOn)
        {
            EventManager.PerkBanChange(perk.Perk);
            return;
        }

        if (_priorityButton.isOn)
        {
            EventManager.PerkPriorityChange(perk.Perk);
        }
    }

    public void SelectedPresetChange(int presetSlot)
    {
        if (presetSlot > 5) presetSlot = 5;
        if (presetSlot < 1) presetSlot = 1;
        Trigger_PresetChange(presetSlot);
    }

    private void Trigger_PresetChange(int presetSlot)
    {
        EventManager.PerkPresetChange(presetSlot);
    }
}
