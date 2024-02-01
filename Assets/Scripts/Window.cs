using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Window : MonoBehaviour
{
    public GameObject player;
    public float timetoopen;
    public bool ready,isOpen;
    private AudioSource source;
    public AudioClip[] clips;

    void OnEnable()
    {
        source = GetComponent<AudioSource>();
        ready = true;
        player = GameObject.Find("!MAINCHARACTER");
    }

    // Update is called once per frame
  
    public void triggerWindow()
    {
        Debug.Log("Triggering");
        Vector3 opendoor = new Vector3(0, transform.rotation.eulerAngles.y - 80, 0);
        Vector3 closedoor = new Vector3(0, transform.rotation.eulerAngles.y + 80, 0);
        if (isOpen && ready)
        {
            ready = false;
            source.PlayOneShot(clips[1]);
            transform.DORotate(closedoor, timetoopen);
            isOpen = !isOpen;
            Invoke("waitfor", 1f);
        }
        else if (!isOpen && ready)
        {
            ready = false;
           
            transform.DORotate(opendoor, timetoopen);
            //transform.DOLocalRotate(opendoor, timetoopen);
            source.PlayOneShot(clips[0]);
            isOpen = !isOpen;
            Invoke("waitfor", 1f);
        }
    }
    void waitfor()
    {
        ready = true;
    }
}
