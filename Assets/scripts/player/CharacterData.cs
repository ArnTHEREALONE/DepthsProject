using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [Header("Infos générales")]
    public string characterName;
    public Sprite portrait; // image UI
    public GameObject prefab;

    [Header("Stats")]
    public float maxHealth;
    public float damage;
    public float defense;
    public float speed;
    public float critRate;     // 0 à 1
    public float critDamage;   // multiplicateur (ex: 2 = double dégâts)

    [Header("Compétences")]
    public Ability[] abilities = new Ability[3];
}