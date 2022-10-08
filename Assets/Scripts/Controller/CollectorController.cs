using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Interface;
using Manager;
using UnityEngine;
using Utils;

namespace Controller
{
    [RequireComponent(typeof(Collider))]
    public class CollectorController : MonoBehaviour, ICollector  
    {
        [SerializeField] private int collectableLayer = -1;

        private Dictionary<CollectableType, int> collectables;

        private void Start()
        {
            collectables = new Dictionary<CollectableType, int>();
            foreach (var type in EnumUtil.GetValues<CollectableType>())  
            {  
                collectables[type] = 0;
            } 
        }

        private void OnCollisionEnter(Collision otherCollider)
        {
            if (collectableLayer != otherCollider.gameObject.layer) return;
            
            if (Enum.TryParse(otherCollider.gameObject.name, true, out CollectableType type))
            {
                collectables[type] += 10;
                Debug.Log(otherCollider.gameObject);
                EventsManager.instance.CollectableChange(type, collectables[type]);
            }
            
            Destroy(otherCollider.gameObject);
        }
    }
}