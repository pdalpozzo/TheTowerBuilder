using UnityEngine;

public class CardMassControl : MonoBehaviour
{
    public void ResetCards()
    {
        EventManager.CardForceReset();
    }

    public void MaxAllCards()
    {
        EventManager.CardForceMax();
    }

    public void SelectedPresetChange(int presetSlot)
    {
        if (presetSlot > 5) presetSlot = 5;
        if (presetSlot < 1) presetSlot = 1;
        Trigger_PresetChange(presetSlot);
    }

    private void Trigger_PresetChange(int presetSlot)
    {
        EventManager.CardPresetChange(presetSlot);
    }
}
