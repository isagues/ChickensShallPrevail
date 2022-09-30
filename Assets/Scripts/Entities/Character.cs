using System.Collections.Generic;
using Command;
using Manager;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update

    private MovementController _movementController;
    [SerializeField] private List<Turret> _turrets;
    private Turret _currentTurret;

    private int _coins = 0;
    
    [SerializeField] private KeyCode _moveFoward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    
    [SerializeField] private KeyCode _deploy = KeyCode.E;

    [SerializeField] private KeyCode _weaponSlot1 = KeyCode.Alpha1;
    
    
    [SerializeField] private KeyCode _setVictory = KeyCode.V;
    [SerializeField] private KeyCode _setDefeat = KeyCode.L;
    
    private CmdMovement _cmdMoveForward; 
    private CmdMovement _cmdMoveBackward;
    private CmdRotation _cmdRotateRight;
    private CmdRotation _cmdRotateLeft; 
    void Start()
    {
        _movementController = GetComponent<MovementController>();
        
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
        _coins += _coins + 1;
        
    }

    private void DeployTurret()
    {
        // Se crea en la posicion y direccion del character.
        var turret = Instantiate(_currentTurret, transform.position, transform.rotation);
        turret.name = "Turret";
        turret.gameObject.SetActive(true);
    }

    private void ChangeTurret(int index)
    {
        foreach (var gun in _turrets) gun.gameObject.SetActive(false);
        _currentTurret = _turrets[index];
    }
}
