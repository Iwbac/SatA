using UnityEngine;

public class PlayerSuberu : MonoBehaviour
{
    public float speed = 20f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        inputDirection = transform.TransformDirection(inputDirection);
        moveDirection.x = inputDirection.x * speed;
        moveDirection.z = inputDirection.z * speed;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Ice")
        {
            moveDirection = Vector3.Lerp(moveDirection, hit.normal * speed, Time.deltaTime);
        }
    }
}