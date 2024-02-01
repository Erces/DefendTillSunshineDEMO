using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public float walkspeed = 5f;
    public float chasespeed = 5f;
    public float attackspeed = 3f;
    public NavMeshAgent agent;
    public Animator animator;
    private Transform player;
    private GameObject playerg;
    

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public bool isChasing;
    public bool isAttacking;
    public bool isWalking;
    public LayerMask playermask;
    private bool hasTarget;
    Collider[] list;
    void Awake()
    {
       
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkspeed;
        

    }
    

    // Update is called once per frame
    void Update()
    {
        if (!hasTarget)
        {
            SearchTarget();
        }
        
        
        


        

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) 
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isChasing", false);
            animator.SetBool("isAttacking", false);
            
            isWalking = true;
            isChasing = false;
            isAttacking = false;
            Patroling();
        } 
        if (playerInSightRange && !playerInAttackRange)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isChasing", true);
            animator.SetBool("isAttacking", false);
            isWalking = false;
            isChasing = true;
            isAttacking = false;
            ChasePlayer();
        }
        
        if (playerInSightRange && playerInAttackRange)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isChasing", false);
            animator.SetBool("isAttacking", true);
            isWalking = false;
            isChasing = false;
            isAttacking = true;
            AttackPlayer();
        }
        
    }
    private void Patroling()
    {
        agent.speed = walkspeed;


        if (!walkPointSet)



            SearchWalkPoint();
        

            




        if (walkPointSet)

            
            agent.SetDestination(walkPoint);



        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }
    
        
    
    private void SearchWalkPoint()
    {
        float randomZ = Random.RandomRange(-walkPointRange, walkPointRange);
        float randomX = Random.RandomRange(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }



    }
    private void ChasePlayer()
    {
        agent.speed = chasespeed;
        
        agent.SetDestination(player.position);
        
    }
    private void AttackPlayer()
    {
        agent.speed = attackspeed;

        agent.SetDestination(player.position);
        transform.LookAt(player);
        if (!alreadyAttacked)
        {
           

            alreadyAttacked = true;
            Invoke("ResetAttack", timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
       

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {
            
            Knockback();
        }
    }
    private void Knockback()
    {
        Debug.Log("knockback");
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        agent.enabled = false;
        rigidBody.isKinematic = false;
        Vector3 test = new Vector3(2500, 0, 0); // currently just pushes to the right for testing purposes
        rigidBody.AddForce(test , ForceMode.Impulse);
        agent.enabled = true;
        rigidBody.isKinematic = true;
    }
    void SearchTarget()
    {
        list = Physics.OverlapSphere(transform.position, 25, whatIsPlayer);
        if (list.Length != 0)
        {
            player = list[0].transform;
            hasTarget = true;
        }
    }
}
