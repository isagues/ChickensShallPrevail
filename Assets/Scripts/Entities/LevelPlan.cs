using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class LevelPlan
    {

        public Queue<EnemySpawnParams> levelGeneratorParamsQueue;


        public LevelPlan()
        {
            levelGeneratorParamsQueue = new Queue<EnemySpawnParams>();
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(0, 0, EnemyType.RedSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(1, 5, EnemyType.BlueSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(2, 10, EnemyType.RedSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(3, 15, EnemyType.BlueSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(4, 20, EnemyType.RedSlime));
        }
    }

    public readonly struct EnemySpawnParams
    {
        public readonly int lane;
        public readonly int time;
        public readonly EnemyType enemyType;

        public EnemySpawnParams(int lane, int time, EnemyType enemyType)
        {
            this.lane = lane;
            this.time = time;
            this.enemyType = enemyType;
        }
    }
}