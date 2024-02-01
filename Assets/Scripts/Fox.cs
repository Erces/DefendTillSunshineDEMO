using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Fox : MonoBehaviour
{
    public float magnitude;
    public bool walkPointSet, search,playerInRange,escaping ;
    public NavMeshAgent agentfox;
    public Vector3 walkPoint,escapePoint;
    public float walkPointRange = 5,playercheckradius;
    public LayerMask whatIsGround,whatIsPlayer;
    public Animator animator;
    public Collider[] collist;
    public Transform playertransform;
    public float kalanmesafe;
    void Start()
    {
        walkPointSet = false;
        search = true;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        playerInRange = Physics.CheckSphere(transform.position, playercheckradius, whatIsPlayer);
        if (playerInRange)
        {
            escaping = true;
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", false);
            
        }
        if (escaping)
        {
           
            Escape();
        }
        else if(!escaping)
        {
            playercheckradius = 0;
            Patrolling();
        }
            
        
        
        
        

    }
    public void Escape()
    {
        
        agentfox.speed = 2;
        collist = Physics.OverlapSphere(transform.position, playercheckradius, whatIsPlayer);
        if (collist.Length!= 0)
        {
            playertransform = collist[0].transform;
        }
        escapePoint = playertransform.position - transform.position;
        escapePoint = (transform.position - (5*escapePoint));
        Vector3 distanceToEscapePoint = transform.position - escapePoint;
        agentfox.SetDestination(escapePoint);
        escaping = false;
        if (distanceToEscapePoint.magnitude <magnitude)
        {
            escaping = false;
        }
    }
    private void Patrolling()
    {
        agentfox.speed = 1f;
        if (!walkPointSet && search)
            
            StartCoroutine(SearchWalkPoint());
        animator.SetBool("Idle", true);
        animator.SetBool("Run", false);
        animator.SetBool("Walk", false);
        search = false;
           
        if (walkPointSet)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Walk", true);
           
            agentfox.SetDestination(walkPoint);
            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude <1f)
                walkPointSet = false;
            search = true;
        }
    }

    private IEnumerator SearchWalkPoint()
    {
        Debug.Log("IEnum");
        float waitfor = Random.Range(1, 3);
        Vector3 vektor = new Vector3(0, 100, 0);

        RaycastHit hit;
        yield return new WaitForSecondsRealtime(waitfor);
        float randomZ = Random.RandomRange(-walkPointRange, walkPointRange);
        float randomX = Random.RandomRange(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint+vektor, -transform.up, out hit, 200))
        {
            Debug.Log(hit.transform.name);
            walkPointSet = true;

            
        }
        else
        {

            search = true;
            walkPointSet = false;
            
        }
    }
}
