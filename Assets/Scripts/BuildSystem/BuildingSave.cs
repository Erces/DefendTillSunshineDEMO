using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingSave :  MonoBehaviour
{
    public konum location;
     
    void OnEnable()
    {
        GetComponent<SaveableEntity>().GenerateId();
        location.x = GetComponent<Transform>().position.x;
        location.y = GetComponent<Transform>().position.y;
        location.z = GetComponent<Transform>().position.z;
        LoadInstances.instance.objects.Add(location);
    }
   


    
}
[System.Serializable]
public class konum
{
    public float x, y, z;
}
