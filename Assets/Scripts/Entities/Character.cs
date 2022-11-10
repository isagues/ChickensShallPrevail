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
        private CharacterStat _stats;
        private CharacterStat Stats => _stats ??= GetComponent<StatSupplier>().GetStat<CharacterStat>();
        
        private List<Deployeable> Deployeables => Stats.Deployeables;
        
        private MovementController _movementController;
        private CollectorController _collectorController;
    
        private Deployeable _currentDeployable;


        [SerializeField] private KeyCode moveForward = KeyCode.W;
        [SerializeField] private KeyCode moveBack = KeyCode.S;
        [SerializeField] private KeyCode moveRight = KeyCode.D;
        [SerializeField] private KeyCode moveLeft = KeyCode.A;
    
        [SerializeField] private KeyCode deploy = KeyCode.E;

        [SerializeField] private KeyCode weaponSlot1 = KeyCode.Alpha1;
        [SerializeField] private KeyCode weaponSlot2 = KeyCode.Alpha2;
        [SerializeField] private KeyCode weaponSlot3 = KeyCode.Alpha3;
        [SerializeField] private KeyCode weaponSlot4 = KeyCode.Alpha9;
    
    
        [SerializeField] private KeyCode setVictory = KeyCode.V;
        [SerializeField] private KeyCode setDefeat = KeyCode.L;

        private CmdMovement _cmdMoveForward; 
        private CmdMovement _cmdMoveBackward;
        private CmdMovement _cmdMoveRight;
        private CmdMovement _cmdMoveLeft;

        private Transform _deployeablesTransform;

        private void Awake()
        {
            _movementController = GetComponent<MovementController>();
            _collectorController = GetComponent<CollectorController>();
            _deployeablesTransform = GameObject.Find("Deployeables").transform;
        
            _cmdMoveForward     = new CmdMovement(_movementController, Vector3.forward);
            _cmdMoveBackward    = new CmdMovement(_movementController, Vector3.back);
            _cmdMoveRight       = new CmdMovement(_movementController, Vector3.right);
            _cmdMoveLeft        = new CmdMovement(_movementController, Vector3.left);
        }
        
        private void Start()
        {
            EventsManager.instance.OnGameOver += _ =>
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            };
            OnApplicationFocus(true);
            
            ChangeDeployeable(0);
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        
        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var cmdRotation = new CmdRotation(_movementController, Vector3.up * mouseX);
            EventQueueManager.instance.AddCommand(cmdRotation);
            
            if (Input.GetKey(moveForward))      EventQueueManager.instance.AddCommand(_cmdMoveForward);
            if (Input.GetKey(moveBack))         EventQueueManager.instance.AddCommand(_cmdMoveBackward);
            if (Input.GetKey(moveRight))        EventQueueManager.instance.AddCommand(_cmdMoveRight);
            if (Input.GetKey(moveLeft))         EventQueueManager.instance.AddCommand(_cmdMoveLeft);
            
            if (Input.GetKeyDown(setVictory))   EventsManager.instance.EventGameOver(true);
            if (Input.GetKeyDown(setDefeat))    EventsManager.instance.EventGameOver(false);

            if (Input.GetKeyDown(deploy)) DeployCurrentInstance();

            if(Input.GetKey(weaponSlot1)) ChangeDeployeable(0);
            if(Input.GetKey(weaponSlot2)) ChangeDeployeable(1);
            if(Input.GetKey(weaponSlot3)) ChangeDeployeable(2);
            if(Input.GetKey(weaponSlot4)) ChangeDeployeable(3);
        }

        private void DeployCurrentInstance()
        {
            if (!_collectorController.Expend(CollectableType.Egg, _currentDeployable.Cost)) return;

            var t = transform;
            var deployeable = Instantiate(_currentDeployable, t.position + t.TransformVector(Vector3.forward * 1.2f), t.rotation);
            deployeable.name = _currentDeployable.name;
            deployeable.transform.parent = _deployeablesTransform.transform;
            deployeable.gameObject.SetActive(true);
        }

        private void ChangeDeployeable(int index)
        {
            _currentDeployable = Deployeables[index];
            EventsManager.instance.DeployableChange(_currentDeployable);
        }
    }
}
