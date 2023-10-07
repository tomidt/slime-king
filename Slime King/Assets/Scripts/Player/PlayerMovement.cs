using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementValue;
    private Vector2 prevMovementValue;

    private float currentSpeed = 0f;
    private float acc = 0.75f;          //acceleration scalar
    private float dcc = 0.75f;          //deceleration scalar

    [SerializeField] private InputActionReference movement;
    [SerializeField] private FloatValue speed;

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
        if (val.magnitude > 0 && currentSpeed >= 0)
        {
            prevMovementValue = val;
            currentSpeed += (speed.value * acc) * speed.value * Time.fixedDeltaTime;
        }
        else
        {
            currentSpeed -= (speed.value * dcc) * speed.value * Time.fixedDeltaTime;
        }
        //Debug.Log("speed : " + currentSpeed);
        currentSpeed = Mathf.Clamp(currentSpeed, 0, speed.value);
        //Debug.Log("speed : " + currentSpeed);
        rb.velocity = prevMovementValue * currentSpeed;
    }
}
