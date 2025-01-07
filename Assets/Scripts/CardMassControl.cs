using UnityEngine;
using UnityEngine.UI;

public class CardMassControl : MonoBehaviour
{
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _maxButton;

    public void ResetCards()
    {
        EventManager.CardForceReset();
    }

    public void MaxAllCards()
    {
        EventManager.CardForceMax();
    }

}
