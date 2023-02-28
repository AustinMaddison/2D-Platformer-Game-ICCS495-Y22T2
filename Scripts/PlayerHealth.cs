using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public GameObject deathEffect;
    public Transform fxSpawn;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(health);
        healthBar.SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health= 0;
            Die();
        }

        healthBar.SetHealth(health);
    }


    public void Heal(int heal)
    {
        health += heal;
        if(health > maxHealth)
        {
            health = maxHealth; 
        }
    }

    void Die()
    {
        Instantiate(deathEffect, fxSpawn.position, Quaternion.identity);
        Destroy(gameObject);
        FindObjectOfType<ChangeScene>().RestartLevel();

    }
}
