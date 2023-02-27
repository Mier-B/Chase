using UnityEngine;

public class Looping : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction = Vector3.right;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
