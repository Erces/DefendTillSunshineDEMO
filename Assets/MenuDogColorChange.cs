using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDogColorChange : MonoBehaviour
{
    public GameObject dog;
    public Material[] materials;
    private int i = 0;
   
    void Start()
    {
        
        
    }

    // Update is called once per frame
    public void onChange()
    {
        if (i == 4)
        {
            i = 0;
        }
        dog.GetComponent<Renderer>().material = materials[i];
        PlayerPrefs.SetInt("DogSelect", i);
        i++;
        
       
    }
}
