using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarDemo : MonoBehaviour
{
    // The player max health
    public int maxHealth = 100;

    // Health deduction
    public int healthDeduction = 10;

    // The players current health
    private int currentHealth;

    // The health bar
    public HealthBar healthBar;


    void Start()
    {
        // Set the current health value
        currentHealth = maxHealth;

        // Set the health bar max value to the max health value
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // If the A key is pressed take away health
        if(Input.GetKey(KeyCode.A))
        {
            TakeHealth(healthDeduction);
        }

        // If the S key is pressed add health
        if (Input.GetKey(KeyCode.D))
        {
            AddHealth(healthDeduction);
        }
    }

    void AddHealth(int amount)
    {
        // Check the health value and add health
        if(currentHealth < maxHealth)
        {
            currentHealth += amount;
            healthBar.SetHealth(currentHealth);
        }
    }

    void TakeHealth(int amount)
    {  
        // Check the health value and take away health
        if (currentHealth > 0)
        {
            currentHealth -= amount;
            healthBar.SetHealth(currentHealth);
        }
    }
}
