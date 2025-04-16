using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapDisabler : MonoBehaviour
{
    public Tilemap tilemap; // Assign the Tilemap in the Inspector
    public List<GameObject> interactableObjects; // Assign the 5 objects in the Inspector
    private HashSet<GameObject> interactedObjects = new HashSet<GameObject>();

    void Start()
    {
        if (tilemap == null)
        {
            Debug.LogError("Tilemap not assigned!");
        }
    }

    public void RegisterInteraction(GameObject obj)
    {
        if (interactableObjects.Contains(obj) && !interactedObjects.Contains(obj))
        {
            interactedObjects.Add(obj);
            Debug.Log("Interacted with: " + obj.name);
        }
        
        if (interactedObjects.Count >= interactableObjects.Count)
        {
            MakeTilemapDisappear();
        }
    }

    void MakeTilemapDisappear()
    {
        tilemap.gameObject.SetActive(false); // Disables the tilemap
        Debug.Log("Tilemap disappeared!");
    }
}


