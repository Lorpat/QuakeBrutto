using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemenet : MonoBehaviour
{

    public CharacterController characterController;
    public float speed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
