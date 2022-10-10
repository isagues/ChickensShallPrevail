using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            EventsManager.instance.OnGameOver += OnGameOver;
        }

        private static void OnGameOver(bool isVictory)
        {
            GlobalData.instance.IsVictory = isVictory;
            SceneManager.LoadScene("Endgame");
        }
    }
}