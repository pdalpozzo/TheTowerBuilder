using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "ScriptableObjects/Theme")]
public class ThemeScriptableObject : ScriptableObject
{
    [SerializeField] private string _themeName;
    //[TextArea(3, 10)] [SerializeField] private string _tooltipMessage;
    //[SerializeField] private Sprite _icon;
    [SerializeField] private ThemeType _type;

    public string Name { get { return _themeName; } }
    //public string Tooltip { get { return _tooltipMessage; } }
    //public Sprite Icon { get { return _icon; } }
    public ThemeType ThemeType { get { return _type; } }
}
