using System;
using System.Collections.Generic;
using Command;
using Interface;
using Manager;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(IAutoMove))]
    public class Chicken : MonoBehaviour, IDeployer
    {
        [SerializeField] protected GameObject _eggPrefab;

        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private Collider _collider;

        [SerializeField] private IAutoMove _autoMoveController;
        
        private float nextDeployTime;
        [SerializeField] private float period;

        private CmdDeploy _cmdDeploy;
        
        [SerializeField] private List<int> layerTarget;
        
        [SerializeField] private DeployeableType _deployeableType;
        [SerializeField] private int cost;
        #region ACCESORS
        public DeployeableType DeployeableType => _deployeableType;
        public int Cost => cost;
        public GameObject BulletPrefab => _eggPrefab;
        public Collider Collider => _collider;
        public Rigidbody Rigidbody => _rigidBody;
        public IAutoMove AutoMove => _autoMoveController;

        #endregion
        
        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _autoMoveController = GetComponent<IAutoMove>();

            _collider.isTrigger = true;
            _rigidBody.useGravity = false;
            _rigidBody.isKinematic = true; //Inafectable
            _rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            transform.Rotate(((float)Math.PI) * Vector3.up);
            transform.Rotate(2 * Vector3.up);
            
            nextDeployTime = Time.time;

            _cmdDeploy = new CmdDeploy(this);
        }

        public void Deploy()
        {
            var turret = Instantiate(_eggPrefab, transform.position, transform.rotation);
            turret.name = CollectableType.Egg.ToString();
            turret.transform.parent = GameObject.Find("Eggs").transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!layerTarget.Contains(other.gameObject.layer)) return;
            transform.Rotate(180 * Vector3.up);
        }

        private void Update()
        {
            _autoMoveController.Travel();
            if (!(Time.time > nextDeployTime)) return;
            nextDeployTime += period;
            EventQueueManager.instance.AddCommand(_cmdDeploy);
        }
    }
}