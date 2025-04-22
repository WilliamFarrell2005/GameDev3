using UnityEngine;

public class SwordLogic : MonoBehaviour
{
    public float damage;
    private PlayerHealth mainCharacter;
    private Animator animator;
    private int notMoving = Animator.StringToHash("notMoving");
    private AudioSource sound;
    private NavMesh2DMovement movementScript;
    private float rotation;
    private static int goesLeft = Animator.StringToHash("goesLeft");
    private static int goesRight = Animator.StringToHash("goesRight");
    private static int goesUp = Animator.StringToHash("goesUp");
    private static int goesDown = Animator.StringToHash("goesDown");
    
    private void Start()
    {
        movementScript = GetComponentInParent<NavMesh2DMovement>();
        animator = GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        sound.mute = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCharacter = other.gameObject.GetComponent<PlayerHealth>();
            mainCharacter.TakeDamage(damage);
        }
    }

    private void Update()
    {
        if (movementScript.isActiveAndEnabled)
        {
            rotation = movementScript.rotation;
            animator.SetBool(notMoving, false);
            sound.mute = false;
            switch (rotation)
            {
                case <= 45 and >= 0:
                case <= 360 and > 315:
                    animator.SetBool(goesLeft, true);
                    animator.SetBool(goesRight, false);
                    animator.SetBool(goesUp, false);
                    animator.SetBool(goesDown, false);
                    break;
                case > 45 and <= 135:
                    animator.SetBool(goesDown, true);
                    animator.SetBool(goesRight, false);
                    animator.SetBool(goesUp, false);
                    animator.SetBool(goesLeft, false);
                    break;
                case > 135 and <= 225:
                    animator.SetBool(goesRight, true);
                    animator.SetBool(goesUp, false);
                    animator.SetBool(goesDown, false);
                    animator.SetBool(goesLeft, false);
                    break;
                default:
                    animator.SetBool(goesUp, true);
                    animator.SetBool(goesRight, false);
                    animator.SetBool(goesDown, false);
                    animator.SetBool(goesLeft, false);
                    break;
            }
        }
        else
        {
            animator.SetBool(notMoving, true);
            sound.mute = true;
        }
    }
}    
