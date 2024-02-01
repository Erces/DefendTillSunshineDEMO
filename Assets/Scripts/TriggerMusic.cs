using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip clip;
    public AudioSource soundtrackManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("'''");
        if (other.tag == "Player")
        {
            Debug.Log("music!");
            soundtrackManager.GetComponent<SoundtrackPlay>().playSong(clip);
            Destroy(gameObject);
        }
    }
}
