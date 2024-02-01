using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    [Header("Specs")]
    public int Health;
    public float Age;
    private bool isDead;

    public Animator animator;
    private SphereCollider sphere;
    private NavMeshAgent agent;
    private FoxYapayZeka fox;
    public GameObject meat;
    public GameObject player;

    public Collider sword;
    public GameObject effect;

    private AudioSource source;
    public AudioClip clip;
    void Start()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        fox = GetComponent<FoxYapayZeka>();
        isDead = false;
        sphere = GetComponent<SphereCollider>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0 && !isDead)
        {
            Die();
        }
    }
    public void takeDamage(int _damage)
    {
        source.PlayOneShot(clip);
       transform.LookAt(player.transform.position);
      
        Health -= _damage;
        if (Health<= 0)
        {
            return;
        }
        animator.SetTrigger("TakeDamage");
        Vector3 closestOnAnimal = sword.ClosestPointOnBounds(sword.transform.position);
        Instantiate(effect, closestOnAnimal, Quaternion.identity);
        fox.awarenessArea = 500;
    }
    public void takeDamageLeft(int _damage)
    {
        Health -= _damage;
        if (Health <= 0)
        {
            return;
        }
        animator.SetTrigger("L_Damage");
        
        fox.awarenessArea = 500;
    }
    public void takeDamageRight(int _damage)
    {
        Health -= _damage;
        if (Health <= 0)
        {
            return;
        }
        animator.SetTrigger("R_Damage");
        
        fox.awarenessArea = 500;
    }
    void Die()
    {
        animator.SetTrigger("IsDead");
        isDead = true;
        Debug.Log("Animal dying");
        fox.enabled = false;
        Instantiate(meat, transform.position, transform.rotation);
        foreach (Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = false;
        }
        
        
        agent.ResetPath();
        agent.enabled = false;
        
        
        
        
        
        sphere.enabled = false;
    }
}
