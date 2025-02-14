using UnityEngine;


public class Module : MonoBehaviour
{
    [SerializeField] private ModuleScriptableObject _data;
    [SerializeField] private bool _isEquipped = false;

    public string Name { get { return _data.Name; } }
    public Rarity BaseRarity { get { return _data.Rarity; } }
    public bool IsNone { get { return _data.IsNone; } }
    public Sprite Icon { get { return _data.Icon; } }
    public bool IsEquipped { get { return _isEquipped; } }

    //public float GetValue(Rarity rarity)
    //{
    //    return _data.Value((int)rarity);
    //}

    public void ChangeEquipped(bool isEquipped)
    {
        _isEquipped = isEquipped;
    }

    public string CreateDescription(Rarity rarity)
    {
        if (_data.IsNonEpic || _data.IsNone) return "";

        string description = string.Empty;
        description += _data.Prefix;
        description += _data.ValueDisplay((int)rarity);
        description += _data.Suffix;

        return description;
    }
}
