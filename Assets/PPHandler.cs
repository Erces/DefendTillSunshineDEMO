using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PPHandler : MonoBehaviour
{

    public Volume volume;
    public VolumeProfile low, medium, high, ultra;
    void Start()
    {
        if (PlayerPrefs.GetInt("PP") == 0)
        {
            volume.profile = low;

        }
        if (PlayerPrefs.GetInt("PP") == 1)
        {
            volume.profile = medium;


        }
        if (PlayerPrefs.GetInt("PP") == 2)
        {
            volume.profile = high;
        }
        if (PlayerPrefs.GetInt("PP") == 3)
        {
            volume.profile = ultra;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
