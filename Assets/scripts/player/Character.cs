using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData Data;
    private float currentHealth;

    private void Start()
    {
        currentHealth = Data.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        float finalDamage = amount - Data.defense;
        if (finalDamage < 0) finalDamage = 0;

        if (Random.value < Data.critRate)
            finalDamage *= Data.critDamage;

        currentHealth -= finalDamage;
        Debug.Log($"{Data.characterName} subit {finalDamage} dégâts. PV restants : {currentHealth}");

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log($"{Data.characterName} est KO !");
        // ici tu peux désactiver ou retirer le perso
    }

    public void UseAbility(int index, Character target)
    {
        if (index >= 0 && index < Data.abilities.Length)
            Data.abilities[index].Activate(this, target);
    }
}