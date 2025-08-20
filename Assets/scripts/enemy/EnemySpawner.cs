using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float DetectionPlayerRange = 10f; // Distance à laquelle l'ennemi détecte le joueur
    public float DetectionEnemyRange = 10f; // Distance à laquelle l'ennemi détecte un autre ennemi
    public int MaxEnemies = 5; // Nombre maximum d'ennemis pouvant être présents
    public Enemy[] enemyPrefabs; // Préfabriqués des ennemis à faire apparaître
    public float[] enemiesChances; // Chances d'apparition des ennemis (doit correspondre à enemyPrefabs)
    public Transform[] enemiesSpawnPoints; // Points de spawn des ennemis
    public float delayBetweenSpawns = 2f; // Délai entre les apparitions d'ennemis
    private float spawnTimer = 0f; // Compteur pour le délai d'apparition
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        if (enemyPrefabs.Length != enemiesChances.Length)
        {
            Debug.LogError("Le nombre de préfabriqués d'ennemis et de chances d'apparition ne correspond pas !");
            return;
        }

        // Initialisation ou autres configurations si nécessaire
        spawnTimer = delayBetweenSpawns; // On initialise le timer pour le premier spawn
        
    }

    // Update is called once per frame
    void Update()
    {   
        spawnTimer += Time.deltaTime; // On incrémente le timer

        // Vérifier si le délai entre les apparitions est écoulé
        if (spawnTimer >= delayBetweenSpawns)
        {
            TrySpawnEnemy();
            spawnTimer = 0f; // Réinitialiser le timer après un spawn
        }
    }
    
    private void TrySpawnEnemy()
    {
        // Vérifier le nombre d'ennemis présents
        Enemy[] existingEnemies = FindObjectsOfType<Enemy>();
        if (existingEnemies.Length >= MaxEnemies)
        {
            Debug.Log("Nombre maximum d'ennemis atteint, pas de spawn.");
            return;
        }

        // Choisir un ennemi aléatoire en fonction des chances
        Enemy enemyToSpawn = GetRandomEnemy();
        if (enemyToSpawn == null)
        {
            Debug.Log("Aucun ennemi à spawn, les chances n'ont pas été favorables.");
            return;
        }

        // Choisir un point de spawn aléatoire
        Transform spawnPoint = enemiesSpawnPoints[Random.Range(0, enemiesSpawnPoints.Length)];
        
        // Instancier l'ennemi
        Instantiate(enemyToSpawn.gameObject, spawnPoint.position, Quaternion.identity);
    }
    
    // Choisir un ennemi aléatoire en fonction des chances si la chance d'apparition ne tombe pas sur un enemmi aucun enemy ne sera spawn
    private Enemy GetRandomEnemy()
    {
        float totalChance = 1f;

        float randomValue = Random.Range(0f, totalChance);
        float cumulativeChance = 0f;

        for (int i = 0; i < enemiesChances.Length; i++)
        {
            cumulativeChance += enemiesChances[i];
            if (randomValue <= cumulativeChance)
            {
                return enemyPrefabs[i]; // Retourne l'ennemi correspondant à la chance tirée
            }
        }

        return null;
    }
}
