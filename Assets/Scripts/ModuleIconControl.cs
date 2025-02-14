using UnityEngine;
using UnityEngine.UI;

public class ModuleIconControl : MonoBehaviour
{
    [SerializeField] private Module _module;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _border;
    [SerializeField] private Button _selected;
    [SerializeField] private GameObject _fade;

    private void Start()
    {
        _icon.sprite = _module.Icon;
    }

    public void SetModule(Module module)
    {
        _module = module;
    }

    public void Update()
    {
        _border.color = RarityColors.GetColor(_module.BaseRarity);
        _fade.SetActive(!_module.IsEquipped);
    }
}
