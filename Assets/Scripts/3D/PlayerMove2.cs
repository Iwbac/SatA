using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb; 
    const float speed = 300f;
    const float dashSpeed = 600f;
    private bool isPressedSpace = false;
 void Start() { 
     rb = GetComponent<Rigidbody>(); 
} 
void Update(){
   if(Input.GetKeyDown(KeyCode.Space)){
       isPressedSpace = true;
    }
}

 void FixedUpdate() { 
     if (Input.GetKey(KeyCode.W)) { 
     rb.velocity = Vector3.forward * speed * Time.fixedDeltaTime; 
      if (Input.GetKey(KeyCode.LeftShift)) { 
        rb.velocity = Vector3.forward * dashSpeed * Time.fixedDeltaTime; 
         } 
     } 

    
     else if (Input.GetKey(KeyCode.S)) { 
     rb.velocity = Vector3.back * speed * Time.fixedDeltaTime;
      if (Input.GetKey(KeyCode.LeftShift)) { 
        rb.velocity = Vector3.back * dashSpeed * Time.fixedDeltaTime; 
         } 
     } 

   
     else if (Input.GetKey(KeyCode.D)) { 
        rb.velocity = Vector3.right * speed * Time.fixedDeltaTime;
         if (Input.GetKey(KeyCode.LeftShift)) { 
        rb.velocity = Vector3.right * dashSpeed * Time.fixedDeltaTime; 
         } 
    } 
    
    else if (Input.GetKey(KeyCode.A)) { 
        rb.velocity = Vector3.left * speed * Time.fixedDeltaTime;
         if (Input.GetKey(KeyCode.LeftShift)) { 
        rb.velocity = Vector3.left * dashSpeed * Time.fixedDeltaTime; 
         } 
    } 
    if(isPressedSpace){
       rb.AddForce(transform.up * 5f, ForceMode.Impulse);
       isPressedSpace = false;
    }
 } 
}