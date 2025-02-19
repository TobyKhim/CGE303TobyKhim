using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    //try setting this to 8 in the inspector 
   public float speed;

   //try setting this to 100 in inspector 
   public float turnspeed; 

   public float horizontalInput;
   public float verticalInput; 


   //Update is called once per frame 
   Void Update() 
   {
        //Move forward
        //transform.Translate(1, 0);

        //Which is the same as...
        //transform.Translate(Vector2.right);

        //Move forward 20meters/second if speed is set to 20
        //transform.Translate(Vector2.right * Time.deltaTime * speed);

        //Get Input - Do this in Update ( )
        horizontalInput = Input.GetAxis("horizontal");
        verticalInput = Input.GetAxis("vertical");

        //Move Player side-to-side with horizontal Input
        //transform.Translate(Vector2.right * turnspeed * Time.deltaTime* horizontalInput);

        //Move player forward with vertical Input
        transform.Translate(Vector2.right * Time.deltaTime *speed *verticalInput);

        //Rotate player with horizontal Input
        transform.Rotate(Vector3.forward, turnspeed * Time.deltaTime * horizontalInput);
   }
   
}