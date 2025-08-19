using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;   // assigné depuis l’Inspector
    public EnemyLoot lootTable;

    private float currentHealth;

    private void Start()
    {
        currentHealth = data.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        // Calcul dégâts avec défense
        float finalDamage = amount - data.defense;
        if (finalDamage < 0) finalDamage = 0;

        // Gestion critique
        if (Random.value < data.critRate)
        {
            finalDamage *= data.critDamage;
            Debug.Log("Coup critique !");
        }

        currentHealth -= finalDamage;
        Debug.Log($"{gameObject.name} a pris {finalDamage} dégâts. PV restants : {currentHealth}");

        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} est mort.");
        Destroy(gameObject);

        if (lootTable != null)
        {
            foreach (var entry in lootTable.lootTable)
            {
                float roll = Random.Range(0f, 100f);
                if (roll <= entry.dropChance)
                {
                    Instantiate(entry.item.prefab, transform.position, Quaternion.identity);
                    Debug.Log($"{entry.item.itemName} drop !");
                }
            }
        }
    }

    public virtual void Move()
    {
        // Logique de déplacement par défaut
        transform.Translate(Vector3.forward * data.speed * Time.deltaTime);
    }
}