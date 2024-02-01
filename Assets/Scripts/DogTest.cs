using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogTest : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    public Transform deneme;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(deneme.position);
    }
}
