using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnManager : MonoBehaviour
{
    private void Start()
    {
        // Only move player if "UseSavedSpawn" is set
        if (PlayerPrefs.GetInt("UseSavedSpawn", 0) == 1)
        {
            if (PlayerPrefs.HasKey("SpawnX") && PlayerPrefs.HasKey("SpawnY"))
            {
                float x = PlayerPrefs.GetFloat("SpawnX");
                float y = PlayerPrefs.GetFloat("SpawnY");

                transform.position = new Vector2(x, y);
                Debug.Log("Spawning player at saved position: " + transform.position);
            }

            // Reset the flag
            PlayerPrefs.SetInt("UseSavedSpawn", 0);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Using default scene position, not saved spawn.");
        }
    }
}

