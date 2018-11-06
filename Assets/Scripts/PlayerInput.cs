using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerInput : MonoBehaviour {

    [SerializeField]
    private PlayerSight playerSight;
    private Movement movement;
    private WaterGun waterGun;

    private void Start()
    {
        movement = GetComponent<Movement>();
        waterGun = GetComponentInChildren<WaterGun>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            movement.Jump();
        }
        if(Input.GetButton("Fire1"))
        {
            waterGun?.StartShooting(playerSight.transform.position);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            waterGun?.StopShooting();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement.MoveWithHorizontal(horizontal);
    }
}
