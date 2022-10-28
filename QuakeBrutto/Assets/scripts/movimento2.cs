using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class movimento2 : MonoBehaviour
{
    
    public Rigidbody rb;
    public float speed = 5f;
    public float sensitivity = 10f;
    public float distance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        //Store user input as a movement vector
        //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        //rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed);
        

        if (Input.GetKey(KeyCode.S)) transform.position = transform.position - Camera.main.transform.forward * distance * Time.deltaTime; // indietro
        if (Input.GetKey(KeyCode.W)) transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime; // avanti
        if (Input.GetKey(KeyCode.D)) transform.position = transform.position + Camera.main.transform.right * distance * Time.deltaTime; // destra
        if (Input.GetKey(KeyCode.A)) transform.position = transform.position - Camera.main.transform.right * distance * Time.deltaTime; // sinistra

        float rotateHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotateHorizontal * sensitivity, 0);
    }


}
