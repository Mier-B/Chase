using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feind : MonoBehaviour
{
    public float speed = 2.0f;
    public float attackRange = 1.0f;
    public float attackDuration = 1.0f;
    public int damage = 1;
    public int health = 1;
    private float attackTime = 0;
    //private Animator animator;
    private Transform player;

    private void Start()
    {
      //  animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        // Enemy Movement
        if (player != null)
        {
            //float distance = Vector2.Distance(transform.position, player.position);
              //float abstand = player.position.x - transform.position.x;
             
           /* if (abstand > attackRange)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position = transform.position + direction * speed * Time.deltaTime;
            }
            else
            {  
                 Debug.Log("ENEMY ATTACK");
                Attack();
               
            }*/
                   Vector3 direction = (player.position - transform.position).normalized;
                transform.position = transform.position + direction * speed * Time.deltaTime;
                Attack();


        }

        // Enemy Actions
        if (attackTime > 0)
        {
            attackTime -= Time.deltaTime;
            if (attackTime <= 0)
            {
        //        animator.SetBool("Attacking", false);
            }
        }
    }

    private void Attack()
    {
        Debug.Log("ENEMY");
        if (attackTime <= 0)
        {
          //  animator.SetBool("Attacking", true);
            attackTime = attackDuration;
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Player"));
            foreach (Collider2D player in hitPlayers)
            {
                player.GetComponent<PlayerMovement>().TakeDamage(damage);
                 Debug.Log("ENEMY ATTACK");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle enemy death
        Destroy(gameObject);
    }
    
}
