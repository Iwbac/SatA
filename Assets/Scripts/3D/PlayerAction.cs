using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{

    CharacterController controller;
    Vector3 movedir = Vector3.zero;
    private Animator animator;
    public Collider attackCollider;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        attackCollider.enabled = false;
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
        Quaternion rot = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0);
        Vector3 globaldir = rot * movedir;
        controller.Move(globaldir* Time.deltaTime);

        if (controller.isGrounded)
        {
            movedir.y = -5f;
        }
        
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * InputDir.x + Camera.main.transform.right * InputDir.y;

        if (moveForward != Vector3.zero) {
        transform.rotation = Quaternion.LookRotation(moveForward);
        }

        animator.SetFloat("Walk", controller.velocity.magnitude);

         if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

     //武器の判定を有効or無効切り替える
    public void OffColliderAttack()
    {
        attackCollider.enabled = false;
    }
    public void OnColliderAttack()
    {
        attackCollider.enabled = true;
    }

}
