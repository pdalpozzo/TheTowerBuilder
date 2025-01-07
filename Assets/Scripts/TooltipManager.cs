using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;
    [SerializeField] private TextMeshProUGUI _tooltipMessage;
    [SerializeField] private TextMeshProUGUI _tooltipTitle;
    [SerializeField] private RectTransform _tooltipPanel;
    private float _padding = 5f;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        _tooltipPanel = transform.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        HideTooltip();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    private void SetAndShowTooltip(string message, string title)
    {
        gameObject.SetActive(true);
        _tooltipMessage.text = message;
        _tooltipTitle.text = title;

        float width = 0f;
        width = (_tooltipMessage.preferredWidth > _tooltipTitle.preferredWidth) ? _tooltipMessage.preferredWidth: _tooltipTitle.preferredWidth;
        width += (4 * _padding);
        width = Mathf.Ceil(width);
        width = (width < 300) ? width : 300f;

        float height = 0f;
        height += _tooltipTitle.preferredHeight;
        height += _tooltipMessage.preferredHeight;
        height = Mathf.Ceil(height);

        Vector2 tooltipSize = new Vector2(width, height);

        _tooltipPanel.sizeDelta = tooltipSize;
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
        _tooltipMessage.text = "";
    }

    public static void ShowTooltip_Static(string message, string title = "")
    {
        _instance.SetAndShowTooltip(message, title);
    }

    public static void HideTooltip_Static()
    {
        _instance.HideTooltip();
    }
}
