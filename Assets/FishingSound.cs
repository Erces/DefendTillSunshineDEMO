using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip start, middle, end;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartFishing()
    {
        source.PlayOneShot(start);
    }
    public void MiddleFishing()
    {
        source.PlayOneShot(middle);
    }
    public void EndFishing()
    {
        source.PlayOneShot(end);
    }
}
