using System;
using System.Collections.Generic;
using Command;
using Flyweight;
using Interface;
using Manager;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(IAutoMove))]
    public class Chicken : MonoBehaviour, IDeployer
    {
        private ChickenStat _stats;
        private ChickenStat Stats => _stats ??= GetComponent<StatSupplier>().GetStat<ChickenStat>();
        
        public int Period => Stats.Period;
        public GameObject DeployablePrefab => Stats.EggPrefab;

        public GameObject TransformPrefab => Stats.TransformPrefab;
        public List<int> LayerTarget => Stats.LayerTarget;
        
        private float _nextDeployTime;

        private CmdDeploy _cmdDeploy;

        private float _transformTime;
        public Collider Collider { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public IAutoMove AutoMove { get; private set; }

        private Transform _eggsTransform;

        private void Awake()
        {
            _eggsTransform = GameObject.Find("Eggs").transform;
            
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();
            AutoMove = GetComponent<IAutoMove>();

            Collider.isTrigger = true;
            Rigidbody.useGravity = false;
            Rigidbody.isKinematic = true; //Inafectable
            Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            transform.Rotate(((float)Math.PI) * Vector3.up);
            transform.Rotate(2 * Vector3.up);
            
            _nextDeployTime = Time.time;

            _transformTime = Time.time + Stats.TransformTime;

            _cmdDeploy = new CmdDeploy(this);
        }

        public void Deploy()
        {
            var t = transform;
            var turret = Instantiate(DeployablePrefab, t.position, t.rotation);
            turret.name = CollectableType.Egg.ToString();
            turret.transform.parent = _eggsTransform;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!LayerTarget.Contains(other.gameObject.layer)) return;
            transform.Rotate(180 * Vector3.up);
        }

        private void Update()
        {
            AutoMove.Travel();
            if ((Time.time > _nextDeployTime))
            {
                _nextDeployTime += Period;
                Deploy();
                // EventQueueManager.instance.AddCommand(_cmdDeploy);
            }
            

            if (Time.time > _transformTime)
            {
                SelfDestroy();
            }
        }
        
        protected void SelfDestroy()
        {
            BeforeDestroy();
            Destroy(gameObject);
        }

        private void BeforeDestroy()
        {
            var t = transform;
            var suicideChicken = Instantiate(TransformPrefab, t.position, t.rotation);
            suicideChicken.name = t.name;
            suicideChicken.transform.parent = t.parent;
        }
    }
}