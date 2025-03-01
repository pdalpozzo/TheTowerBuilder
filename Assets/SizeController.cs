using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    [SerializeField] private GameObject _contentPanel;
    [SerializeField] private GameObject _targetPanel;
    [SerializeField] private float _heightOffset;
    [SerializeField] private float _widthOffset;

    private void Update()
    {
        Vector2 targetRect = _targetPanel.GetComponent<RectTransform>().sizeDelta;
        targetRect.y += _heightOffset;
        targetRect.x += _widthOffset;
        _contentPanel.GetComponent<RectTransform>().sizeDelta = targetRect;
    }
}
