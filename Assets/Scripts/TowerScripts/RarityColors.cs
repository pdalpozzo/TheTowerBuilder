using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity { COMMON, RARE, EPIC, LEGENDARY, MYTHIC, ANCESTRAL }; 

public class RarityColors : MonoBehaviour
{
    [SerializeField] private static Color _common = new(1f, 1f, 1f, 1f);                // white
    [SerializeField] private static Color _rare = new(.06f, .89f, .97f, 1f);            // blue
    [SerializeField] private static Color _epic = new(.96f, .43f, .97f, 1f);            // purple
    [SerializeField] private static Color _legendary = new(.97f, .59f, .08f, 1f);       // orange
    [SerializeField] private static Color _mythic = new(.99f, .31f, .31f, 1f);          // red
    [SerializeField] private static Color _ancestral = new(.24f, .82f, .15f, 1f);       // green
    [SerializeField] private static Color _maxed = new(.86f, .72f, .07f, 1f);           // gold
    [SerializeField] private static Color _fail = new(.99f, .31f, .31f, 1f);            // bright red 
    [SerializeField] private static Color _inputEnable = new(.21f, .19f, .46f, 1f);     // dark blue 
    [SerializeField] private static Color _inputDisable = new(.09f, .08f, .21f, 1f);    // dark dark blue

    public static Color GetColor(Rarity rarity)
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

    public static Color GetMax()
    {
        return _maxed;
    }

    public static Color GetFail()
    {
        return _fail;
    }

    public static Color GetInputEnable()
    {
        return _inputEnable;
    }

    public static Color GetInputDisable()
    {
        return _inputDisable;
    }
}
