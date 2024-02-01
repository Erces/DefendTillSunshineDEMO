using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentPlace : MonoBehaviour
{
    public GameObject tent;
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           GameObject tentplace = Instantiate(tent,player.position + (Vector3.forward * -0.5f) , player.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
