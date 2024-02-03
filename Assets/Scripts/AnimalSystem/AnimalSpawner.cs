using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public static AnimalSpawner instance;
    public int maxFoxCount, maxDeerCount, maxBearCount;


    //public Transform[] spawnLocations_Fox;
    //public Transform[] spawnLocations_Deer;
    //public Transform[] spawnLocations_Bear;
    
    public GameObject fox,deer,bear;
    public int foxcount, deercount, bearcount;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance");
            return;
        }
        instance = this;
    }
    public void spawnFox()
    {
        if (foxcount >= maxFoxCount)
        {
            return;
        }
        RaycastHit hit;

        //Spawn
        Vector3 position = new Vector3(Random.Range(400, 600), 0, Random.Range(400, 600));
        Vector3 vektor = new Vector3(0, 100, 0);



        if (Physics.Raycast(position + vektor, Vector3.down, out hit, 200))
        {
            if (hit.transform.tag == "Ground")
            {
                GameObject tilki = Instantiate(fox, hit.point, Quaternion.identity);
                tilki.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            
        }
        else
        {
            Debug.Log("no ground");
        }
    }
}
