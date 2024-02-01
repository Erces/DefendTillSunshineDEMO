using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipBlock : MonoBehaviour
{
    public GameObject[] list;
    public GameObject Notification;
    public void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered player to the tipblock");
       // foreach (var item in list)
      //  {
        //    item.GetComponent<TriggerBlocks>().enabled = true;
        //}
        if(Notification != null)
        {
            Debug.Log("Tipblock notification");
            Notification.GetComponent<Animator>().SetTrigger("Not");
        }
        
        Destroy(gameObject);
    }
}
