using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoorOpen : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    public AudioClip[] clips;
    public AudioSource source;
    public float timetoopen;
    private bool ready;
    public void Start()
    {
        ready = true;
        source = GetComponent<AudioSource>();
        DOTween.Init();
        
        
        
    }
    public void triggerDoor()
    {
        Debug.Log("Triggering");
        Vector3 opendoor = new Vector3(0, transform.rotation.eulerAngles.y - 90, 0);
        Vector3 closedoor = new Vector3(0, transform.rotation.eulerAngles.y + 90, 0);
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
            source.PlayOneShot(clips[0]);
            transform.DORotate(opendoor, timetoopen);
            //transform.DOLocalRotate(opendoor, timetoopen);

            isOpen = !isOpen;
            Invoke("waitfor", 1f);
        }
    }

    private void OnMouseDown()
    {
      //  triggerDoor();
    }
    void waitfor()
    {
        ready = true;
    }
}
