using System;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject EnemyPrefab => _enemyPrefab;
    [SerializeField] protected GameObject _enemyPrefab;
    
    private float nextShotTime = 0;
    [SerializeField] private float period;
    [SerializeField] private int count;
    private int current = 0;
    

    private void Update()
    {
        if(Time.time > nextShotTime && current < count) {
            nextShotTime += period;
            current ++;
            NewEnemy();
        }
    }

    private void NewEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
        enemy.name = "monstro";
    }
}
