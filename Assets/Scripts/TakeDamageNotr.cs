using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TakeDamageNotr : MonoBehaviour
{
    public int Health;
    public NavMeshAgent deeragent;
    public Animator deeranimator;
    public Fox fox;
    public GameObject meat;

    [SerializeField] private int maxHealth = 50;

    void Start()
    {
        fox = this.GetComponent<Fox>();
        deeranimator = this.GetComponent<Animator>();
        deeragent = this.GetComponent<NavMeshAgent>();
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void takeDamage(int a)
    {
        Health -= a;
        if (Health <= 0)
        {
            
               Instantiate(meat, transform.position, Quaternion.identity);
            
;            
            fox.enabled = false;
            deeranimator.SetTrigger("IsDead");
            deeragent.speed = 0;
            foreach (Collider c in GetComponentsInChildren<Collider>())
            {
                c.enabled = false;
            }
            deeragent.radius = 0;
            deeragent.height = 0;
            return;
        }
        deeranimator.SetTrigger("TakeDamage");
        fox.playercheckradius = 500;
    }
}
