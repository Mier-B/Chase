using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        // set the position of the camera to the player's position with an offset
        transform.position = player.position + offset;
         // check if the player's position falls below a certain value
    if (player.position.y < -10)
    {
        // end the game
        Debug.Log("Game Over");
        Application.Quit();
       
    }
    }
}
