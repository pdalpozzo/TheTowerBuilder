using UnityEngine;

public enum ThemeType { TOWER, BACKGROUND, SONG };

public class Theme : MonoBehaviour
{
    [SerializeField] private ThemeScriptableObject _data;
    [SerializeField] private bool _isOn = false;

    public string Name { get { return _data.Name; } }
    public bool IsOn { get { return _isOn; } }

    public void ChangeActive(bool isOn)
    {
        _isOn = isOn;
    }
}
