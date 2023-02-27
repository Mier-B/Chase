using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontroller : MonoBehaviour
{

    public CharacterMovement player;
    public GameOver gameOver;
    public follow auto1;
    public follow auto2;
    public follow miniGegner;
     public follow miniGegner2;
    private float startTime;
    public float t;

    // Start is called before the first frame update
    void Start()
    {
         startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(player.lose||auto1.lose||miniGegner.lose||auto2.lose||miniGegner2.lose){

            gameOver.Setup(t);
        }
        else{
            t = Time.time - startTime;
        }
    }

}
