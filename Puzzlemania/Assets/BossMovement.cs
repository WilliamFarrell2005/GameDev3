using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform Player; 
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 direction = (Player.position - transform.position).normalized;

        float horizontal = direction.x;
        float vertical = direction.y; 

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}

