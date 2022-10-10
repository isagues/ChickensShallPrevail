using System.Collections.Generic;
using Command;
using Controller;
using Flyweight;
using Manager;
using UnityEngine;

namespace Entities
{
    public class Character : MonoBehaviour
    {
        private MovementController _movementController;
        private CollectorController _collectorController;
    
        private Deployeable _currentDeployable;

        private CharacterStat _stats;
    
        [SerializeField] private KeyCode moveForward = KeyCode.W;
        [SerializeField] private KeyCode moveBack = KeyCode.S;
        [SerializeField] private KeyCode moveRight = KeyCode.D;
        [SerializeField] private KeyCode moveLeft = KeyCode.A;
    
        [SerializeField] private KeyCode deploy = KeyCode.E;

        [SerializeField] private KeyCode weaponSlot1 = KeyCode.Alpha1;
        [SerializeField] private KeyCode weaponSlot2 = KeyCode.Alpha2;
        [SerializeField] private KeyCode weaponSlot3 = KeyCode.Alpha3;
    
    
        [SerializeField] private KeyCode setVictory = KeyCode.V;
        [SerializeField] private KeyCode setDefeat = KeyCode.L;

        private CmdMovement _cmdMoveForward; 
        private CmdMovement _cmdMoveBackward;
        private CmdRotation _cmdRotateRight;
        private CmdRotation _cmdRotateLeft;

        public List<Deployeable> Deployeables => _stats.Deployeables;

        private void Awake()
        {
            _stats = GetComponent<StatSupplier>().GetStat<CharacterStat>();
            
            _movementController = GetComponent<MovementController>();
            _collectorController = GetComponent<CollectorController>();
        
            _cmdMoveForward = new CmdMovement(_movementController, Vector3.forward);
            _cmdMoveBackward = new CmdMovement(_movementController, -Vector3.forward);
            _cmdRotateRight = new CmdRotation(_movementController, Vector3.up);
            _cmdRotateLeft = new CmdRotation(_movementController, -Vector3.up);
        }
        
        private void Start()
        {
            ChangeDeployeable(0);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKey(moveForward)) EventQueueManager.instance.AddCommand(_cmdMoveForward);
            if (Input.GetKey(moveBack)) EventQueueManager.instance.AddCommand(_cmdMoveBackward);
            if (Input.GetKey(moveRight)) EventQueueManager.instance.AddCommand(_cmdRotateRight);
            if (Input.GetKey(moveLeft)) EventQueueManager.instance.AddCommand(_cmdRotateLeft);
            if (Input.GetKeyDown(setVictory)) EventsManager.instance.EventGameOver(true);
            if (Input.GetKeyDown(setDefeat)) EventsManager.instance.EventGameOver(false);

            if (Input.GetKeyDown(deploy)) DeployCurrentInstance();

            if(Input.GetKey(weaponSlot1)) ChangeDeployeable(0);
            if(Input.GetKey(weaponSlot2)) ChangeDeployeable(1);
            if(Input.GetKey(weaponSlot3)) ChangeDeployeable(2);
        }

        private void DeployCurrentInstance()
        {
            if (!_collectorController.Expend(CollectableType.Egg, _currentDeployable.Cost)) return;

            var t = transform;
            var deployeable = Instantiate(_currentDeployable, t.position + 2*Vector3.forward, t.rotation);
            deployeable.name = name;
            deployeable.transform.parent = GameObject.Find("Deployeables").transform;
            deployeable.gameObject.SetActive(true);
        }

        private void ChangeDeployeable(int index)
        {
            _currentDeployable = Deployeables[index];
            EventsManager.instance.DeployableChange(_currentDeployable);
        }
    }
}
