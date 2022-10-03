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

        public void EventGameOver(bool isVictory)
        {
            if (OnGameOver != null) OnGameOver(isVictory);
        }
        
        public void CharacterLifeChange(float currentLife, float maxLife)
        {
            OnCharacterLifeChange?.Invoke(currentLife, maxLife);
        }
        #endregion
    }
}