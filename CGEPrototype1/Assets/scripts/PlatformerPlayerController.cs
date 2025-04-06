using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    //Player movement speed
    public float movespeed = 5f;

    //Force applied when jumping
    public float jumpForce = 10f; 

    //Layer mask for detecting ground
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    //boot to keeo track of if we are on the ground
    public bool isGrounded;


    //Reference to the Rigidbody2D component
    private Rigidbody2D rb;

    private float horizontalInput;

    public AudioClip jumpSound;
    public AudioClip coinSound;

    private AudioSource playerAudio;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        
        //Set reference variables to components
        playerAudio = GetComponent<AudioSource>();

        // Set the reference for the Animator
        animator = GetComponent<Animator>();

        //ensure the groundCheck variable is assigned
        if (groundCheck == null)
        {
            Debug.LogError("groundCheck no assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input for horizontal movement 
        horizontalInput = Input.GetAxis("Horizontal");

        //Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Play jump sound effet
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void FixedUpdate()
    {
        //Move the player using Rigidbody2D in FixedUpdate
        rb.velocity = new Vector2 (horizontalInput * movespeed, rb.velocity.y);

        animator.SetFloat("xVelocityAbs", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        //Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        animator.SetBool("onGround", isGrounded);

        //Ensure the player is facing the direction of movement 
        if (horizontalInput > 0 )
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); //Facing left 
        }
    }

    public void PlayCoinSound()
    {
        //Play coin sound
        playerAudio.PlayOneShot(coinSound, 1.0f);
    }


}
