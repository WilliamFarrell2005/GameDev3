using UnityEngine;
using UnityEngine.AI;

public class GoblinLogic : MonoBehaviour
{
    private SwordLogic swordScript;
    private NavMesh2DMovement movementScript;
    private NavMeshAgent agent;
    private Animator animator;
    private int notMoving = Animator.StringToHash("notMoving");
    private AudioSource sound;
    
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        movementScript = GetComponent<NavMesh2DMovement>();
        agent = GetComponent<NavMeshAgent>();
        swordScript = GetComponentInChildren<SwordLogic>();
        swordScript.enabled = false;
        animator = GetComponent<Animator>();
        sound.mute = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agent.enabled = true;
            movementScript.enabled = true;
            swordScript.enabled = true;
            animator.SetBool(notMoving, false);
            sound.mute = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        agent.enabled = false;
        movementScript.enabled = false;
        swordScript.enabled = false;
        animator.SetBool(notMoving, true);
        sound.mute = true;
    }
}
