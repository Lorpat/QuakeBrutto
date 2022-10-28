using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telecamera : MonoBehaviour
{
    /*CHAT

    Pat:comunque

    Lorenzi: 

    Albi: sono gay e succhio cazzi nei bagni dei gigli!!!8===========D---

    */

    public Transform playerBody;//questo è il "corpo" del personaggio, serve per la roba di fisica
    float xRotation = 0f;
    public float sensitivity = 10f;//sensibilità

    void FixedUpdate()//aggiorna a ogni frame
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp (xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // quaternions bitch
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
