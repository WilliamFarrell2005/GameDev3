using UnityEngine;

public class AxePickup : MonoBehaviour
{
    public GameObject[] environmentPiecesToRemove; // Assign in Inspector
    private bool isPlayerNearby = false;
    private bool hasAxe = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            PickUpAxe();
        }
    }

    private void PickUpAxe()
    {
        hasAxe = true;
        gameObject.SetActive(false); // Hide the axe after pickup
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

    public bool PlayerHasAxe()
    {
        return hasAxe;
    }
}
