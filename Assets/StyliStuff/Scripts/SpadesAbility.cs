using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TarodevController;

public class SpadesAbility : MonoBehaviour
{
    public PlayerController player;
    public Health playerHealth;
    public GameObject pokerChip;
    public GameObject boomerangOb;
   
    public float xVelocity = 500f;
    public float yVelocity = 500f;

    public float damageMulti = 1.5f;
    public float damageTimer = 5f;


    public void PokerChip()
    {
        if (player.isFlipped)
        {
            Vector3 spawnPosition = new Vector2(player.transform.position.x - 1f, player.transform.position.y + 1f);
            GameObject chip = Instantiate(pokerChip, spawnPosition, Quaternion.identity);
            chip.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xVelocity, yVelocity));
            
            

        }
        else
        {
            Vector3 spawnPosition = new Vector2(player.transform.position.x + 1f, player.transform.position.y + 1f);
            GameObject chip = Instantiate(pokerChip, spawnPosition, Quaternion.identity);
            chip.GetComponent<Rigidbody2D>().AddForce(new Vector2(xVelocity, yVelocity));
        }
    }

    public void DamageIncrease()
    {
        // implement damage increase once we got it in the game
        int ogHealth = playerHealth.currentHealth;
        //need to change damage

        if(playerHealth.currentHealth / 2 == 0)
        {
            playerHealth.currentHealth = 1;
        }
        else
        {
            playerHealth.currentHealth /= 2;
        }
            StartCoroutine(DmgDuration(damageTimer, damageMulti, ogHealth));
       
    }

    public void boomerang()
    {
        if (player.isFlipped)
        {
            Vector3 spawnPosition = new Vector2(player.transform.position.x - 1f, player.transform.position.y + 1f);
            GameObject boom = Instantiate(boomerangOb, spawnPosition, Quaternion.identity);
            boom.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xVelocity, 0));



        }
        else
        {
            Vector3 spawnPosition = new Vector2(player.transform.position.x + 1f, player.transform.position.y + 1f);
            GameObject chip = Instantiate(boomerangOb, spawnPosition, Quaternion.identity);
            chip.GetComponent<Rigidbody2D>().AddForce(new Vector2(xVelocity, 0));
        }
    }

    public IEnumerator DmgDuration(float time, float speedMulti,int ogHealth)
    {

        yield return new WaitForSeconds(time);
        playerHealth.currentHealth = ogHealth;


    }
}
