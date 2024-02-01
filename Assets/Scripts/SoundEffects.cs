using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects instance;
    public AudioSource audiosourceGun,audiosourceForest,audiosourceRain;
    public AudioClip gunSound;
    public AudioClip[] hatchetSound;
    private void Awake()
    {
        if (instance!= null)
        {
            Debug.Log("More Audio Manager");
            return;
        }
        
            instance = this;
        
    }
    void Start()
    {
        //audiosourceForest.Play();
        //audiosourceGun = GetComponent<AudioSource>();
    }

    public void playGunSound()
    {
        audiosourceGun.PlayOneShot(gunSound);
    }
    public void playHatchetSound()
    {
        audiosourceGun.PlayOneShot(hatchetSound[Random.Range(0,hatchetSound.Length)]);
    }

}
