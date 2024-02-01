using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    public int index = 0;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void npcTalk()
    {
        if (index == 2)
        {
            Destroy(this);
        }
        source.PlayOneShot(clips[index]);
        index++;
    }
    
}
