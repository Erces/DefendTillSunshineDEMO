using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private EnemyAI ai;
    public float health = 500;
    [SerializeField] private float number = 3;
    public GameObject moneyprefab;
    public Animator animator;
    public NavMeshAgent agent;
    public SphereCollider sphere;
    private void Start()
    {
       
        ai = this.GetComponent<EnemyAI>();
        agent = this.GetComponent<NavMeshAgent>();
    }
    public void takeDamage (float amount)
    {
        agent.speed = 0.05f;
        animator.SetTrigger("takeDamage");
        health -= amount;
        
            ai.sightRange += 15f;
        
        if (health <= 0f)
        {
            number = Random.Range(0, 10);
            Die();
        }
    }
    void Die()
    {
        
        this.GetComponent<EnemyAI>().enabled = false;
        agent.radius = 0.1f;
        agent.height = 0.1f;
        sphere.isTrigger = true;
        agent.enabled = false;
        animator.SetBool("Death", true);
        
        Destroy(gameObject,10);
        this.GetComponent<Enemy>().enabled = false;
    }
}
