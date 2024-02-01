using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Dog : MonoBehaviour
{
    [Header("Ayarlar")]
    [SerializeField] private float chillRange,barkRange,chaseRange,sleepRange,runRange;
   

    [SerializeField] private LayerMask whatIsPlayer,whatIsGround,whatIsZombie,whatIsSleepZone;

    private NavMeshAgent agentdog;
    private Animator animator;
    public Transform player, zombie,sleepZone;

    public bool playerInChillRange,playerInChaseRange, dogInSleepZone,playerInRunRange,walkPointSet,zombieInBarkRange, zombieInChaseRange,sit = false,sleeping = false;

    public float walkPointRange;
    public bool sitTooLong = false;
    public Vector3 walkPoint;
    public int dogtype = 0;
    public GameObject dog1, dog2, dog3;
    public Collider[] zombielist,sleep;
    public float magnitudeLevel;

    // Start is called before the first frame update
    void Start()
    {
        agentdog = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        playerInChillRange = Physics.CheckSphere(transform.position, chillRange, whatIsPlayer);
        playerInChaseRange = Physics.CheckSphere(transform.position, runRange, whatIsPlayer);
        
        dogInSleepZone = Physics.CheckSphere(transform.position, sleepRange, whatIsSleepZone);
        zombieInBarkRange = Physics.CheckSphere(transform.position, barkRange, whatIsZombie);
        zombieInChaseRange = Physics.CheckSphere(transform.position, chaseRange, whatIsZombie);

        if (playerInChillRange)
        {
            Patroling();
        }
        if (playerInChillRange && Input.GetKeyDown(KeyCode.H))
        {
            sit = !sit;
            StartCoroutine("Sitting", sit);
        }
        else if (!playerInChillRange && !playerInChaseRange)
        {
            ChasePlayer();
        }
     



    }
    private IEnumerator GoSleep() 
    {
        Debug.Log("Sleeping!");
        sleep = Physics.OverlapSphere(transform.position, sleepRange, whatIsSleepZone);
        sleepZone = sleep[0].transform;
        agentdog.SetDestination(sleepZone.position);
        float dist = agentdog.remainingDistance;
        

        sleeping = !sleeping;
        yield return null;
    }
    private IEnumerator Sitting(bool sit)
    {
        animator.SetBool("Sit", sit);
        float zaman = 4;

        if (sit)
        {
            zaman -= Time.deltaTime;
            agentdog.speed = 0;
            yield return new WaitForSeconds(8);
            if (sit)
            Debug.Log("Zaman");

        }
        else
        {
            agentdog.speed = 1f;
        }
        
        yield return null;
    }
    private void Patroling()
    {
       
       // agentdog.speed = 0.12f;
        animator.SetBool("Patroling", true);
        animator.SetBool("Chasing", false);
        animator.SetBool("Barking", false);

        if (!walkPointSet)
            SearchWalkPoint();
           
        if (walkPointSet)
            agentdog.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

      if (distanceToWalkPoint.magnitude < magnitudeLevel)
            walkPointSet = false;
       


    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.RandomRange(-walkPointRange, walkPointRange);
        float randomX = Random.RandomRange(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(player.position.x + randomX, player.position.y, player.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 10f, whatIsGround))
        {
            walkPointSet = true;
        }
        
    }
    private void ChasePlayer()
    {

       // agentdog.speed = 0.2f; 
        animator.SetBool("Patroling", false);
        animator.SetBool("Barking", false);
        animator.SetBool("Chasing", true);
        agentdog.SetDestination(player.position);
    }
    private void BarkZombie()
    {
        zombielist = Physics.OverlapSphere(transform.position, chaseRange, whatIsZombie);
        if (zombielist.Length != 0)
        {
            zombie = zombielist[0].transform;
        }
        transform.LookAt(zombie);
        animator.SetBool("Barking", true);
        animator.SetBool("Patroling", false);
        animator.SetBool("Chasing", false);

    }
    private void ChaseZombie()
    {
        zombielist = Physics.OverlapSphere(transform.position, chaseRange, whatIsZombie);
        if (zombielist.Length != 0)
        {
            zombie = zombielist[0].transform;
        }
        animator.SetBool("Patroling", false);
        animator.SetBool("Chasing", true);
        animator.SetBool("Barking", false);
        agentdog.SetDestination(zombie.position);
        

    }
    private void AttackZombie()
    {

    }

}
