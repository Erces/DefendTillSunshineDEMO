using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Bear : MonoBehaviour
{

    public enum AIState { Idle, Walking, Running }
    public AIState currentState = AIState.Idle;
    private NavMeshAgent fox;
    private Animator animator;
    public Vector3 walkPoint;
    [Header("Speeds")]
    public float walkSpeed;
    public float runSpeed;

    [SerializeField] private bool action = true;
    [SerializeField] private float awarenessArea;
    [SerializeField] private Transform enemy, escapePoint;
    private bool set = true;
    [SerializeField] private float runMultiplier;
    private SphereCollider col;
    private Vector3 sky = new Vector3(0, 50, 0);


    void switchAnimations(AIState state)
    {
        animator.SetBool("isRunning", state == AIState.Running);
        animator.SetBool("isWalking", state == AIState.Walking);
        animator.SetBool("Idle", state == AIState.Idle);
    }



    void Start()
    {

        col = this.GetComponent<SphereCollider>();
        col.radius = awarenessArea;
        col.isTrigger = true;
        fox = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == AIState.Idle)
        {
            fox.speed = walkSpeed;
            if (enemy)
            {
                StopAllCoroutines();
                currentState = AIState.Running;
                switchAnimations(currentState);

            }
            if (action)
            {
                StartCoroutine(WalkAround());

                action = false;
            }
        }
        else if (currentState == AIState.Walking)
        {
            fox.speed = walkSpeed;
            if (enemy)
            {
                StopAllCoroutines();
                currentState = AIState.Running;
                switchAnimations(currentState);

            }
            if (action)
            {
                RaycastHit hit;
                action = false;
                float randomZ = Random.RandomRange(-15, 15);
                float randomX = Random.RandomRange(-15, 15);
                walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
                if (Physics.Raycast(walkPoint, Vector3.up, out hit, 300))
                {

                    Debug.Log(hit.transform.name);
                    Debug.Log("Ground hitUP!");
                    if (hit.transform.tag == "Ground")
                    {

                        fox.SetDestination(walkPoint);
                    }
                }
                else if (Physics.Raycast(walkPoint, Vector3.down, out hit, 300))
                {
                    Debug.Log(hit.transform.name);
                    Debug.Log("Ground hitUP!");
                    if (hit.transform.tag == "Ground")
                    {

                        fox.SetDestination(walkPoint);
                    }
                }
                else
                {
                    action = true;
                }


            }
            if (DoneReachingDestination())
            {
                currentState = AIState.Idle;
                action = true;
            }
        }
        else if (currentState == AIState.Running)
        {
            NavMeshPath path = new NavMeshPath();
            enemy = null;

            RaycastHit hit;
            fox.speed = runSpeed;
            Vector3 runTo = transform.position + ((transform.position - escapePoint.position) * runMultiplier);
            Vector3 warningRun = -(transform.position + ((transform.position - escapePoint.position) * runMultiplier));

            if (Physics.Raycast(runTo + sky, Vector3.down, out hit, 300) && set)
            {
                fox.CalculatePath(runTo, path);
                Debug.Log(hit.transform.name);
                Debug.Log(path.status);
                if (path.status == NavMeshPathStatus.PathInvalid)
                {
                    Debug.Log("Cant reach the destination!");
                    runTo = warningRun;

                }


                if (hit.transform.tag == "Ground")
                {
                    set = false;
                    Debug.Log("Ground hit!");
                    fox.SetDestination(runTo);
                }
                else
                {
                    set = false;
                    fox.SetDestination(runTo);
                }
            }


            // fox.SetDestination(runTo);


            if (DoneReachingDestination())
            {
                set = true;
                enemy = null;
                currentState = AIState.Idle;
                switchAnimations(currentState);
                action = true;
            }
        }
    }

    IEnumerator WalkAround()
    {
        switchAnimations(currentState);
        yield return new WaitForSeconds(Random.Range(41, 115));


        currentState = AIState.Walking;
        switchAnimations(currentState);
        action = true;
    }
    bool DoneReachingDestination()
    {
        if (!fox.pathPending)
        {
            if (fox.remainingDistance <= fox.stoppingDistance)
            {
                if (!fox.hasPath || fox.velocity.sqrMagnitude == 0f)
                {
                    //Done reaching the Destination
                    return true;
                }
            }
        }

        return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            enemy = other.transform;
            escapePoint = enemy;
        }
    }
}
