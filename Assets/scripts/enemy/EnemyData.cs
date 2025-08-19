using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public string monsterClass;
    public float maxHealth;
    public float damage;
    public float defense;
    public float speed;
    public float critRate;     // taux critique (0 à 1)
    public float critDamage;   // multiplicateur critique (ex: 2 = double dégâts)
}