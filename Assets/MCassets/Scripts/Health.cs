using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    public int maxHealth = 4;
    public int currentHealth;
    public GameObject player;
    public GameObject Respawn;
    public GameObject Revive;
    public bool revive;
    

    [Header("Iframes")]
    [SerializeField] public float iFramesDuration;
    [SerializeField] public int numOfFlashes;
    public SpriteRenderer spriteRend;
    public Color damageColor = new Color(1, 0, 0, 0.5f);

    [Header("Misc")]
    public bool shieldActive = false;

    //Add this once you hahve death animation
    //public Animator anim;
    void Start()
    {
        currentHealth = maxHealth;
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    public void Death(bool revive)
    {
        Debug.Log("Player died. Revive status: " + revive);
        if (revive)
        {
            Debug.Log("Reviving Player");
            player.transform.position = Revive.transform.position;
            currentHealth = 1;
        }
        else
        {
            Debug.Log("Normal Respawn");
            player.transform.position = Respawn.transform.position;
            currentHealth = maxHealth;
        }
    }
    public void TakeDamage(int amount)
    {
        if (shieldActive)
        {
            Debug.Log("Damage Blocked by Shield");
            return;
        }
        currentHealth -= amount;
        StartCoroutine(Invul(iFramesDuration, damageColor));
        if (currentHealth <= 0)
        {
            Death(revive);
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

    public IEnumerator Invul(float iFramesDuration, Color color)
    {
        Debug.Log("activated");
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numOfFlashes; i++)
        {
            spriteRend.color = color;
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    
}
