using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class BattleTrigger : MonoBehaviour
{
    public Enemy enemy; // référence vers l'ennemi touché
    public float detectionRadius = 5f; // rayon de détection pour déclencher le combat
    private bool battleStarted = false; // pour éviter de déclencher plusieurs fois le combat

    private void Start()
    {
        if (enemy == null) enemy = GetComponent<Enemy>();
    }
    
    private void Update()
    {
        if (battleStarted) return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log("Le joueur est entré dans le rayon de combat !");
                StartBattle(enemy);
                break;
            }
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
        BattleData.playerTeam = PlayerData.Instance.activeTeam.ToList(); // on enregistre l'équipe du joueur

        // Charger la scène de combat
        SceneManager.LoadScene("BattleScene");
    }
}