using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform arrowstart;
    public GameObject arrow;
    public float force;
    private Rigidbody rb;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Bow");
        }
     if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Bow");
                GameObject arr = Instantiate(arrow, arrowstart.position,Quaternion.identity);
                Rigidbody rb2 = arrow.GetComponent<Rigidbody>();
            rb2.AddForce(arrowstart.forward * force * 200, ForceMode.Impulse);
            
        }  
    }
}
