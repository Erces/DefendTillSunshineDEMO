using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        rb.AddForce(transform.right * 1000);
    }
}
