using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private bool _isGameOver = false;
        [SerializeField] private bool _isVictory = false;
        [SerializeField] private Text _gameoverMessage;

        private void Start()
        {
            EventsManager.instance.OnGameOver += OnGameOver;
            _gameoverMessage.text = string.Empty;
        }


        private void OnGameOver(bool isVictory)
        {
            _isGameOver = true;
            _isVictory = isVictory;

            _gameoverMessage.text = isVictory ? "Victory" : "Defeat";
            _gameoverMessage.color = isVictory ? Color.cyan : Color.red;
            
            GlobalData.instance.SetVictoryField(_isVictory);
            
            LoadEndgameScene();
            
        }

        private void LoadEndgameScene() => SceneManager.LoadScene("Endgame");
    }
   
}