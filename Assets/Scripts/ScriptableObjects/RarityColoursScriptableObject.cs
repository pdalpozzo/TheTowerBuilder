using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "ScriptableObjects/Color")]
public class RarityScriptableObject : ScriptableObject
{
    [SerializeField] private Color _common = new Color(255, 255, 255, 255);     // white
    [SerializeField] private Color _rare = new Color(17, 227, 247, 255);        // blue
    [SerializeField] private Color _epic = new Color(244, 111, 247, 255);       // purple
    [SerializeField] private Color _legendary = new Color(248, 151, 20, 255);   // orange
    [SerializeField] private Color _mythic = new Color(253, 79, 80, 255);       // red
    [SerializeField] private Color _ancestral = new(62, 210, 39, 255);          // green

    public Color GetColor(Rarity rarity)
    {
        // new way to do switch statements?
        return rarity switch
        {
            Rarity.COMMON => _common,
            Rarity.RARE => _rare,
            Rarity.EPIC => _epic,
            Rarity.LEGENDARY => _legendary,
            Rarity.MYTHIC => _mythic,
            Rarity.ANCESTRAL => _ancestral,
            _ => _common,
        };
    }
}
