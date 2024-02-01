using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hover, click;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void hoverSound()
    {
        source.PlayOneShot(hover);
    }
     public void clickSound()
    {
        source.PlayOneShot(click);
    }
}
