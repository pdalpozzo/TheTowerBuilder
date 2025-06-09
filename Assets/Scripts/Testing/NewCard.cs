using UnityEngine;

public class NewCard : MonoBehaviour
{
    [SerializeField] private Rarity _rarity;
    [SerializeField] private Sprite _icon;

    public Rarity Rarity { get { return _rarity; } }
    public Sprite Icon { get { return _icon; } }
}
