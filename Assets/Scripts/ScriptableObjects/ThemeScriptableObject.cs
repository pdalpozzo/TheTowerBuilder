using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "ScriptableObjects/Theme")]
public class ThemeScriptableObject : ScriptableObject
{
    [SerializeField] private string _themeName;
    [SerializeField] private ThemeType _type;

    public string Name { get { return _themeName; } }
    public ThemeType ThemeType { get { return _type; } }
}
