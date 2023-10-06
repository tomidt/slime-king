using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementValue;
    private Vector2 prevMovementValue;
    [SerializeField] private InputActionReference movement;

    //TODO - change to so
    private float maxSpeed = 4;
    private float acceleration = 50;
    private float deacceleration = 100;

    private float currentSpeed = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementValue = movement.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        move(movementValue);
    }

    private void move(Vector2 val)
    {
        Debug.Log("speed : " + movementValue);
        if (val.magnitude > 0 && currentSpeed >= 0)
        {
            prevMovementValue = val;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * maxSpeed * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb.velocity = prevMovementValue * currentSpeed;
    }
}
