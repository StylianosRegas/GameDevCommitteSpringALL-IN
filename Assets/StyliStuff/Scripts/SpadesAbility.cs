using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;
using UnityEngine.UIElements;

public class SpadesAbility : MonoBehaviour
{
    public PlayerController player;
    public Health playerHealth;
    public PlayerAttack playerAttack;
    public GameObject pokerChip;
    public GameObject boomerangOb;
    public GameObject moneyOb;
   
    public float xVelocity = 500f;
    public float yVelocity = 500f;

    public int damageIncrease = 2;
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
        int ogDmg = playerAttack.damage;
        //need to change damage

        if(playerHealth.currentHealth / 2 == 0)
        {
            playerHealth.currentHealth = 1;
          
        }
        else
        {
            playerHealth.currentHealth /= 2;
          
        }
        playerAttack.damage = damageIncrease;

        StartCoroutine(DmgDuration(damageTimer, damageIncrease, ogHealth,ogDmg));
       
    }

    public void boomerang()
    {
        if (player.isFlipped)
        {

            Instantiate(boomerangOb, new Vector3(player.transform.position.x + 2, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);


        }
        else
        {

            Instantiate(boomerangOb, new Vector3(player.transform.position.x - 2, player.transform.position.y+1, player.transform.position.z), Quaternion.identity);

        }
    }

    public void moneyGun()
    {

        if (player.isFlipped)
        {

            Instantiate(moneyOb, new Vector3(player.transform.position.x + 2, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);


        }
        else
        {

            Instantiate(moneyOb, new Vector3(player.transform.position.x - 2, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);

        }
    }

    public IEnumerator DmgDuration(float time, float speedMulti,int ogHealth, int ogDmg)
    {

        yield return new WaitForSeconds(time);
        playerHealth.currentHealth = ogHealth;
        playerAttack.damage = ogDmg;


    }
}
