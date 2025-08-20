using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string category; // ex: "Arme", "Armure", "Potion"
    public Sprite icon;        // facultatif, pour l’UI
    public GameObject prefab;  // objet à instancier si drop
}