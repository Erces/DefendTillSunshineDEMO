using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogGrow : MonoBehaviour, ISaveable
{
    SkinnedMeshRenderer meshrenderer;
    public Material[] materials;
    [SerializeField] private float daycount;
    public GameObject dog;
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = materials[PlayerPrefs.GetInt("DogSelect")];
        DayNightCycle.onDayPass += Grow;
        meshrenderer = GetComponent<SkinnedMeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Grow()
    {
        


        }

    public object CaptureState()
    {
        return new SaveData
        {
            daycount = daycount
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;

        daycount = saveData.daycount;
    }
    [Serializable]
    private struct SaveData
    {
        public float daycount;
    }
}

