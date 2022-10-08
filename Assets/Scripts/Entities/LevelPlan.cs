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
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(1, 2, EnemyType.BlueSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(2, 4, EnemyType.RedSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(3, 6, EnemyType.BlueSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(4, 8, EnemyType.RedSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(5, 10, EnemyType.BlueSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(0, 12, EnemyType.RedSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(1, 14, EnemyType.BlueSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(2, 16, EnemyType.RedSlime));
            levelGeneratorParamsQueue.Enqueue(new EnemySpawnParams(3, 18, EnemyType.BlueSlime));
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