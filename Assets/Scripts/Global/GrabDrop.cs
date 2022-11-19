using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDrop : MonoBehaviour
{
    public Transform grapPoint;
    public Transform rayPoint;
    public bool hasRemove = false;

    public float rayDistance;

    public GameObject grabbedObject;
    public LayerMask layerMask;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, Vector2.right, rayDistance, layerMask);

        if (hit.collider != null)
        {
            Item itm = hit.collider.GetComponent<Item>();
            
            // grab
            if (Input.GetKeyDown(KeyCode.Space) && grabbedObject == null)
            {
                itm.hasDrop = false;
                grabbedObject = hit.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grapPoint.position;
                grabbedObject.transform.SetParent(grapPoint);
            }
            
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                itm.hasDrop = true;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }

        if (hasRemove)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DepositArea da = GameObject.FindObjectOfType<DepositArea>();
                da.Removeable(10, null);
            } 
            
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                DepositArea da = GameObject.FindObjectOfType<DepositArea>();
                da.Removeable(20, null);
            }
            
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                DepositArea da = GameObject.FindObjectOfType<DepositArea>();
                da.Removeable(30, null);
            }
        }
        
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Counter"))
        {
            hasRemove = !hasRemove;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Counter"))
        {
            hasRemove = !hasRemove;
        }
    }
}
