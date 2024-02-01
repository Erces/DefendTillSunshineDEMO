using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Predator : MonoBehaviour
{
    public float magnitude;
    public bool walkPointSet, search, playerInRange, attacking,chasing,playerInAttackRange;
    public NavMeshAgent agentfox;
    public Vector3 walkPoint, escapePoint;
    public float walkPointRange = 5, playercheckradius,playerattackradius;
    public LayerMask whatIsGround, whatIsPlayer;
    public Animator animator;
    public Collider[] collist;
    public Transform playertransform;
    public float kalanmesafe;
    void Start()
    {
        walkPointSet = false;
        search = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, playercheckradius, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, playerattackradius, whatIsPlayer);
        if (playerInRange && !playerInAttackRange)
        {
            attacking = false;
            chasing = true;
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", false);
            

        }
        if (playerInAttackRange)
        {
            attacking = true;
        }
        if (chasing)
        {
           
            Chase();
        }
         if (attacking)
        {
            Attacking();
        }
         if (!attacking && !chasing)
        {
            playercheckradius = 10;
            Patrolling();
        }






    }

    private void Attacking()
    {
        agentfox.SetDestination(playertransform.position);
        animator.SetBool("IsAttacking", true);
    }

    public void Chase()
    {
        animator.SetBool("IsAttacking", false);
        collist = Physics.OverlapSphere(transform.position, playercheckradius, whatIsPlayer);
        if (collist.Length != 0)
        {
            playertransform = collist[0].transform;
        }
       // escapePoint = playertransform.position - transform.position;
      //  escapePoint = (transform.position - (5 * escapePoint));
      //  Vector3 distanceToEscapePoint = transform.position - escapePoint;
        agentfox.SetDestination(playertransform.position);
        
    }
    private void Patrolling()
    {
        animator.SetBool("IsAttacking", false);
        if (!walkPointSet && search)

            StartCoroutine(SearchWalkPoint());
        search = false;
       
        animator.SetBool("Idle", true);
        animator.SetBool("Run", false);
       animator.SetBool("Walk", false);
        if (walkPointSet)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Walk", true);

            agentfox.SetDestination(walkPoint);
            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 0.15f)
                walkPointSet = false;
            search = true;
        }
    }

    private IEnumerator SearchWalkPoint()
    {

        float waitfor = UnityEngine.Random.Range(5, 15);
        Debug.Log(waitfor);
        yield return new WaitForSecondsRealtime(waitfor);
        float randomZ = UnityEngine.Random.RandomRange(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.RandomRange(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {

            walkPointSet = true;

        }
        else
        {


            walkPointSet = true;

        }
    }
}
