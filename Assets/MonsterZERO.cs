using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterZERO : MonoBehaviour
{
    public GameObject player;
    public float distance, walkSpeed;
    public GameObject kaya;
    private Transform spawningpos;
    public Vector3 ortanokta,walkPoint;
    private Vector3 sky = new Vector3(0, 50, 0);

    public bool action;
    [Header("YapayZeka")]
    private bool canAttack;
    public NavMeshAgent monster;
    public enum AIState { Idle, Run, Attack }
    public AIState currentState = AIState.Idle;
    public Animator animator;
    public Transform enemy,escapePoint;
    void Start()
    {
        canAttack = true;
        animator = GetComponent<Animator>();
        monster = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Abs( Vector3.Distance(player.transform.position, gameObject.transform.position));
        ortanokta = new Vector3((player.transform.position.x + gameObject.transform.position.x) / 2, (player.transform.position.y + gameObject.transform.position.y) / 2, (player.transform.position.z + gameObject.transform.position.z) / 2);

        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine("attack");
        }
        if (currentState == AIState.Idle)
        {
            monster.speed = walkSpeed;
            if (enemy)
            {
                StopAllCoroutines();
                currentState = AIState.Run;
                switchAnimations(currentState);

            }
            if (action && !enemy)
            {
                StartCoroutine(WalkAround());

                action = false;
            }
        }
        else if (currentState == AIState.Run)
        {
            monster.speed = walkSpeed;
          
            if (action)
            {
                RaycastHit hit;
                action = false;
                float randomZ = Random.RandomRange(-15, 15);
                float randomX = Random.RandomRange(-15, 15);
                Vector3 vektor = new Vector3(0, 300, 0);

                walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
                if (Physics.Raycast(walkPoint + vektor, Vector3.down, out hit, 500))
                {
                    if (hit.transform.tag != "Ground")
                    {
                        return;
                    }
                    Debug.Log(hit.transform.name);
                    Debug.Log("Ground hitUP!");
                    if (hit.transform.tag == "Ground")
                    {

                        monster.SetDestination(walkPoint);
                    }
                }
               
                else
                {
                    action = true;
                }


            }
            if (DoneReachingDestination())
            {
                Debug.Log("DoneReachingDestination");
                currentState = AIState.Idle;
                action = true;
            }
        }
        else if (currentState == AIState.Attack)
        {
            monster.speed = walkSpeed;

            if (action)
            {
                RaycastHit hit;
                action = false;
                float randomZ = Random.RandomRange(-15, 15);
                float randomX = Random.RandomRange(- 15, 15);
                Vector3 vektor = new Vector3(0, 300, 0);

                walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
                if (Physics.Raycast(walkPoint + vektor, Vector3.down, out hit, 500))
                {
                    if (hit.transform.tag != "Ground")
                    {
                        return;
                    }
                    Debug.Log(hit.transform.name);
                    Debug.Log("Ground hitUP!");
                    if (hit.transform.tag == "Ground")
                    {

                        monster.SetDestination(walkPoint);
                    }
                }

                else
                {
                    action = true;
                }


            }
            if (DoneReachingDestination())
            {
                Debug.Log("DoneReachingDestination");
                currentState = AIState.Idle;
                action = true;
            }
        }

    }
    IEnumerator attack()
    {
        if (!canAttack)
        {
            yield return null;
        }
        GameObject rock = (GameObject)Instantiate(kaya, ortanokta, Quaternion.identity);
        //2 nokta bulunmasi gerekecek
        Debug.Log("Monster rock spawn");

        yield return new WaitForSeconds(0.9f);
        GameObject rock2 = (GameObject)Instantiate(kaya, player.transform.position, Quaternion.identity);


    }
    IEnumerator WalkAround()
    {
        switchAnimations(currentState);
        yield return new WaitForSeconds(Random.Range(3, 5));


        currentState = AIState.Run;
        switchAnimations(currentState);
        action = true;
    }
    bool DoneReachingDestination()
    {
        if (!monster.pathPending)
        {
            if (monster.remainingDistance <= monster.stoppingDistance)
            {
                if (!monster.hasPath || monster.velocity.sqrMagnitude == 0f)
                {
                    //Done reaching the Destination
                    return true;
                }
            }
        }

        return false;
    }
    void switchAnimations(AIState state)
    {
        animator.SetBool("isRunning", state == AIState.Run);
        animator.SetBool("isAttacking", state == AIState.Attack);
        animator.SetBool("Idle", state == AIState.Idle);
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
