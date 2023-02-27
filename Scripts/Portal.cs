using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;
    public GameObject destinationPortal;
    private bool canTeleport = true;
    public float cooldown = 20f;
    private float timer;
    public AudioSource sound;
    public GameObject portal;

    void Start()
    {
        timer = cooldown;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            sound.Play();
            other.transform.position = destination.position;
            destinationPortal.SetActive(false);
            portal.GetComponent<SpriteRenderer>().enabled = false;
            canTeleport = false;

        }
    }

    private void Update()
    {
        if (!canTeleport)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                destinationPortal.SetActive(true);
                portal.GetComponent<SpriteRenderer>().enabled = true;
                canTeleport = true;
                timer = cooldown;
            }
        }
    }
}
