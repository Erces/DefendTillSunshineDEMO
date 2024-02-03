using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationHandlerMusic : MonoBehaviour
{
    public static NotificationHandlerMusic instance;
    public AudioClip notificationSound;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (instance != null)
        {
            Debug.Log("More than 1 musicnotif");
            return;
        }
        instance = this;

    }

    // Update is called once per frame
    public void playNotSound()
    {
        source.PlayOneShot(notificationSound);
    }
}
