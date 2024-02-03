using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;

public class PlayerSituation : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    public float waterlevel = 100f;
    public float hungerlevel = 100f;
    [Header("Images")]
    public Image healthimage;
    public Image hungerimage;
    public Image thirstimage;
    public static PlayerSituation instance;
    public GameObject thirst, hunger, freeze;
    private Animator animator;
    private bool isDead = false;
    [Header("GameObjects")]
    public GameObject riggun, gun;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }
    void Start()
    {
        InvokeRepeating("UpdateImage", 0, 1);
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (hungerlevel <= 30)
        {
            hunger.SetActive(true);
        }
        if (hungerlevel > 30)
        {
            hunger.SetActive(false);
        }
        if (health <= 0 && !isDead)
        {
            Die();
        }
        if (hungerlevel <= 40)
        {
            hungerlevel = 40;
        }
        if (waterlevel <= 40)
        {
            waterlevel = 40;
        }


    }
    void UpdateImage()
    {
        healthimage.fillAmount = health / 100;
        hungerimage.fillAmount = hungerlevel / 100;
        thirstimage.fillAmount = waterlevel / 100;

    }
    private void takeThirstDamage()
    {
      //  waterlevel = 0;
       // health -= 5 * Time.deltaTime;
    }

    private void takeHungerDamage()
    {
       // hungerlevel = 0;
      //  health -= 5 * Time.deltaTime;
    }
    public void takeFreezeDamage(float speed)
    {
      //  health -= speed * Time.deltaTime;
    }
    private void Die()
    {
        animator.SetTrigger("isDead");
        gun.SetActive(false);
        riggun.GetComponent<Rig>().weight = 0;
        isDead = true;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
    }

    public void takeDamage(float a)
    {
       health -= a;

    }
}
