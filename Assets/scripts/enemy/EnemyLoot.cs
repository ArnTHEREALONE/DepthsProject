using UnityEngine;

[System.Serializable]
public class LootEntry
{
    public ItemData item;      // l'item
    [Range(0f, 100f)]
    public float dropChance;   // en pourcentage
}

[CreateAssetMenu(fileName = "EnemyLoot", menuName = "ScriptableObjects/EnemyLoot")]
public class EnemyLoot : ScriptableObject
{
    public LootEntry[] lootTable;
}