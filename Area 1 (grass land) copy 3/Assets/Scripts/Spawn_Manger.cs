using UnityEngine;
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

    /// <summary>
    /// Stores the last position for a given scene.
    /// You can optionally add a small vertical/horizontal offset.
    /// </summary>
    public void SetLastPosition(Transform triggerTransform, string sceneName, bool isVertical = false)
    {
        Vector3 offset = isVertical ? Vector3.down * 0.05f : Vector3.right * 0.01f;
        lastPositions[sceneName] = triggerTransform.position + offset;
        lastScene = sceneName;
    }

    /// <summary>
    /// Returns the last stored position for a given scene.
    /// </summary>
    public Vector3 GetLastPosition(string currentScene)
    {
        if (lastPositions.ContainsKey(currentScene))
        {
            return lastPositions[currentScene];
        }

        return Vector3.zero;
    }

    public string GetLastScene()
    {
        return lastScene;
    }
}
