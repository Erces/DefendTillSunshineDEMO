using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class LoadInstances : MonoBehaviour, ISaveable
{
    public static LoadInstances instance;
    public  List<konum> objects;
    public GameObject wall;
    public GameObject wall2;
    
    //public Transform spawningpos;
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Already loadinstance");
            return;
        }
        instance = this;
    }
    public object CaptureState()
    {
        return new SaveData
        {
            objects = objects
            
        };
    }

    public void RestoreState(object state)
    {

        var saveData = (SaveData)state;
        objects = saveData.objects;
        foreach (var item in objects)
        {
           // spawningpos.position = new Vector3(item.x, item.y, item.z);
            Debug.LogError("1");
            GameObject partic = Instantiate(wall,new Vector3(item.x, item.y, item.z), Quaternion.identity);
        }
        
    }
    [Serializable]
    private struct SaveData
    {
        
        public List<konum> objects;
    }
}
