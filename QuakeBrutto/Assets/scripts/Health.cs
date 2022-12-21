using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Heal(10);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Damage(10);
            }
        }
    }

    void Heal(int healV)
    {
        currentHealth += healV;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        slider.value = currentHealth;
    }

    void Damage(int damageV)
    {
        currentHealth -= damageV;
        slider.value = currentHealth;
    }
}
