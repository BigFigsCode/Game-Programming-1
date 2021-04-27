using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPSController : MonoBehaviour
{
    public float speed;
    public float gravity = -9.81f;
    public float groundDistance = .4f;
    public float jumpforce = 15f;

    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public CharacterController playerCC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * xDir + transform.forward * zDir;
        playerCC.Move(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpforce * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        playerCC.Move(velocity * Time.deltaTime);

        
    }
}
