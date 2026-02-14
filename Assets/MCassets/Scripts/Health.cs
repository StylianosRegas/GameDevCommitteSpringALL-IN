using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public GameObject player;
    public GameObject Respawn;

    //Add this once you hahve death animation
    //public Animator anim;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            player.transform.position = Respawn.transform.position;
            Start();
        }
    }

    public void Regen()
    {
        if(currentHealth < maxHealth)
        {
            currentHealth++;
        }
    }

    public void Sheild()
    {
        if (currentHealth <= maxHealth)
        {
            currentHealth++;
        }
    }
}
