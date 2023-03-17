using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPack : MonoBehaviour
{
    public int ShieldhGain = 25;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Health>().currentShield < other.gameObject.GetComponent<Health>().maxShield)
            {
                other.GetComponent<Health>().getShield(ShieldhGain);
                transform.position = new Vector3(transform.position.x, transform.position.y - 30, transform.position.z);
                Invoke("GetBackUp", 10f);
            }
        }
    }

    public void GetBackUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 30, transform.position.z);
    }
}
