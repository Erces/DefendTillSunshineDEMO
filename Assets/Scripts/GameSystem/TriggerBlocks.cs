using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerBlocks : MonoBehaviour
{
    
    public GameObject Notification;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Notification.GetComponent<Animator>().SetTrigger("Not");
            NotificationHandlerMusic.instance.playNotSound();
            Destroy(gameObject);
        }
       

    }

}
