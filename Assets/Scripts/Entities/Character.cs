using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update

    private MovementController _movementController;
    [SerializeField] private List<Turret> _turrets;
    private Turret _currentTurret;
    
    [SerializeField] private KeyCode _moveFoward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    
    [SerializeField] private KeyCode _deploy = KeyCode.E;

    [SerializeField] private KeyCode _weaponSlot1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode _weaponSlot2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode _weaponSlot3 = KeyCode.Alpha3;
    
    [SerializeField] private float _timer = 3;
    void Start()
    {
        _movementController = GetComponent<MovementController>();
        ChangeTurret(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_moveFoward)) _movementController.Travel(Vector3.forward);
        if (Input.GetKey(_moveBack)) _movementController.Travel(-Vector3.forward);
        if (Input.GetKey(_moveRight)) _movementController.Rotate(Vector3.up);
        if (Input.GetKey(_moveLeft)) _movementController.Rotate(-Vector3.up);

        if (Input.GetKeyDown(_deploy)) DeployTurret();

        if(Input.GetKey(_weaponSlot1)) ChangeTurret(0);
        // if(Input.GetKey(_weaponSlot2)) ChangeTurret(1);
        // if(Input.GetKey(_weaponSlot3)) ChangeTurret(2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogWarning(collision);
    }

    private void DeployTurret()
    {
        // Se crea en la posicion y direccion del character.
        var turret = Instantiate(_currentTurret, transform.position, transform.rotation);
        turret.name = "Bala Turret";
        turret.gameObject.SetActive(true);
    }

    private void ChangeTurret(int index)
    {
        foreach (var gun in _turrets) gun.gameObject.SetActive(false);
        _currentTurret = _turrets[index];
    }
}
