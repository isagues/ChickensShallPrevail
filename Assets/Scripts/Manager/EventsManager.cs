using System;
using System.Collections.Generic;
using Entities;
using Entities.Turrets;
using Interface;
using UnityEngine;
using Utils;

namespace Manager
{
    public class EventsManager : MonoBehaviour
    {
        public static EventsManager instance;
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }
            instance = this;
            
            _onCollectableChange = new Dictionary<CollectableType, Action<int>>();
            foreach (var type in EnumUtil.GetValues<CollectableType>())  
            {  
                _onCollectableChange[type] = _ => {};
            } 
        }
        
        public event Action<bool>                   OnGameOver;
        public event Action<float, float>           OnFarmLifeChange;
        public event Action<Deployeable>            OnDeployableChange;
        public event Action<EnemyType, GameObject>  OnEnemySpawn;
        public event Action<int>                    OnEnemyKilled;
        
        private Dictionary<CollectableType, Action<int>> _onCollectableChange;

        public void EventGameOver(bool isVictory)
        {
            OnGameOver?.Invoke(isVictory);
        }
        
        public void FarmLifeChange(float currentLife, float maxLife)
        {
            OnFarmLifeChange?.Invoke(currentLife, maxLife);
        }
        
        public void DeployableChange(Deployeable deployeable)
        {
            OnDeployableChange?.Invoke(deployeable);
        }
        
        public void CollectableChange(CollectableType type, int currentValue)
        {
            _onCollectableChange[type].Invoke(currentValue);
        }
        
        public void AddOnCollectableChangeHandler(CollectableType type, Action<int> handler)
        {
            _onCollectableChange[type] += handler;
        }

        public void EnemySpawn(EnemyType type,GameObject enemy)
        {
            OnEnemySpawn?.Invoke(type, enemy);
        }
        
        public void EnemyKilled(int id)
        {
            OnEnemyKilled?.Invoke(id);
        }
    }
}