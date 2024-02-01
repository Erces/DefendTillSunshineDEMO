using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] bool isDead = false;
    [SerializeField] private GameObject log;

    [SerializeField] private Collider axe;
    [SerializeField] GameObject effect;
    // Update is called once per frame
    public GameObject[] trees;
    public GameObject lodtree,cuttree;
    [SerializeField] private int damagecount = 0;
    private void Start()
    {
        health = 50;
    }
    void Update()
    {
       
       if (health <= 0)
        {
            cuttree.SetActive(true);
        }
           
        
      
    }
    public void takeDamage(int _damage)
    {
        health -= _damage;
        damagecount++;
        if (health <= 0)
        {
            cuttree.SetActive(true);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Instantiate(log, transform.position, Quaternion.identity);
            Invoke("Die", 10);
            return;
        }
        lodtree.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            if (i == damagecount)
            {
                trees[damagecount].SetActive(true);
            }
            else
            {
                trees[i].SetActive(false);
            }
        }
        
        
        Vector3 closestOnAxe = axe.ClosestPointOnBounds(axe.transform.position);
        Instantiate(effect, closestOnAxe, Quaternion.identity);
        Debug.Log("Taking Tree Damage");
        health -= _damage;
       
    }
    void Die()
    {
        
        Destroy(gameObject);
    }
}
