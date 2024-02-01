using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{

    
    public GameObject shatteredBottle,audioSource;
    private void Start()
    {
        
    }
    public void Shatter()
    {
        Instantiate(shatteredBottle, transform.position, transform.rotation);
        Instantiate(audioSource, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
   
}
