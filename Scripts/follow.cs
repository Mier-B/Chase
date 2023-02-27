using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 1f;
    public float loseDistance = 1f;
    public float obstacleRange = 5f;
    public bool lose;
    private float timeSinceLastSpeedIncrease;
    private float timeSinceLastMovement;
    public Vector3 teleportLocation; // set this in the Inspector

    void Start(){
        lose=false;
        timeSinceLastSpeedIncrease = 0f;
        timeSinceLastMovement = 0f;
    }

    void Update()
    {
        Vector3 currentPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);

        Vector2 direction = player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, obstacleRange);
        if (hit.collider != null)
        {
            float angle = Random.Range(-110, 110);
            direction = Quaternion.Euler(0, 0, angle) * direction;
        }
        transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.position) <= loseDistance)
        {
            lose=true;
        }
        
        // check if the enemy's position is not changing for 10 seconds
        if (currentPos == transform.position)
        {
            timeSinceLastMovement += Time.deltaTime;
if (timeSinceLastMovement >= 10f)
{
// teleport the enemy to the set location
transform.position = teleportLocation;
timeSinceLastMovement = 0f;
}
}
else
{
timeSinceLastMovement = 0f;
}
    timeSinceLastSpeedIncrease += Time.deltaTime;
    if (timeSinceLastSpeedIncrease >= 30f)
    {
        followSpeed += 0.5f;
        timeSinceLastSpeedIncrease = 0f;
    }
}
}

