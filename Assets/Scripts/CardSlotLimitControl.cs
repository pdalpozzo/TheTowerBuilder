using TMPro;
using UnityEngine;

public class CardSlotLimitControl : MonoBehaviour
{
    [SerializeField] private TMP_InputField _unlockedSlotInput;

    private void Awake()
    {
        EventManager.OnCardUnlockedLimitChange += UpdateUnlockedCardSlotLimit;  // triggered by cards holder
    }

    private void UpdateUnlockedCardSlotLimit(int max, int unlocked)
    {
        _unlockedSlotInput.placeholder.GetComponent<TextMeshProUGUI>().text = max.ToString();
        _unlockedSlotInput.text = (unlocked == 0) ? "" : unlocked.ToString();
    }
}
