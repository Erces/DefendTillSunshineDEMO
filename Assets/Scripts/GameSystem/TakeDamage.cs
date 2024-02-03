using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TakeDamage : MonoBehaviour
{
    public int Health;
    private NavMeshAgent deeragent;
    private Animator deeranimator;
    private Predator predator;
    
   [SerializeField] private int maxHealth = 50;

    void Start()
    {
        predator = this.GetComponent<Predator>();
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
            predator.enabled = false;
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
        predator.playercheckradius = 100;
    }
}
