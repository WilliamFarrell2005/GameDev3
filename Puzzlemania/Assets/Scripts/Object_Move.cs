using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PushableObject : MonoBehaviour
{
    public float pushStrength = 2f; // Adjust the push force
    public float friction = 0.9f; // Friction to scrub speed over time
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = 0; // Disable gravity for top-down movement
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            rb.linearVelocity = pushDirection * pushStrength;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity *= friction; // Apply friction to gradually stop movement
    }
}




