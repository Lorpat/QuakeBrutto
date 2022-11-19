using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public CharacterController characterController;
    
    public float speed = 8f;
    public float gravity = (-9.81f)*2; // costante di gravitazione universale * 2

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    Vector3 velocity;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // per controllare se il player tocca terra

        if (isGrounded && velocity.y < 0f) // se l'oggetto è a terra, la velocità non deve continuare ad aumentare, quindi viene resettata
        {                                   // si setta a -2f perché è meglio di 0f
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        characterController.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // formula fisica per determinare la velocità necessaria a compiere un salto di una certa altezza
        }
        
        velocity.y += gravity * Time.deltaTime; // moto uniformemente accelerato
        
        characterController.Move(velocity * Time.deltaTime);
    }
}
