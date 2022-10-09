using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class LevelPlan
    {

        [SerializeField] private List<EnemySpawnParams> enemySpawnPlan;

        public bool IsEmpty()
        {
            return enemySpawnPlan.Count == 0;
        }

        public bool IsSpawnTime(float time)
        {
            return !IsEmpty() && time > enemySpawnPlan[0].time;
        }

        public EnemySpawnParams PopEnemySpawnParam()
        {
            var ret = enemySpawnPlan[0];
            enemySpawnPlan.RemoveAt(0);
            return ret;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }

    [Serializable]
    public struct EnemySpawnParams
    {
        public int         lane;
        public float       time;
        public EnemyType   enemyType;

        public EnemySpawnParams(int lane, float time, EnemyType enemyType)
        {
            this.lane = lane;
            this.time = time;
            this.enemyType = enemyType;
        }
        
        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}