using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class JinPlayer : BasePlayer{
    // Start is called before the first frame update
    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;
    public KeyCode act;
    protected override void Start(){
        base.Start();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    protected override void Update(){
        base.Update();
        if(Input.GetKeyDown(act)){
            PickUp();
        }
        
    }

    // public void OnMoveInput(InputAction.CallbackContext callbackContext){
    //     moveInput = callbackContext.ReadValue<Vector2>();
    // }

    protected override void Movement(){
        base.Movement();
        Vector2 movementInput = new Vector2();
        // moveInput = input.PlayerMap.Movement.ReadValue<Vector2>();
        if(Input.GetKey(up) && Input.GetKey(down)){
            // movementInput = movementInput + Vector2.up;
        }else if(Input.GetKey(up)){
            movementInput = movementInput + Vector2.up;
        }else if(Input.GetKey(down)){
            movementInput = movementInput + Vector2.down;
        }
        if(Input.GetKey(right) && Input.GetKey(left)){
            // movementInput = movementInput + Vector2.up;
        }else if(Input.GetKey(right)){
            if(!facingLeft){
                facingLeft = !facingLeft;
                changePickUpPos();
            }
            movementInput = movementInput + Vector2.right;
        }else if(Input.GetKey(left)){
            if(facingLeft){
                facingLeft = !facingLeft;
                changePickUpPos();
            }
            movementInput = movementInput + Vector2.left;
        }
        // moveInput.y = 0;
        transform.Translate(movementInput * speed * Time.deltaTime);
        // rb.velocity = moveInput * speed;
    }
    
}
