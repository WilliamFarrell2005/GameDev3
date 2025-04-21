using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public string targetScene;
    public bool isVerticalTransition = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneTransitionManager.Instance.SetLastPosition(transform, currentScene, isVerticalTransition);

            SceneManager.LoadScene(targetScene);
        }
    }
}
