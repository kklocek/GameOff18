using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerInput : MonoBehaviour {

    private Movement movement;
    private WaterGun waterGun;
    //TODO
    private FireGun fireGun;

    private void Start()
    {
        movement = GetComponent<Movement>();
        waterGun = GetComponentInChildren<WaterGun>();
        fireGun = GetComponentInChildren<FireGun>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            movement.Jump();
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            waterGun?.StartShooting();
            fireGun?.StartShooting();
        }
        if(Input.GetKeyUp(KeyCode.V))
        {
            waterGun?.StopShooting();
            fireGun?.StopShooting();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement.MoveWithHorizontal(horizontal);
    }




}
