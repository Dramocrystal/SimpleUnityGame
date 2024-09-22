using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3;
    public float heightMax = 3;
    private Vector3 velocity; // Store the bullet's velocity

    // Set the velocity from the GunController
    public void SetVelocity(Vector3 initialVelocity)
    {
        velocity = initialVelocity;
    }

    void Awake()
    {
        Destroy(gameObject, life); // Destroy the bullet after its life span
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;

        // Update position using kinematics equation d = d + v * deltaTime 
        transform.position += velocity * deltaTime;

        // If bullet goes above the height limit, destroy it
        if (transform.position.y > heightMax)
        {
            Debug.Log("Max Height reached, destroying bullet");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name);
        Destroy(gameObject); // Destroy bullet upon collision
    }
}
