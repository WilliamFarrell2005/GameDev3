using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    private Dictionary<string, Vector3> lastPositions = new Dictionary<string, Vector3>();
    private string lastScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLastPosition(Transform triggerTransform, string sceneName)
    {
        Vector3 spawnPosition = triggerTransform.position + Vector3.down * 1.0f; // Spawns slightly below the trigger
        lastPositions[sceneName] = spawnPosition;
        lastScene = sceneName;
    }

    public Vector3 GetLastPosition(string currentScene)
    {
        if (lastPositions.ContainsKey(currentScene))
        {
            return lastPositions[currentScene];
        }
        return Vector3.zero; // Default position if no previous location is recorded
    }
}
