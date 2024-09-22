using UnityEngine;

public class TowerController : MonoBehaviour
{
    public int hitCount = 0;
    public int maxHits = 3;

    // Reference to the PlatformGenerator script
    public PlatformGenerator platformGenerator;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitCount++;
            Debug.Log("Tower hit! Current hit count: " + hitCount);

            // Destroy the bullet
            Destroy(collision.gameObject);

            // Check if the tower has been hit enough times
            if (hitCount >= maxHits)
            {
                Debug.Log("Tower destroyed!");

                // Destroy all tower objects
                GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
                foreach (GameObject tower in towers)
                {
                    Destroy(tower);
                }

                // Trigger platform generation script
                if (platformGenerator != null)
                {
                    platformGenerator.GeneratePlatforms();
                }
                else
                {
                    Debug.LogError("PlatformGenerator not assigned to TowerController.");
                }
            }
        }
    }
}
