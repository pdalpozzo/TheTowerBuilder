using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackControl : MonoBehaviour
{

    [SerializeField] private Toggle _mainToggle;
    [SerializeField] private Image _fade;
    [SerializeField] private Pack _pack;

    private bool _isUnlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        _isUnlocked = _mainToggle.isOn;
        UpdatePack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdatePack()
    {
        //_mainToggle.isOn = _isPurchased;
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
