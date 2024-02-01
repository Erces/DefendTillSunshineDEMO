using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Bed : MonoBehaviour
{
    public LayerMask ignore;
    public GameObject bedText,player,warningnotification;
    public PlayableDirector timeline;
    public bool readyToSleep;
   
    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 2)
        {



        }
    }
    private void OnMouseExit()
    {
        //bedText.SetActive(false);
    }
    private void Update()
    {
     //   Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
       // foreach (var hit in hitColliders)
        //{
           // if(hit.transform.tag == "AtticSelf")
           // {
           //     readyToSleep = true;
            //}
            
      //  }
    }
    public void BedWork()
    {

        Debug.Log("Over");
        //bedText.SetActive(true);
        if (Input.GetMouseButtonDown(0) && readyOrNot())
        {
            timeline.Play();
            player.SetActive(false);

        }
        else if (Input.GetMouseButtonDown(0) && !readyOrNot())
        {
            warningnotification.GetComponent<Animator>().SetTrigger("Not");
            NotificationHandlerMusic.instance.playNotSound();
        }
    }
    public bool readyOrNot()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        foreach (var hit in hitColliders)
        {
            if (hit.transform.tag == "AtticSelf")
            {
                readyToSleep = true;
                return true;
            }

        }
        return false;
    }
}
