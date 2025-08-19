using UnityEngine;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    [Header("Inventaire global du joueur")]
    public List<ItemData> inventory = new List<ItemData>();

    [Header("Personnages débloqués")]
    public List<CharacterData> unlockedCharacters = new List<CharacterData>();

    [Header("Team active (3 slots fixes)")]
    public CharacterData[] activeTeam = new CharacterData[3]; // ← tableau au lieu de List

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --- Inventaire ---
    public void AddItem(ItemData item)
    {
        inventory.Add(item);
        Debug.Log($"Ajouté {item.itemName} à l’inventaire !");
    }

    public void RemoveItem(ItemData item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log($"Retiré {item.itemName} de l’inventaire !");
        }
    }

    // --- Débloquer un perso ---
    public void UnlockCharacter(CharacterData character)
    {
        if (!unlockedCharacters.Contains(character))
        {
            unlockedCharacters.Add(character);
            Debug.Log($"{character.characterName} a été débloqué !");
        }
    }

    // --- Team active ---
    public void SetActiveTeam(CharacterData[] newTeam)
    {
        if (newTeam.Length != 3)
        {
            Debug.LogWarning("L’équipe doit avoir exactement 3 slots !");
            return;
        }

        activeTeam = newTeam;
        Debug.Log("Nouvelle équipe active définie !");
    }

    /// <summary>
    /// Place un personnage dans un slot précis (0,1,2).
    /// Remplace l'ancien si slot déjà occupé.
    /// </summary>
    public void AddToActiveTeam(CharacterData character, int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= activeTeam.Length)
        {
            Debug.LogWarning("Index de slot invalide !");
            return;
        }

        if (!unlockedCharacters.Contains(character))
        {
            Debug.LogWarning($"{character.characterName} n’est pas encore débloqué !");
            return;
        }

        activeTeam[slotIndex] = character;
        Debug.Log($"{character.characterName} assigné au slot {slotIndex} !");
    }

    public void RemoveFromActiveTeam(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= activeTeam.Length)
        {
            Debug.LogWarning("Index de slot invalide !");
            return;
        }

        if (activeTeam[slotIndex] != null)
        {
            Debug.Log($"{activeTeam[slotIndex].characterName} retiré du slot {slotIndex} !");
            activeTeam[slotIndex] = null;
        }
    }
}
