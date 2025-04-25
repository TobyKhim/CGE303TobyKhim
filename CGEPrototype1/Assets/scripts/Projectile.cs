using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectile class that controls the movement of the projectile
// Attach this sript to the projectile prefab
public class Projectile : MonoBehaviour
{
    //Rigidbody2D component of the projectile
    private Rigidbody2D rb;

    // Speed of the projectile with a default value of 20
    public float speed = 20f;

    //Damage of the projectile with the default value of 20
    public int damage = 20;

    // Impact effect of the projetile
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Get the rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        //Set the velocity of the projectile to fire
        //to the right at the speed
        rb.velocity = transform.right * speed;
    }

    //Function called when the projectile collides with another object
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Get the enemy component of the object that was hit
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        // If the object that was hit has an Enemy component
        if (enemy != null)
        {
            // Call the TakeDamage function of the Enemy script
            enemy.Takedamage(damage);
        }
        // If the object that was hit is not the player
        if (hitInfo.gameObject.tag != "Player")
        {
            // Instantiate the impact effect
            Instantiate(impactEffect, transform.position, Quaternion.identity);

            // Destroy the projectile
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
