using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notification : MonoBehaviour
{
    public GameObject not;
    private Animator animator;
    private void Start()
    {
        animator = not.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("Not");
            
            NotificationHandlerMusic.instance.playNotSound();
            Destroy(gameObject);
        }
    }
}
