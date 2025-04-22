using UnityEngine;
using System.Collections.Generic;

public class Respawn_Manager : MonoBehaviour
{
    public static Respawn_Manager Instance;
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

    public void SetLastPosition(Transform triggerTransform, string sceneName, bool isVertical)
    {
        Vector3 offset = isVertical ? Vector3.down * 0.05f : Vector3.right * 0.05f;
        lastPositions[sceneName] = triggerTransform.position + offset;
        lastScene = sceneName;
    }

    public Vector3 GetLastPosition(string currentScene)
    {
        if (lastPositions.ContainsKey(currentScene))
        {
            return lastPositions[currentScene];
        }
        return Vector3.zero;
    }
} 
