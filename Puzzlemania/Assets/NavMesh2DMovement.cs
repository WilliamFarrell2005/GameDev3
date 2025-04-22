using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;

public class NavMesh2DMovement : MonoBehaviour
{
    public float rotation;
    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private Transform visionField;
    private static int goesLeft = Animator.StringToHash("goesLeft");
    private static int goesRight = Animator.StringToHash("goesRight");
    private static int goesUp = Animator.StringToHash("goesUp");
    private static int goesDown = Animator.StringToHash("goesDown");
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        visionField = transform.GetChild(0);
    }
   
    void Update()
    {
        rotation = visionField.rotation.eulerAngles.z;
        switch (rotation)
        {
            case <= 45 and >= 0 or <= 360 and > 315:
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
        agent.SetDestination(target.position);
        var targetRotation = Quaternion.LookRotation(visionField.forward, visionField.position - target.position); 
        targetRotation *= Quaternion.Euler(0, 0, 90);
        visionField.rotation = targetRotation;
    }
}