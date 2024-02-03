using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSpawner : MonoBehaviour
{
    [Header("SpawnableItems")]
    [SerializeField] private GameObject mushroom;
    

    [Header("CountsPerDay")]
    [SerializeField] private int countmushroom;
    


    void Start()
    {
        DayNightCycle.onDayPass += SpawnNatureItems;
        
    }

    
    void Update()
    {
        
    }

    void SpawnNatureItems()
    {
        RaycastHit hit;

        for (int i = 0;i < countmushroom; i++)
        {
            Vector3 position = new Vector3(Random.Range(400, 600), 0, Random.Range(400, 600));
            Vector3 vektor = new Vector3(0, 100, 0);



            if (Physics.Raycast(position + vektor, Vector3.down, out hit, 200))
            {
                if (hit.transform.tag == "Ground")
                {
                    GameObject mantar = Instantiate(mushroom, hit.point, Quaternion.identity);
                    mantar.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                }
                else
                {
                    i--;
                }
            }
            else
            {
                Debug.Log("no ground");
            }


        }
    }
}
