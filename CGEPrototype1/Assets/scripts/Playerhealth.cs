using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{

    //Variable to store the health of the player
    public int health = 100;

    //A reference to the health bear
    // This must be set in the inspector
    public DisplayBar healthBar;

    //reference to the RigidBody2D of the player
    private Rigidbody2D rb;

    //Knockback force when the player collides with an enemy
    public float knockbackforce = 5f;

    // A prefab to spawn when the player dies
    // This must be set in the inspector
    public GameObject playerDeathEffect;

    // bool to keep track if player has been hit recently
    public static bool hitRecently = false;

    // time in seconds to recover from a hit
    public float hitRecoveryTime = 0.2f;


    //references to play audio
    private AudioSource playerAudio;
    public AudioClip playerHitSound;
    public AudioClip playerDeathSound;


    // Start is called before the first frame update
    void Start()
    {

        //set the audiosource reference
        playerAudio = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();

        //check if the rb reference is null
        if (rb == null)
        {
            //Log an error message
            Debug.LogError("Rigidbody2D not found on player");
        }

        //set the healthBar max value to the player's health
        healthBar.SetMaxValue(health);

        //initialize hitRecently to false
        hitRecently = false;
    }

    // A function to knock the player back when they collide with the enemy
    public void knockBack(Vector3 enemyPosition)
    {
        // if the player has been hit recently ...
        if (hitRecently)
        {
            //return out of the function
            return;
        }

        // set hitRecently to true
        hitRecently = true;

        if (gameObject.activeSelf)
        {
            // Start the coroutine to reset hitRecently
            StartCoroutine(RecoverFromHit());
        }
        //Calculate the direction of the knockback
        Vector2 direction = transform.position - enemyPosition;

        //normalize the direction of the vector
        //this gives the consistent knockback force regardless of the distance
        //between the player and the enemy
        direction.Normalize();

        //add upward direction to the knockback
        direction.y = direction.y * 0.5f + 0.5f;

        //add force to the player in the direction of the knockback
        rb.AddForce(direction * knockbackforce, ForceMode2D.Impulse);       
    }

    //coroutine to reset hitRecently after hitRecoveryTime seconds
    IEnumerator RecoverFromHit()
    {
        //wait for hitRecoveryTime (0.2) seconds
        yield return new WaitForSeconds(hitRecoveryTime);

        //set hitRecovery to false
        hitRecently = false;
    }

    //a function to take damage
    public void TakeDamage(int damage)
    {
        //subtract the damage from the health
        health -= damage;

        //update the health bar
        healthBar.SetValue(health);

        //to do: play sround effect when the player takes damage
        //to do: play an animation when the player takes damage

        //if the health is less than or equal to 0
        if (health <=0)
        {
            //call the Die method
            Die();
        }
        else
        {
            //play the playerhitsound
            playerAudio.PlayOneShot(playerHitSound);
        }
    }

    //a function to die
    public void Die()
    {
        //set gameover to true
        ScoreManager.gameOver = true;
        gameObject.SetActive(false);

        //TO DO: play a sound effect when the player dies
        //TO DO: add the player death effects when the player dies
        playerAudio.PlayOneShot(playerDeathSound);

        //Instantiate the death effect at the player's position
        GameObject deathEffect = Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        //TO DO: complete this

        //destroy the death effect after 2 seconds
        Destroy(deathEffect, 2f);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
