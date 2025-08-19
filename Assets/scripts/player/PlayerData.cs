using UnityEngine;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    [Header("Inventaire")]
    public List<ItemData> inventory = new List<ItemData>();

    [Header("Personnages débloqués")]
    public List<CharacterData> unlockedCharacters = new List<CharacterData>();

    [Header("Team active (3 persos max)")]
    public List<CharacterData> activeTeam = new List<CharacterData>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddItem(ItemData item)
    {
        inventory.Add(item);
        Debug.Log($"Ajouté {item.itemName} à l’inventaire !");
    }

    public void UnlockCharacter(CharacterData character)
    {
        if (!unlockedCharacters.Contains(character))
        {
            unlockedCharacters.Add(character);
            Debug.Log($"{character.characterName} débloqué !");
        }
    }

    public void SetActiveTeam(List<CharacterData> newTeam)
    {
        if (newTeam.Count <= 3)
        {
            activeTeam = newTeam;
            Debug.Log("Nouvelle team sélectionnée !");
        }
        else
        {
            Debug.LogWarning("La team ne peut pas dépasser 3 persos !");
        }
    }
}