using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    public AudioSource music;
    public float mvolume = 1f;
    void Start()
    {
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mvolume);
        music.volume = mvolume;
    }
    public void changeMusicVolume( float value )
    {
        mvolume = value;
        Debug.Log(mvolume);
    }
}
