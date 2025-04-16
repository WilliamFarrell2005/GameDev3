using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapRemover : MonoBehaviour
{
    public Tilemap tilemap;  // Reference to the Tilemap
    public Vector3Int removeAreaCenter; // Center of the area to remove (Grid Position)
    public int removeRadius = 2; // Radius of the area to remove
    public KeyCode interactionKey = KeyCode.E; // Key to trigger removal

    private bool isPlayerNearby = false;

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(interactionKey))
        {
            RemoveTilesInArea();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player is tagged correctly
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

    private void RemoveTilesInArea()
    {
        if (tilemap == null) return;

        // Loop through a square area around the center
        for (int x = -removeRadius; x <= removeRadius; x++)
        {
            for (int y = -removeRadius; y <= removeRadius; y++)
            {
                Vector3Int tilePosition = removeAreaCenter + new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, null); // Remove tile
            }
        }
    }
}
