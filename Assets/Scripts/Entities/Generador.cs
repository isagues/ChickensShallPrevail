using System;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject EnemyPrefab => _enemyPrefab;
    [SerializeField] protected GameObject _enemyPrefab;
    
    private float nextShotTime = 0;
    [SerializeField] private float period;

    private void Update()
    {
        if(Time.time > nextShotTime ) {
            nextShotTime += period;
            NewEnemy();
        }
    }

    private void NewEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, transform.position + Vector3.forward * 5, transform.rotation);
        enemy.name = "monstro";
    }
}
