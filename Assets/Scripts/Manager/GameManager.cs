using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public bool GameOver => _isGameOver;
        [SerializeField] private bool _isGameOver = false;
        [SerializeField] private bool _isVictory = false;

        private void Start()
        {
            EventsManager.instance.OnGameOver += OnGameOver;
        }

        private void OnGameOver(bool isVictory)
        {
            _isGameOver = true;
            _isVictory = isVictory;
            
            SetVictoryField(isVictory);
            GlobalData.instance.SetVictoryField(_isVictory);
            LoadEndgameScene();
            
        }
        public void SetVictoryField(bool isVictory) => _isVictory = isVictory;
        private void LoadEndgameScene() => SceneManager.LoadScene("Endgame");
    }
   
}