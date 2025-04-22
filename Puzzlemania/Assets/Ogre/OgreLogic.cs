using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.PlayerLoop;

public class OgreLogic : MonoBehaviour
{
    public float attackFrequency = 2;
    private Transform target;
    public float maxLengthOfTheRaybeam;
    private LineRenderer lineRenderer;
    private PlayerHealth mainCharacterScript;
    public float damage;
    private bool canMove;
    private bool canAttack;
    private NavMeshAgent agent;
    private NavMesh2DMovement movementScript;
    private Animator animator;
    private int notMoving = Animator.StringToHash("notMoving");
    private AudioSource sound;
    void Start()
    {
        canMove = true;
        canAttack = false;
        sound = gameObject.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        movementScript = GetComponent<NavMesh2DMovement>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mainCharacterScript = target.GetComponent<PlayerHealth>();
        sound.mute = true;
        StartCoroutine(raybeamAttack(attackFrequency));
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (canMove)
        {
            canAttack = true;
            animator.SetBool(notMoving, false);
            agent.enabled = true;
            movementScript.enabled = true;
            sound.mute = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        agent.enabled = false;
        movementScript.enabled = false;
        animator.SetBool(notMoving, true);
        canAttack = false;
        sound.mute = true;
    }
    
     IEnumerator raybeamAttack(float delayTime)
     {
        while (true) {
            if  (canAttack){
                Vector2 startPoint = transform.GetChild(0).position;
                Vector2 endPoint = target.position;
                Vector2 direction = endPoint - startPoint;
                RaycastHit2D ray = Physics2D.Raycast(startPoint, direction, maxLengthOfTheRaybeam);
                Vector2 hitPoint = ray ? ray.point : (startPoint + direction.normalized * maxLengthOfTheRaybeam);
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, startPoint);
                lineRenderer.SetPosition(1, hitPoint);
                float timer = 0f;
                agent.enabled = false;
                movementScript.enabled = false;
                animator.SetBool(notMoving, true);
                canMove = false;
                canAttack = false;
                while (timer < delayTime)
                {
                    direction = hitPoint - startPoint;
                    ray = Physics2D.Raycast(startPoint, direction.normalized, direction.magnitude);
                    if (ray && ray.collider.CompareTag("Player"))  mainCharacterScript.TakeDamage(damage * Time.deltaTime);
                    timer += Time.deltaTime;
                    yield return null;
                }
            }
            yield return new WaitForSeconds(delayTime);
            canMove = true;
            lineRenderer.enabled = false;
        }
    }
}
