using UnityEngine;

public class CalcaltionDisplayLayout : MonoBehaviour
{
    [SerializeField] private Calculation[] _calculations;

    public void SetDisplayCalc(DisplayCalc displayCalc)
    {
        foreach (var calc in _calculations)
        {
            calc.SetDisplayCalc(displayCalc);
        }
    }
}
