using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseonFall : MonoBehaviour
{
  //Set this in the inspector 
  public float lowestY;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < lowestY)
        {
            ScoreManager.gameOver = true;
        }
    }
}
