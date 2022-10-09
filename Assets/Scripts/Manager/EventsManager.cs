using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;
using Utils;

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
            
            OnCollectableChange = new Dictionary<CollectableType, Action<int>>();
            foreach (var type in EnumUtil.GetValues<CollectableType>())  
            {  
                OnCollectableChange[type] = _ => {};
            } 
        }
        #endregion

        #region GAME_MANAGE
        public event Action<bool> OnGameOver;
        public event Action<float, float> OnCharacterLifeChange;
        public event Action<Turret> OnTurretChange; 
        
        private Dictionary<CollectableType, Action<int>> OnCollectableChange;

        public void EventGameOver(bool isVictory)
        {
            OnGameOver?.Invoke(isVictory);
        }
        
        public void CharacterLifeChange(float currentLife, float maxLife)
        {
            OnCharacterLifeChange?.Invoke(currentLife, maxLife);
        }
        
        public void TurretChange(Turret turret)
        {
            Debug.Log("changing to turret" + turret.TurretType);
            OnTurretChange?.Invoke(turret);
        }
        
        public void CollectableChange(CollectableType type, int currentValue)
        {
            OnCollectableChange[type].Invoke(currentValue);
        }
        
        public void AddOnCollectableChangeHandler(CollectableType type, Action<int> handler)
        {
            OnCollectableChange[type] += handler;
        }
        
        #endregion
    }
}