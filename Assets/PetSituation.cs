using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetSituation : MonoBehaviour
{
    private Animator animator;

    public float hunger, thirst, health;
    public float maxHunger = 100, maxThirst = 100, maxHealth = 100;
    private bool isDead;
    public Pet pet;
    public Image healthImage;
    public GameObject healthBar;
    private void Start()
    {
        animator = GetComponent<Animator>();
        pet = GetComponent<Pet>();

        InvokeRepeating("UpdateHealthBar", 1.5f, 1.5f);
        isDead = false;
        hunger = maxHunger;
        thirst = maxThirst;
        health = maxHealth;
    }
    private void Update()
    {
        healthImage.fillAmount = health/100;
        if (health <= 0 && !isDead)
        {
            Die();
            return;
        }
       
        if (hunger < 30)
        {
            takeHungerDamage();
        }
        else if (thirst < 30)
        {
            takeThirstDamage();
        }
        hunger -= 0.2f * Time.deltaTime;
        thirst -= 0.2f * Time.deltaTime;
    }
    private void UpdateHealthBar()
    {
        if (health < 50 && health > 25)
        {
            healthBar.SetActive(true);
            healthImage.color = Color.yellow;

        }
        if (health <= 25)
        {
            healthImage.color = Color.red;
        }

        if (health >= 50)
        {
            healthBar.SetActive(false);
        }
    }
    void takeHungerDamage()
    {
        health -= 5 * Time.deltaTime;
    }
    void takeThirstDamage()
    {
        health -= 5 * Time.deltaTime;

    }
    void takeDamage(float x)
    {

    }
    void Die()
    {
        isDead = true;
        pet.enabled = false;
        animator.SetTrigger("Die");
    }

    void Revive()
    {

    }
}
