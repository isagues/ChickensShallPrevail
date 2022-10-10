using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Manager
{
    public class GeneratorManager : MonoBehaviour
    {
        [SerializeField] 
        private float laneCount;
        public float LaneCount => laneCount;

        [SerializeField] 
        private int level;

        private LevelPlan _levelPlan;
        private int _enemyCount = 0;
        private Dictionary<EnemyType, GameObject> _enemyPrefabs;
        private Renderer _renderer;
        private Transform _enemiesContainer;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _enemiesContainer = GameObject.Find("Enemies").transform;
            
            _enemyPrefabs = new Dictionary<EnemyType, GameObject>();
            LoadPrefabs();
            
            _levelPlan = JsonUtility.FromJson<LevelPlan>(Resources.Load<TextAsset>($"Levels/level{level}").text);

            EventsManager.instance.OnEnemySpawn  += OnEnemySpawn;
            EventsManager.instance.OnEnemyKilled += OnEnemyKilled;
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
                    _enemyPrefabs.Add(type, (GameObject)thisObject);
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
            var width = _renderer.bounds.size.x;
            if (lane >= laneCount) throw new Exception($"Lane out of bounds, max lane is {laneCount}");
            newPosition.x += Mathf.Lerp( -width/2, width/2, lane / laneCount); 
         
            if (_enemyPrefabs.ContainsKey(enemyType))
            {
                var enemy = Instantiate(_enemyPrefabs[enemyType], newPosition, transform.rotation);
                enemy.name = enemyType.ToString();
                enemy.transform.parent = _enemiesContainer;
                EventsManager.instance.EnemySpawn(enemyType, enemy);
            }

        }
        
        private void OnEnemySpawn(EnemyType _, GameObject __)
        {
            _enemyCount++;
        }

        private void OnEnemyKilled(int _)
        {
            _enemyCount--;
            if (_enemyCount == 0 && _levelPlan.IsEmpty())
            {
                EventsManager.instance.EventGameOver(true);
            }
            
        }
    }
}