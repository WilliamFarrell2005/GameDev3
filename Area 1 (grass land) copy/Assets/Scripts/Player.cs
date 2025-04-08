using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        string currentScene = SceneManager.GetActiveScene().name;
            Vector3 lastPos = SceneTransitionManager.Instance.GetLastPosition(currentScene);

            if (lastPos != Vector3.zero) // If a previous position exists, move the player there
            {
                transform.position = lastPos;
            }
    
    }

    // Update is called once per frame
    void Update()
    {

        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.linearVelocity = new Vector2(speedX, speedY);
    
    }
}
