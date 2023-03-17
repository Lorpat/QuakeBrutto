using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Slider slider;
    public Text healthText;
    
    public float maxShield = 100;
    public float currentShield = 0;
    public Slider shieldSlider;
    public Text shieldText;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.value = currentHealth;
        shieldSlider.value = currentShield;
        healthText.text = currentHealth.ToString();
        shieldText.text = currentShield.ToString();
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

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public float getHealth()
    {
        return currentHealth;
    }

    public void setHealth(float amount)
    {
        currentHealth = amount;
        healthText.text = currentHealth.ToString();
    }

    public void Heal(float healV)
    {
        currentHealth += healV;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = currentHealth.ToString();
        slider.value = currentHealth;
    }

    public void Damage(float damageV)
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
        healthText.text = currentHealth.ToString();
        shieldText.text = currentShield.ToString();
    }

    public void getShield(float shieldV)
    {
        currentShield += shieldV;
        if(currentShield > maxShield)
        {
            currentShield = maxShield;
        }
        shieldSlider.value = currentShield;
        shieldText.text = currentShield.ToString();
    }

    
}
