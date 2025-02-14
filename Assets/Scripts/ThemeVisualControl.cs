using TMPro;
using UnityEngine;

public class ThemeVisualControl : MonoBehaviour
{
    [SerializeField] private Theme _theme;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private OnOffToggleControl _toggle;

    // Start is called before the first frame update
    private void Start()
    {
        if (_nameText != null) _nameText.text = _theme.Name;
    }

    public void ToggleTheme()
    {
        _theme.ChangeActive(_toggle.IsOn);
    }

    private void Update()
    {
        if (_toggle.IsOn != _theme.IsOn) _toggle.SetToggle(_theme.IsOn);
    }
}
