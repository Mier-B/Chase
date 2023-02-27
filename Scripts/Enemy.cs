using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed ;
    public float leftBoundary ;
    public float rightBoundary ;
    private bool movingRight = true;
   

    // Update is called once per frame
    void Update()
    {
        
{
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (transform.position.x >= rightBoundary)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftBoundary)
        {
            movingRight = true;
        }
        
    }
    
  


}
}
