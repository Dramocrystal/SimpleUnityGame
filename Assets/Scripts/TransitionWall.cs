using UnityEngine;

public class TransitionWall : MonoBehaviour
{
    // The GameObject representing the barrier that will be activated
    public GameObject barrier;

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has crossed the invisible wall.");

            barrier.SetActive(true);


        }
    }
}
