using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Reference : MonoBehaviour
{
    public int sceneBuildIndex;  
    public Vector2 spawnPosition; 

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            print("Switching Scene to " + sceneBuildIndex);
            Debug.Log("Switching to scene " + sceneBuildIndex);

            // Save the player's spawn position for the next scene
            PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
            PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("UseSavedSpawn", 1);


            // Load the new scene
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
