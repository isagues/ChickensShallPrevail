using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private bool _isGameOver = false;
        [SerializeField] private bool _isVictory = false;

        void Start()
        {
            //   .instance.OnGameOver += OnGameOver;
        }

        private void OnGameOver(bool isVictory)
        {
            _isGameOver = true;
            _isVictory = isVictory;
            
            GlobalData.instance.SetVictoryField(_isVictory);
            
            LoadEndgameScene();
            
        }

        private void LoadEndgameScene() => SceneManager.LoadScene("Endgame");
    }
   
}