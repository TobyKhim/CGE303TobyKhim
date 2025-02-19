using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
  
   private void OnTriggerEnter2D(Collider2D collision)    
{
    Debug.Log("Triggered by " + collision.gameObject.name);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
