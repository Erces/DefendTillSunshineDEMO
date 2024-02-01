using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackPlay : MonoBehaviour
{
    public AudioSource audiosource;
    
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSong(AudioClip audio)
    {
        audiosource.PlayOneShot(audio);
    }
}
