using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractToRemoveTilemap : MonoBehaviour
{
    public Tilemap tilemapToRemove; // Assign in Inspector
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) // Change "E" to preferred key
        {
            RemoveTilemap();
        }
    }

    void RemoveTilemap()
    {
        if (tilemapToRemove != null)
        {
            Destroy(tilemapToRemove.gameObject);
            Debug.Log("Tilemap removed!");
        }
        else
        {
            Debug.LogWarning("Tilemap is not assigned!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}


