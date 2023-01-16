using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider slider;

    public int maxShield = 100;
    public int currentShield = 0;
    public Slider shieldSlider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.value = currentHealth;
        shieldSlider.value = currentShield; 
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
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                getShield(10);
            }
        }
    }

    public void Heal(int healV)
    {
        currentHealth += healV;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        slider.value = currentHealth;
    }

    public void Damage(int damageV)
    {
        if(currentShield >= damageV)
        {
            currentShield -= damageV;
        }
        else
        {
            damageV -= currentShield;
            currentShield = 0;
            currentHealth -= damageV;
        }
        slider.value = currentHealth;
        shieldSlider.value = currentShield;
    }

    public void getShield(int shieldV)
    {
        currentShield += shieldV;
        if(currentShield > maxShield)
        {
            currentShield = maxShield;
        }
        shieldSlider.value = currentShield;
    }
}
