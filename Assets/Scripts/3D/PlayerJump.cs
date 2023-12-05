using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerJump : MonoBehaviour
{
    public float jumpPower;
    private Rigidbody rb;
    private bool isJumping = false;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
        }
    }
 
    // ★★追加
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Plane"))
        {
            isJumping = false;
        }
    }
}
