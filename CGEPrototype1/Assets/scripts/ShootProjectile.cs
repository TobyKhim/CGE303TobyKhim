using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the player game object
//This script will allow thenplayers to shoot projectiles
public class ShootProjectile : MonoBehaviour
{
    //Reference to the projectile prefab
    public GameObject projectilePrefab;

    //Reference to the firepoint transform
    //This is where the projectile will be instantiated
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the player presses the fire button
        //call the shoot function
        if(Input.GetButtonDown("Fire1"))
        {
            //call the shoot function
            Shoot();
        }
    }

    void Shoot()
    {
        //instantiate the projectile at the firepoint
        //position and rotation
        //and store the reference to the Instantiated projectile in a variable 
        GameObject firedProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        //destroy the projectile after 1 seconds
        Destroy(firedProjectile,3f);
    }
}
