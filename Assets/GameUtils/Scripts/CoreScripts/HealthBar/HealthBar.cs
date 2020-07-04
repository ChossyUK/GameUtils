using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region Public Variables
    // The health bar slider
    public Slider healthBar;
    #endregion

    #region User Methods
    // Set the maximum health
    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Set the current health value
    public void SetHealth(int health)
    {
        healthBar.value = health;
    }
    #endregion
}
