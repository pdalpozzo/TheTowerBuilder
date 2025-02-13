using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ThemeType { TOWER, BACKGROUND, SONG };

public class Theme : MonoBehaviour
{
    [SerializeField] private ThemeScriptableObject _data;
    [SerializeField] private bool _isOn = false;

    public string Name { get { return _data.Name; } }
    //public string TooltipMessage { get { return _data.Tooltip; } }
    //public Sprite Icon { get { return _data.Icon; } }
    public bool IsOn { get { return _isOn; } }
    public ThemeType Type { get { return _data.ThemeType; } }

    public void ChangeActive(bool isOn)
    {
        _isOn = isOn;
    }
}
