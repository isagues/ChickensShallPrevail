using System.Collections.Generic;
using Command;
using Controller;
using Entities;
using Entities.Turrets;
using Manager;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update

    private MovementController _movementController;
    private CollectorController _collectorController;
    
    [SerializeField] private List<Turret> _turrets;
    private Turret _currentTurret;
    
    [SerializeField] private KeyCode _moveFoward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    
    [SerializeField] private KeyCode _deploy = KeyCode.E;

    [SerializeField] private KeyCode _weaponSlot1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode _weaponSlot2 = KeyCode.Alpha2;
    
    
    [SerializeField] private KeyCode _setVictory = KeyCode.V;
    [SerializeField] private KeyCode _setDefeat = KeyCode.L;

    private CmdMovement _cmdMoveForward; 
    private CmdMovement _cmdMoveBackward;
    private CmdRotation _cmdRotateRight;
    private CmdRotation _cmdRotateLeft;
    void Start()
    {
        _movementController = GetComponent<MovementController>();
        _collectorController = GetComponent<CollectorController>();
        
        _cmdMoveForward = new CmdMovement(_movementController, Vector3.forward);
        _cmdMoveBackward = new CmdMovement(_movementController, -Vector3.forward);
        _cmdRotateRight = new CmdRotation(_movementController, Vector3.up);
        _cmdRotateLeft = new CmdRotation(_movementController, -Vector3.up);

        ChangeTurret(0);
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

        if (Input.GetKeyDown(_deploy)) DeployTurret();

        if(Input.GetKey(_weaponSlot1)) ChangeTurret(0);
        if(Input.GetKey(_weaponSlot2)) ChangeTurret(1);
    }

    private void DeployTurret()
    {
        if (!_collectorController.Expend(CollectableType.Egg, _currentTurret.Cost)) return;
        
        // Se crea en la posicion y direccion del character.
        var turret = Instantiate(_currentTurret, transform.position, transform.rotation);
        turret.name = _currentTurret.name;
        turret.transform.parent = GameObject.Find("Turrets").transform;
        turret.gameObject.SetActive(true);

    }

    private void ChangeTurret(int index)
    {
        _currentTurret = _turrets[index];
        EventsManager.instance.TurretChange(_currentTurret);
        
    }
}
