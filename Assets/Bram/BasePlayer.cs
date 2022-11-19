using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePlayer : MonoBehaviour{
    [Header("Movement Param")]
    public float speed = 5;
    public bool facingLeft;
    // public PlayerInput input;
    [SerializeField]protected Rigidbody2D rb;
    protected Vector2 moveInput;
    [Header("Pickup")]
    public Transform pickupPos;
    public LayerMask pickUpLayer;
    public Transform target;
    public bool isEmpty = false;
    // Start is called before the first frame update
    protected virtual void Start(){
        // input = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)Debug.LogError("Rigidbody2D is null");
    }

    // Update is called once per frame
    protected virtual void Update(){
        Movement();
        Debug.Log(moveInput);
        
    }
    protected virtual void FixedUpdate(){
    }
    protected virtual void Movement(){}
    protected virtual void Action(){}
    protected virtual void PickUp(){
        if(!isEmpty)return;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f, pickUpLayer);
        float minDistance = Mathf.Infinity;
        foreach (Collider col in hitColliders){
            float distance = Vector3.Distance(transform.position, col.transform.position);
            if(distance < minDistance){
                minDistance = distance;
                target = col.transform;
            }
        }
        Debug.Log(target);
        if(target != null){
            target.parent = pickupPos;
            target.transform.localPosition = new Vector3(0,0,0);
        Debug.Log("Pick something");
        }
    }
    // protected virtual void OnEnable(){
    //     input.Player_Map.Enable();
    // }
    // protected virtual void OnDisable(){
    //     input.Player_Map.Disable();
    // }
    protected virtual void changePickUpPos(){
        Vector3 newPos = pickupPos.localPosition;
        newPos.x *=-1;
        pickupPos.localPosition = newPos;
    }
}
