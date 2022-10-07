using System;
using UnityEngine;

namespace Manager
{
    public class EventsManager : MonoBehaviour
    {
        public static EventsManager instance;

        #region UNITY_EVENTS
        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }
        #endregion

        #region GAME_MANAGER
        public event Action<bool> OnGameOver;
        public event Action<float, float> OnCharacterLifeChange;
        public event Action<int> OnCoinsChange;

        public void EventGameOver(bool isVictory)
        {
            Debug.Log("por ganar");
            Debug.Log(isVictory);
            OnGameOver?.Invoke(isVictory);
        }
        
        public void CharacterLifeChange(float currentLife, float maxLife)
        {
            OnCharacterLifeChange?.Invoke(currentLife, maxLife);
        }
        
        public void CoinsChange(int currentCoins)
        {
            OnCoinsChange?.Invoke(currentCoins);
        }
        #endregion
    }
}