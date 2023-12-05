using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveNeo : MonoBehaviour
{
    CharacterController controller;
    Vector3 movedir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
         float speed = 10f;
         Vector2 InputDir= new Vector2 (Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));

        if (controller.isGrounded)
        {
            
             movedir.z = InputDir.x * speed;
             movedir.x = InputDir.y * speed;
                      
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movedir.y = 7f;
            }
        }

        movedir.y -= 20f * Time.deltaTime;

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(movedir * Time.deltaTime);

        if (controller.isGrounded)
        {
            movedir.y = -5f;
        }

        if ((InputDir.x!=0)||(InputDir.y!=0))
        {
            float rad = Mathf.Atan2(-InputDir.x, InputDir.y);
            float degree = rad * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,degree+90,0);
        }

    }
}

