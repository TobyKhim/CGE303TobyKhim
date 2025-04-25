using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //enemy's health
    public int health = 100;

    //a prefab to spawn when the enemy dies
    public GameObject deathEffect;

    //A reference to the health bar
    private DisplayBar healthBar;

    private void Start()
    {
        // Find the health bar in the children of the Enemy
        healthBar = GetComponentInChildren<DisplayBar>();

        if (healthBar == null )
        {
            //if the healhbar is not found, log an error
            Debug.LogError("HealthBar (DisplayBar script) not found");
            return;
        }
        // Set the max value of the health bar to the enemy's health
        healthBar.SetMaxValue(health);
    }

    //a method to take damage
    public void Takedamage(int damage)
    {
        //subtract the damage dealt from the health
        health -= damage;

        // Update the health bar
        healthBar.SetValue(health);

        //if the health is less than or equal to 0
        if (health <= 0)
        {
            //Call the Die function
            Die();
        }
    }

    void Die()
    {
        //Spawn a death effect
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        //Destroy the enemy
        Destroy(gameObject);
    }


    
}
