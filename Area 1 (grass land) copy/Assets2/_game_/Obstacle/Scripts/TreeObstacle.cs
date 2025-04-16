using UnityEngine;

public class TreeObstacle : MonoBehaviour
{
    public GameObject axePickup; // Assign the AxePickup GameObject in Inspector
    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && axePickup.GetComponent<AxePickup>().PlayerHasAxe())
        {
            Destroy(gameObject); // Remove obstacle
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}

