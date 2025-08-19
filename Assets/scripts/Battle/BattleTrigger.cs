using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleTrigger : MonoBehaviour
{
    public Enemy enemy; // référence vers l'ennemi touché
    public Transform player; // référence vers le joueur
    public float detectionRadius = 5f; // rayon de détection pour déclencher le combat
    private bool battleStarted = false; // pour éviter de déclencher plusieurs fois le combat

    private void Start()
    {
        if (enemy == null) enemy = GetComponent<Enemy>();
    }
    
    private void Update()
    {
        if (battleStarted || player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= detectionRadius)
        {
            Debug.Log("Le joueur est entré dans le rayon de combat !");
            StartBattle(enemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur rencontre un ennemi !");
            StartBattle(enemy);
        }
    }

    private void StartBattle(Enemy enemy)
    {
        // On enregistre les infos du combat
        BattleData.enemyToFight = enemy.data; // on enregistre les stats de cet ennemi

        // Charger la scène de combat
        SceneManager.LoadScene("BattleScene");
    }
}