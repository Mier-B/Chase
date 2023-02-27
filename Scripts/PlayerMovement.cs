using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float attackRange = 1.0f;
    public float attackDuration = 1.0f;
    public float blockDuration = 1.0f;
    public int maxHealth = 1;
    private int health;
    private float attackTime = 0;
    private float blockTime = 0;
    public int damage = 1;
    private Animator animator;
    private bool facingRight = true;

    private void Start()
    {
        health = maxHealth;
       animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Player Movement
        float horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
        Flip(horizontal);

        // Player Actions
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
            Debug.Log("Attack");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Block();
            Debug.Log("Block");
        }
        if (attackTime > 0)
        {
            attackTime -= Time.deltaTime;
            if (attackTime <= 0)
            {
           animator.SetBool("Attacking", false);
            }
        }
        if (blockTime > 0)
        {
            blockTime -= Time.deltaTime;
            if (blockTime <= 0)
            {
             animator.SetBool("Blocking", false);
            }
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void Attack()
    {
        blockTime=0;
        if (attackTime <= 0)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Enemy"));
            foreach (Collider2D enemy in hitEnemies)
            {
               enemy.GetComponent<Feind>().TakeDamage(damage);
            }
           animator.SetBool("Attacking", true);
            attackTime = attackDuration;
        }
    }

    private void Block()
    {
        if (blockTime <= 0)
        {
            animator.SetBool("Blocking", true);
            blockTime = blockDuration;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyAttack") && blockTime <= 0)
        {
        
            
        }
    }

  public void TakeDamage(int damage)
    {
        if(blockTime<=0){
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    }
    private void Die()
    {
        // Handle player death
          Debug.Log("Dead");
           Destroy(gameObject);
    }
}
