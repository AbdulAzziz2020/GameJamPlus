using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HumanPlayer : BasePlayer{
    [Header("Jump Parameter")]
    public float jumpForces = 5f;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    public bool isGrounded;

    // // Start is called before the first frame update
    protected override void Start(){
        base.Start();
        // rb = GetComponent<Rigidbody2D>();
    }

    // // Update is called once per frame
    protected override void Update(){
        base.Update();
        // if(rb = null)Debug.LogError("Rigidbody2D is null");
    }
    void FixedUpdate(){
        OnJump();
    }
    protected override void Movement(){
        base.Movement();
        // moveInput = input.PlayerMap.Movement.ReadValue<Vector2>();
        if(Input.GetKeyDown(KeyCode.W)){
            rb.AddForce(Vector2.up * jumpForces, ForceMode2D.Impulse);
        }
        // if(facingLeft && moveInput.x > 0){
        //     facingLeft = true;
        //     changePickUpPos();
        // }else if(!facingLeft && moveInput.x < 0){
        //     facingLeft = false;
        //     changePickUpPos();

        // }
        moveInput.y = 0;
        transform.Translate(moveInput * speed * Time.deltaTime);
        // rb.velocity = moveInput * speed;
        
    }
    public void OnMoveInput(InputAction.CallbackContext callbackContext){
        moveInput = callbackContext.ReadValue<Vector2>();
    }
    protected void OnJump(){
        if(rb.velocity.y >= 0){
            rb.gravityScale = gravityScale;
        }else if (rb.velocity.y < 0){
            rb.gravityScale = fallingGravityScale;
        }
    }
}
