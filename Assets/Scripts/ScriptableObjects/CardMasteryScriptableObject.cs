using UnityEngine;

[CreateAssetMenu(fileName = "Card Mastery", menuName = "ScriptableObjects/Card Mastery")]
public class CardMasteryScriptableObject : ScriptableObject
{
    [SerializeField] private string _masteryName;
    [SerializeField] private string _description;

    public string Name { get { return _masteryName; } }
    public string Description { get { return _description; } }
}
