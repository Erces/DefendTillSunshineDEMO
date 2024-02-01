using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetSkills : MonoBehaviour
{
    public NavMeshAgent pet;
    private Vector3[] points = new Vector3[4];
    private Vector3 sky;
    private bool isExploring;
    public int count;
   
    void Start()

    {
        pet = GetComponent<NavMeshAgent>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoneReachingDestination() && isExploring)
        {

            Explore();
        }
    }

    public void Explore()
    {
        if (count == 4)
        {
            isExploring = false;
            return;
        }
        isExploring = true;
        
        points[0] = new Vector3(transform.position.x + Random.Range(0,15), transform.position.y, transform.position.z + Random.Range(0, 15));
        points[1] = new Vector3(transform.position.x + Random.Range(0, 15), transform.position.y, transform.position.z + Random.Range(0, 15));
        points[2] = new Vector3(transform.position.x + Random.Range(0, 15), transform.position.y, transform.position.z + Random.Range(0, 15));
        points[3] = new Vector3(transform.position.x + Random.Range(0, 15), transform.position.y, transform.position.z + Random.Range(0, 15));
        
        Vector3 sky2 = (Vector3.up*100)+ points[count];

        RaycastHit hit;







        checkExploreLocation(sky2, count);
        count++;


    }
    public bool checkExploreLocation(Vector3 sky,int count)
    {
        RaycastHit hit;
        if (Physics.Raycast(sky, Vector3.down, out hit, 400))
        {
            if (hit.transform.tag == "Ground")
            {
                Pet.instance.chillrange = 500;
                pet.SetDestination(points[count]);
                return true;
            }
            else
            {
                
                return false;
            }
        }
        return false;
    }
    bool DoneReachingDestination()
    {
        if (!pet.pathPending)
        {
            if (pet.remainingDistance <= pet.stoppingDistance)
            {
                if (!pet.hasPath || pet.velocity.sqrMagnitude == 0f)
                {
                    //Done reaching the Destination
                    Pet.instance.chillrange = 3;
                    return true;
                }
            }
        }

        return false;
    }
}
