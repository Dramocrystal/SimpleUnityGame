using UnityEngine;
using TMPro; 

public class PlayerCollision : MonoBehaviour
{
    public Transform respawnPoint;
    public TextMeshProUGUI gameWonText; 
    public MonoBehaviour playerControllerScript;
    public TextMeshProUGUI playerLoseText;

    private void Start()
    {
        // Ensure the game won text is hidden at the start
        if (gameWonText != null)
        {
            gameWonText.gameObject.SetActive(false);
        }

        if (playerLoseText != null)
        {
            playerLoseText.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Log when a collision occurs
        Debug.Log("Player Collided with: " + collision.gameObject.name);


        if (collision.gameObject.CompareTag("Water"))
        {
            Debug.Log("Touched water! Respawning...");
            //Respawn();

            //I had a respawn function but the platform disapeared LOL so I had to restart the game anyways
            if (playerLoseText != null)
            {
                playerLoseText.gameObject.SetActive(true);
                playerControllerScript.enabled = false;
            }
        }


        if (collision.gameObject.CompareTag("goal-area"))
        {
            Debug.Log("Destroying remaing platforms");
            DestroyRemainingPlatforms();
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            Debug.Log("Won the game!");
            if (gameWonText != null)
            {
                gameWonText.gameObject.SetActive(true);
                playerControllerScript.enabled = false;
            }
            else
            {
                Debug.LogWarning("GameWonText is not assigned!");
            }
        }
    }



    private void DestroyRemainingPlatforms()
    {
        // Find all remaining platforms with the tag "Platform"
        GameObject[] remainingPlatforms = GameObject.FindGameObjectsWithTag("Platform");

        // Loop through and destroy each platform
        foreach (GameObject platform in remainingPlatforms)
        {
            Destroy(platform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Player exited platform: " + collision.gameObject.name);
            Destroy(collision.gameObject); // Destroy the platform
        }
    }

    private void Respawn()
    {
        // Move the player to the respawn point
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
    }
}
