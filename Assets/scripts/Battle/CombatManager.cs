using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public Transform enemySpawnPoint;
    public Transform[] playerSpawnPoints;

    private void Start()
    {
        // Charger l’ennemi
        if (BattleData.enemyToFight != null)
        {
            GameObject enemyPrefab = BattleData.enemyToFight.prefab; 
            Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
            Debug.Log("Ennemi chargé : " + BattleData.enemyToFight.name);
        }

        // Charger l’équipe du joueur (depuis PlayerData)
        var team = BattleData.playerTeam;
        int spawnCount = Mathf.Min(team.Count, playerSpawnPoints.Length);

        for (int i = 0; i < spawnCount; i++)
        {
            if (team[i] != null && team[i].prefab != null)
            {
                Instantiate(team[i].prefab, playerSpawnPoints[i].position, Quaternion.identity);
                Debug.Log("Perso chargé : " + BattleData.playerTeam[i].characterName);
            }
            else
            {
                Debug.LogWarning($"⚠ Slot {i} vide ou prefab manquant !");
            }
        }
    }
}