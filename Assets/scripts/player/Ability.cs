using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "ScriptableObjects/Ability")]
public class Ability : ScriptableObject
{
    public string abilityName;
    public Sprite icon;
    public float cooldown;

    // Effet (exemple simple)
    public float damageMultiplier = 1f;

    public virtual void Activate(Character user, Character target)
    {
        float finalDamage = user.Data.damage * damageMultiplier;
        target.TakeDamage(finalDamage);
        Debug.Log($"{user.Data.characterName} utilise {abilityName} sur {target.Data.characterName} !");
    }
}