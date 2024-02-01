using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxAI : MonoBehaviour
{
    public enum AIState { Idle, Walking, Running }
    public AIState currentState = AIState.Idle;
    private NavMeshAgent fox;
    public float walkRange = 5, awarenessArea = 5;
    public LayerMask whatIsGround, whatIsPlayer;
    private Animator animator;
    public Transform enemy;
    private float timer = 0;
    public float multiplier = 2f;
    public bool switchAction;
    private SphereCollider sphere;
    private Vector3  sky = new Vector3(0,100,0);

    private void Start()
    {
        animator = GetComponent<Animator>();
        fox = GetComponent<NavMeshAgent>();
        sphere = GetComponent<SphereCollider>();
        sphere.radius = awarenessArea;
    }
    private void SwitchAnimations(AIState state)
    {
        animator.SetBool("isWalking", state == AIState.Walking);
        animator.SetBool("isRunning", state == AIState.Running);
        animator.SetBool("Idle", state == AIState.Idle);
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            switchAction = true;
        }
        if (currentState == AIState.Idle)
        {
            if (switchAction)
            {
                
            
            
            if (enemy)
            {

                //Eger Dusman gelirse Idle de iken
                Vector3 runTo = transform.position + ((transform.position - enemy.position) * multiplier);
                fox.SetDestination(runTo);
                currentState = AIState.Running; //Kacma baslar
                
            }
            else
            {
                    SwitchAnimations(currentState);
                    switchAction = false;
                    timer = Random.Range(4, 8);
                    
                currentState = AIState.Walking;
                
                
            }


        }

    }
        else if (currentState == AIState.Walking)
        {
            
            
                //Walking girildi!
                
            
            if (enemy)
            {
                //Eger Dusman gelirse Idle de iken
                Vector3 runTo = transform.position + ((transform.position - enemy.position) * multiplier);

                enemy = null;
            }
            else
            {
                    timer = 99999;
                    switchAction = false;
                    
                    currentState = AIState.Walking;
                    SwitchAnimations(currentState);
                    FindWaypoint();
                  

                    


                }
            if (DoneReachingDestination())
            {
                currentState = AIState.Idle;
                timer = 1;
            }



            

        }
        else if (currentState == AIState.Running)
        {
            SwitchAnimations(currentState);
            

            if (DoneReachingDestination())
            {
                enemy = null;
                
                currentState = AIState.Idle;
            }




        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            enemy = other.transform;
        }

    }
    private void FindWaypoint()
    {
        RaycastHit hit;
        float randomZ = Random.RandomRange(-15, 15);
        float randomX = Random.RandomRange(-15, 15);
        Vector3 walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        fox.SetDestination(walkPoint);
        
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


}
