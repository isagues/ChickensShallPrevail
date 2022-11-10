using System;
using System.Collections.Generic;
using Entities;
using Flyweight;
using Interface;
using Manager;
using UnityEngine;
using Utils;

namespace Controller
{
    [RequireComponent(typeof(Collider))]
    public class CollectorController : MonoBehaviour, ICollector  
    {
        private ICollectorStats _stats;
        private ICollectorStats Stats => _stats ??= GetComponent<StatSupplier>().GetStat<ICollectorStats>();

        private Dictionary<CollectableType, int> _collectables;
        
        private int CollectableLayer => Stats.CollectableLayer;

        private void Awake()
        {
            _collectables = new Dictionary<CollectableType, int>();
        }
        
        private void Start()
        {
            foreach (var type in EnumUtil.GetValues<CollectableType>())  
            {  
                _collectables[type] = 0;
            } 
        }

        private void OnCollisionEnter(Collision otherCollider)
        {
            if (CollectableLayer != otherCollider.gameObject.layer) return;
            
            if (Enum.TryParse(otherCollider.gameObject.name, true, out CollectableType type))
            {
                _collectables[type] += 10;
                NotifyCollectableChane(type);
            }
            
            Destroy(otherCollider.gameObject);
        }

        private void NotifyCollectableChane(CollectableType type)
        {
            EventsManager.instance.CollectableChange(type, _collectables[type]);
        }
        
        public bool Expend(CollectableType type, int amount)
        {
            if (_collectables[type] < amount) return false;
            _collectables[type] -= amount;
            NotifyCollectableChane(type);
            return true;
        }
    }
    
    public interface ICollectorStats
    {
        int CollectableLayer { get; }
    }
}