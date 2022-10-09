using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Manager
{
    public class GeneratorManager : MonoBehaviour
    {
        public static GeneratorManager instance;
        public Dictionary<EnemyType, GameObject> enemies;
        
        [SerializeField] 
        private float laneCount;

        public float LaneCount => laneCount;

        [SerializeField] 
        private int level;

        private LevelPlan _levelPlan;

        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }

        private void Start()
        {
            enemies = new Dictionary<EnemyType, GameObject>();
            LoadPrefabs();
            
            _levelPlan = JsonUtility.FromJson<LevelPlan>(Resources.Load<TextAsset>($"Levels/level{level}").text);
        }

        private void LoadPrefabs()
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
            var time = Time.time;
            while (_levelPlan.IsSpawnTime(time))
            {
                var enemySpawnParams = _levelPlan.PopEnemySpawnParam();
                GenerateNewEnemy(enemySpawnParams.lane, enemySpawnParams.enemyType);
            }
        }

        private void GenerateNewEnemy(int lane, EnemyType enemyType)
        {
            var newPosition = transform.position;
            var width = GetComponent<Renderer>().bounds.size.x;
            if (lane >= laneCount) throw new Exception($"Lane out of bounds, max lane is {laneCount}");
            newPosition.x += Mathf.Lerp( -width/2, width/2, lane / laneCount); 
         
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