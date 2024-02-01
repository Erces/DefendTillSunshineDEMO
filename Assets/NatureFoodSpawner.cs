using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureFoodSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        DayNightCycle.onDayPass += SpawnFood;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnFood()
    {
        foreach (var grass in GameObject.FindGameObjectsWithTag("foodgrass"))
        {
            if (grass.name == "grass1")
            {
                grass.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
