using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfAfterDelay : MonoBehaviour
{
    //the delay before the game object is destroyed
    public float delay = 2f;


    // Start is called before the first frame update
    void Start()
    {
        //Destroy the game object adter the delay number of seconds
        Destroy(gameObject, delay);
    }

   
}
