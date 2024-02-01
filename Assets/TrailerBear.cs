using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TrailerBear : MonoBehaviour
{
    public Transform hedef;
    private NavMeshAgent bear;
    void Start()
    {
        bear = this.GetComponent<NavMeshAgent>();
        bear.SetDestination(hedef.position);
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
