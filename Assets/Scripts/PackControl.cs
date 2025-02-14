using UnityEngine;
using UnityEngine.UI;

public class PackControl : MonoBehaviour
{
    [SerializeField] private Toggle _mainToggle;
    [SerializeField] private Image _fade;
    [SerializeField] private Pack _pack;

    private bool _isUnlocked = false;

    void Start()
    {
        _isUnlocked = _mainToggle.isOn;
        UpdatePack();
    }

    private void UpdatePack()
    {
        _fade.gameObject.SetActive(!_isUnlocked);
        EventManager.PackChanged(_pack);
    }

    public void PackToggle()
    {
        _isUnlocked = _mainToggle.isOn;
        _pack.IsOn = _isUnlocked;
        UpdatePack();
    }
}
