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

        [SerializeField] private CharacterStat characterStat;
    
        [SerializeField] private KeyCode _moveFoward = KeyCode.W;
        [SerializeField] private KeyCode _moveBack = KeyCode.S;
        [SerializeField] private KeyCode _moveRight = KeyCode.D;
        [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    
        [SerializeField] private KeyCode _deploy = KeyCode.E;

        [SerializeField] private KeyCode _weaponSlot1 = KeyCode.Alpha1;
        [SerializeField] private KeyCode _weaponSlot2 = KeyCode.Alpha2;
        [SerializeField] private KeyCode _weaponSlot3 = KeyCode.Alpha3;
    
    
        [SerializeField] private KeyCode _setVictory = KeyCode.V;
        [SerializeField] private KeyCode _setDefeat = KeyCode.L;

        private CmdMovement _cmdMoveForward; 
        private CmdMovement _cmdMoveBackward;
        private CmdRotation _cmdRotateRight;
        private CmdRotation _cmdRotateLeft;

        public List<Deployeable> Deployeables => characterStat.Deployeables;
        void Start()
        {
            _movementController = GetComponent<MovementController>();
            _collectorController = GetComponent<CollectorController>();
        
            _cmdMoveForward = new CmdMovement(_movementController, Vector3.forward);
            _cmdMoveBackward = new CmdMovement(_movementController, -Vector3.forward);
            _cmdRotateRight = new CmdRotation(_movementController, Vector3.up);
            _cmdRotateLeft = new CmdRotation(_movementController, -Vector3.up);

            ChangeDeployeable(0);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(_moveFoward)) EventQueueManager.instance.AddCommand(_cmdMoveForward);
            if (Input.GetKey(_moveBack)) EventQueueManager.instance.AddCommand(_cmdMoveBackward);
            if (Input.GetKey(_moveRight)) EventQueueManager.instance.AddCommand(_cmdRotateRight);
            if (Input.GetKey(_moveLeft)) EventQueueManager.instance.AddCommand(_cmdRotateLeft);
            if (Input.GetKeyDown(_setVictory)) EventsManager.instance.EventGameOver(true);
            if (Input.GetKeyDown(_setDefeat)) EventsManager.instance.EventGameOver(false);

            if (Input.GetKeyDown(_deploy)) DeployCurrentInstance();

            if(Input.GetKey(_weaponSlot1)) ChangeDeployeable(0);
            if(Input.GetKey(_weaponSlot2)) ChangeDeployeable(1);
            if(Input.GetKey(_weaponSlot3)) ChangeDeployeable(2);
        }

        private void DeployCurrentInstance()
        {
            if (!_collectorController.Expend(CollectableType.Egg, _currentDeployable.Cost)) return;
        
            var deployeable = Instantiate(_currentDeployable, transform.position + 2*Vector3.forward, transform.rotation);
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
