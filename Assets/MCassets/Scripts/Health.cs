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

    [Header("Iframes")]
    [SerializeField] public float iFramesDuration;
    [SerializeField] public int numOfFlashes;
    public SpriteRenderer spriteRend;

    //Add this once you hahve death animation
    //public Animator anim;
    void Start()
    {
        currentHealth = maxHealth;
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        StartCoroutine(Invul(iFramesDuration));

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

    public IEnumerator Invul(float iFramesDuration)
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
