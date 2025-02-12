using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcaltionDisplayLayout : MonoBehaviour
{
    //[SerializeField] private GameObject _calculationDisplayPrefab;
    //[SerializeField] private Tower _tower;
    [SerializeField] private Calculation[] _calculations;

    public void SetDisplayCalc(DisplayCalc displayCalc)
    {
        foreach (var calc in _calculations)
        {
            calc.SetDisplayCalc(displayCalc);
        }
    }
}
