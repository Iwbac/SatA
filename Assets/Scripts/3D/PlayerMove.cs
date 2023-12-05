using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 10f;
    float dashSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * transform.forward * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift))
            {
             transform.position += dashSpeed * transform.forward * Time.deltaTime;   
            }
        }
 
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= speed * transform.forward * Time.deltaTime;
             if (Input.GetKey(KeyCode.LeftShift))
            {
             transform.position -= dashSpeed * transform.forward * Time.deltaTime;   
            }
        }
 
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * transform.right * Time.deltaTime;
             if (Input.GetKey(KeyCode.LeftShift))
            {
             transform.position += dashSpeed * transform.right * Time.deltaTime;   
            }
        }
 
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * transform.right * Time.deltaTime;
             if (Input.GetKey(KeyCode.LeftShift))
            {
             transform.position -= dashSpeed * transform.right * Time.deltaTime;   
            }
        }

    }
}
