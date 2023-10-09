using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementValue;
    private Vector2 prevMovementValue;
    private Vector2 mouseDir;

    private float currentSpeed = 0f;
    private float acc = 0.75f;          //acceleration scalar
    private float dcc = 0.75f;          //deceleration scalar

    //[SerializeField] private InputActionReference mouse;
    [SerializeField] private InputActionReference movement;
    [SerializeField] private FloatValue speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementValue = movement.action.ReadValue<Vector2>();
        mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mouseDir = Camera.main.ScreenToWorldPoint(movement.action.ReadValue<Vector2>());
    }

    private void FixedUpdate()
    {
        move();
        faceMouse();
    }

    private void move()
    {
        if (movementValue.magnitude > 0 && currentSpeed >= 0)
        {
            prevMovementValue = movementValue;
            currentSpeed += (speed.value * acc) * speed.value * Time.fixedDeltaTime;
        }
        else
        {
            currentSpeed -= (speed.value * dcc) * speed.value * Time.fixedDeltaTime;
        }
        
        currentSpeed = Mathf.Clamp(currentSpeed, 0, speed.value);
        rb.velocity = prevMovementValue * currentSpeed;
    }

    private void faceMouse()
    {
        Vector2 dir = mouseDir - rb.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }
}
