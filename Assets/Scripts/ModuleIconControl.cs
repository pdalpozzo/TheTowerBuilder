using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleIconControl : MonoBehaviour
{
    [SerializeField] private Module _module;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _border;
    [SerializeField] private Button _selected;
    [SerializeField] private GameObject _fade;

    private void Awake()
    {
    }

    private void Start()
    {
        _icon.sprite = _module.Icon;
        UpdateDisplay();
    }

    public void SetModule(Module module)
    {
        _module = module;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        _border.color = RarityColors.GetColor(_module.BaseRarity);
        _fade.SetActive(!_module.IsEquipped);
    }
}
