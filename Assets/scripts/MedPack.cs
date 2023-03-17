using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPack : MonoBehaviour
{
    public int HealthGain = 25;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<Health>().currentHealth < other.gameObject.GetComponent<Health>().maxHealth)
            {
                other.GetComponent<Health>().Heal(HealthGain);
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
