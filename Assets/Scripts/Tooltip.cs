using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _tooltipTitle;
    [TextArea(3, 10)]
    [SerializeField] private string _tooltipMessage;

    void Start()
    {
        //Upgrade temp = gameObject.GetComponentInParent<Upgrade>();
        //if (temp != null)
        //{
        //    _tooltipMessage = gameObject.GetComponentInParent<Upgrade>().TooltipMessage;
        //}

    }

    public void SetMessage(string message, string title = "")
    {
        _tooltipMessage = message;
        _tooltipTitle = title;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.ShowTooltip_Static(_tooltipMessage, _tooltipTitle);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.HideTooltip_Static();
    }
}
