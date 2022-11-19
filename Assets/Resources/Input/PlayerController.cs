using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveInput;
    public Rigidbody2D rb;
    public float speed = 5f;
    
    private void FixedUpdate()
    {
        moveInput.y = 0;
        rb.velocity = moveInput * speed;
    }

    public void OnMoveInput(InputAction.CallbackContext callbackContext)
    {
        moveInput = callbackContext.ReadValue<Vector2>();
    }
}
