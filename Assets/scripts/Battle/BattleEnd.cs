using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleEnd : MonoBehaviour
{
    public void EndBattle()
    {
        SceneManager.LoadScene("test johan"); // revenir sur la map
    }
}