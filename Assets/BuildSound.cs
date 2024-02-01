using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSound : MonoBehaviour
{
    public static BuildSound instance;
    public AudioSource source;
    public AudioClip clip;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Error buildsound");
            return;
        }
        instance = this;
    }
    public void playSound()
    {
        source.PlayOneShot(clip);
    }
}
