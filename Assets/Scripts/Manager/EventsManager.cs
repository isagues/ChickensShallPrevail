using System;
using UnityEngine;

namespace Manager
{
    public class EventsManager : MonoBehaviour
    {
        static public EventsManager instance;

        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }
        
        public event Action<bool> OnGameOver;

        public void EventGameOver(bool isVictory)
        {
            if (OnGameOver != null) OnGameOver(isVictory);
        }
    }
}