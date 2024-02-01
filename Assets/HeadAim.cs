using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAim : MonoBehaviour
{
    public Transform head;
    public Transform player;
    
  

    // Update is called once per frame
    void Update()
    {
        head.LookAt(player);
    }
}
