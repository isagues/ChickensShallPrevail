using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    public class GeneratorManager : MonoBehaviour
    {
        public static GeneratorManager instance;
        public Dictionary<EnemyType, GameObject> enemies;
        
        [SerializeField] 
        private float _generatorDistance;

        public float GeneratorDistance => _generatorDistance;

        [SerializeField] 
        private LevelPlan _levelPlan;
        
        public Queue<EnemySpawnParams> EnemySpawnQueue => _levelPlan.levelGeneratorParamsQueue;
        
        
        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }

        void Start()
        {
            enemies = new Dictionary<EnemyType, GameObject>();
            LoadPrefabs();
        }

        void LoadPrefabs()
        {
            var resources = Resources.LoadAll("Prefabs/Enemies");
            foreach (var thisObject in resources)
            {
                var objectType = thisObject.GetType().Name;
                if (objectType != "GameObject") continue;

                if (Enum.TryParse(thisObject.name, true, out EnemyType type))
                {
                    enemies.Add(type, (GameObject)thisObject);
                }
            }
        }
        
        private void Update()
        {
            while (EnemySpawnQueue.Count > 0)
            {
                if (Time.time > EnemySpawnQueue.Peek().time)
                {
                    EnemySpawnParams enemySpawnParams = EnemySpawnQueue.Dequeue();
                    GenerateNewEnemy(enemySpawnParams.lane, enemySpawnParams.enemyType);
                }
                else
                {
                    break;
                }
            }
        }

        private void GenerateNewEnemy(int lane, EnemyType enemyType)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += lane * GeneratorDistance;
         
            if (enemies.ContainsKey(enemyType))
            {
                var enemy = Instantiate(enemies[enemyType], newPosition, transform.rotation);
                enemy.name = enemyType.ToString();
            }
            else
            {
                // Debug.Log(enemyType.ToString() + " was not found");
            }
            
        }

        
    }
}