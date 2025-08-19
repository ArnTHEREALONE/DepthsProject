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
        var team = PlayerData.Instance.activeTeam;
        for (int i = 0; i < ((ICollection<CharacterData>)team).Count; i++)
        {
            GameObject charPrefab = team[i].prefab;
            Instantiate(charPrefab, playerSpawnPoints[i].position, Quaternion.identity);
            Debug.Log("Perso chargé : " + team[i].characterName);
        }
    }
}