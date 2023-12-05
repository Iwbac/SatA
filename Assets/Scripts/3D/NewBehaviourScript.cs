using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb; 
    const float speed = 300f;
    const float dashSpeed = 600f;

 void Start() { 
     rb = GetComponent<Rigidbody>(); 
} 
 void FixedUpdate() { 
     if (Input.GetKey(KeyCode.W)) { 
     rb.velocity = Vector3.forward * speed * Time.fixedDeltaTime; 
      if (Input.GetKey(KeyCode.LeftShift)) { 
        rb.velocity = Vector3.forward * dashSpeed * Time.fixedDeltaTime; 
         } 
     } 

    
     if (Input.GetKey(KeyCode.S)) { 
     rb.velocity = Vector3.back * speed * Time.fixedDeltaTime;
      if (Input.GetKey(KeyCode.LeftShift)) { 
        rb.velocity = Vector3.back * dashSpeed * Time.fixedDeltaTime; 
         } 
     } 

   
     if (Input.GetKey(KeyCode.D)) { 
        rb.velocity = Vector3.right * speed * Time.fixedDeltaTime;
         if (Input.GetKey(KeyCode.LeftShift)) { 
        rb.velocity = Vector3.right * dashSpeed * Time.fixedDeltaTime; 
         } 
    } 
    
    if (Input.GetKey(KeyCode.A)) { 
        rb.velocity = Vector3.left * speed * Time.fixedDeltaTime;
         if (Input.GetKey(KeyCode.LeftShift)) { 
        rb.velocity = Vector3.left * dashSpeed * Time.fixedDeltaTime; 
         } 
    } 
 } 
}