using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10f; 
    public float jumpforce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;
    public Animator animator;
    public Vector3 startPosition;
    public float deathY ;
    public LayerMask ziel;
    public bool lose; 
    private float timeSinceLastMovement;
    private bool links;
    public AudioSource jumpSound;
    private float timeSinceLastSpeedIncrease;

    // Update is called once per frame
    void Start()
    {
        lose=false;
        animator = GetComponent<Animator>();
         timeSinceLastMovement = 0f;
         links=false;
         timeSinceLastSpeedIncrease = 0f;
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
      
  // Check if the character is touching the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        //move the character based on input
        transform.position = transform.position + new Vector3(moveX,0, 0) * speed * Time.deltaTime;
        
          
        //jump the character when spacebar is pressed
       if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {   

            jumpSound.Play(); 
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            // transform.position = transform.position + new Vector3(0,jumpforce, 0) * speed * Time.deltaTime;
           
        }
       
        if(moveX<0&&isGrounded){
            links=true;
        }
        else if(moveX>0){
            links=false;
        }
        

        
        //animatione steuern
        animator.SetBool("IsWalking",moveX!=0);
        animator.SetBool("OnAir",!isGrounded);
        animator.SetBool("L",links);
        

if (moveX != 0)
        {
            timeSinceLastMovement = 0f;
        }
        else
        {
            timeSinceLastMovement += Time.deltaTime;
        }

        // Check if player hasn't moved for more than 5 seconds
        if (timeSinceLastMovement >= 5f && !lose)
        {
            Debug.Log("Game Over: You were standing still for too long");
            lose=true;
            //Add your code here to handle the game over
        }
//respawnen
        if (transform.position.y <= deathY)
        {
           // transform.position = startPosition;
             lose=true;
             
        }



//speed increase
timeSinceLastSpeedIncrease += Time.deltaTime;
if (timeSinceLastSpeedIncrease >= 60f)
{
    speed += 0.5f;
    timeSinceLastSpeedIncrease = 0f;
}


       

         

    }
   
}
