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

    // the damage the enemy deals to the player
    public int damage = 10;

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

    //damage the player when the enemy collides with them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //get the player health script from the player object
            Playerhealth playerhealth = collision.gameObject.GetComponent<Playerhealth>();

            //check the player health script is null
            if (playerhealth == null)
            {
                //log an error if the player health script is null
                Debug.LogError("PlayerHealth script not found on player");
                return;
            }

            // damage the player
            playerhealth.TakeDamage(damage);

            //knockback the player
            playerhealth.knockBack(transform.position);
        }
    }

}
