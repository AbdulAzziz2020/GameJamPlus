using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour{
    public HumanPlayer player;
    BoxCollider2D cd;
    // public LayerMask groundlayer;
    // Start is called before the first frame update
    void Start(){
        cd = GetComponent<BoxCollider2D>();
        player = transform.parent.GetComponent<HumanPlayer>();
    }

    // Update is called once per frame
    // void Update(){
        
    // }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Ground"){//} || col.gameObject.tag == "Enemy" || col.gameObject.tag == "MovingPlatform" ){
            Debug.Log("Grounded");
            player.isGrounded = true;
        }
        // if(col.gameObject.tag == "MovingPlatform"){
        //     player.transform.parent = col.gameObject.transform;   
        // }
    }
    
    void OnTriggerStay2D(Collider2D col){
        
        if(col.gameObject.tag == "Ground"){//} || col.gameObject.tag == "Enemy" || col.gameObject.tag == "MovingPlatform"){
            Debug.Log("Grounded");
            player.isGrounded = true;
        }
        // if(col.gameObject.tag == "MovingPlatform"){
        //     player.transform.parent = col.gameObject.transform;   
        // }
    }
    
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Ground"){
        // || col.gameObject.tag == "Enemy"
        //  || col.gameObject.tag == "MovingPlatform"){
            Debug.Log("Not Grounded");
            player.isGrounded = false;
        }
        // if(col.gameObject.tag == "MovingPlatform"){
        //     player.transform.parent = null;   
        // }
    }
}
