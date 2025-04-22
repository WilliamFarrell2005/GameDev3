using UnityEngine;
using System.Collections;
using NavMeshPlus.Extensions;
using UnityEngine.AI;

public class WitchLogic : MonoBehaviour
{
    public GameObject circlePrefab;   
    public float shootForce = 10f;
    private GameObject shootPoint;
    public float shootInterval = 10f;
    private NavMeshExtension rotation;
    private NavMesh2DMovement movementScript;
    private NavMeshAgent agent;
    private Animator animator;
    private int notMoving = Animator.StringToHash("notMoving");
    private bool canAttack;
    private AudioSource sound;
    void Start()
    {
        StartCoroutine(ShootOrbsAutomatically(shootInterval));
        movementScript = GetComponent<NavMesh2DMovement>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        sound.mute = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agent.enabled = true;
            movementScript.enabled = true;
            animator.SetBool(notMoving, false);
            canAttack = true;
            sound.mute = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        agent.enabled = false;
        movementScript.enabled = false;
        animator.SetBool(notMoving, true);
        canAttack = false;
        sound.mute = false;
    }
    IEnumerator ShootOrbsAutomatically(float delayTime)
    {
        while (true)
        {
            if (canAttack)
            {
                shootPoint = gameObject.transform.GetChild(0).GetChild(0).gameObject;
                GameObject orbCopy = Instantiate(circlePrefab, shootPoint.transform.position, Quaternion.identity);
                Rigidbody2D rb = orbCopy.GetComponent<Rigidbody2D>();
                Vector2 direction = -transform.GetChild(0).right;
                rb.linearVelocity = direction * shootForce;
                yield return new WaitForSeconds(delayTime);
            }
            yield return null;
        }
    }
}
