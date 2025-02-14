using UnityEngine;

public class SubEffect : MonoBehaviour
{
    [SerializeField] private SubEffectScriptableObject _data;
    [SerializeField] private Rarity _currentRarity;
    [SerializeField] private Rarity _currentModuleRarity;
    [SerializeField] private bool _isEquipped = false;

    public string Name { get { return _data.Name; } }
    public Rarity Rarity { get { return _currentRarity; } }
    public Rarity BaseRarity { get { return _data.Rarity; } }
    public Rarity ModuleRarity { get { return _currentModuleRarity; } }
    public ModuleType ModuleType { get { return _data.ModuleType; } }
    public float Value { get { return _data.GetValue((int)_currentRarity); } }
    public bool IsEquipped { get { return _isEquipped; } }

    private void Awake()
    {
        _currentRarity = _data.Rarity;
    }

    public string GetDescription()
    {
        return StringFormating.Format(_data.GetValue((int)_currentRarity), _data.FormatType, _data.DecimalPlaces);
    }

    public void SetEquipped(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }

    public void SetModuleRarity(Rarity rarity)
    {
        _currentModuleRarity = rarity;
    }

    public void ChangeRarity(Rarity rarity)
    {
        if (rarity < _data.Rarity) return;
        if (rarity > _currentModuleRarity) return;
        _currentRarity = rarity;
    }
}
