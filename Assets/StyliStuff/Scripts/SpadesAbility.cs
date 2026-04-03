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

    public float spawnTime = .2f;
    public int moneyAmount = 20;

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
            boomerangOb.GetComponent<Boomerang>().direction = -1;
            Instantiate(boomerangOb, new Vector3(player.transform.position.x - 2, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);


        }
        else
        {
            boomerangOb.GetComponent<Boomerang>().direction = 1;

            Instantiate(boomerangOb, new Vector3(player.transform.position.x + 2, player.transform.position.y+1, player.transform.position.z), Quaternion.identity);

        }
    }

    public void moneyAttack()
    {
        StartCoroutine(moneySpawner());
    }

    public void Uppercut()
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        player.ExecuteJump();
        


    }

    public IEnumerator moneySpawner()
    {

        for (int i = 0; i < moneyAmount; i++)
        {
            if (player.isFlipped)
            {
                moneyOb.GetComponent<MoneyAttack>().direction = -1;
                GameObject money = Instantiate(moneyOb, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);
                Rigidbody2D rb = money.GetComponent<Rigidbody2D>();
                //rb.AddForce(transform.up * 100f);


            }
            else
            {
                moneyOb.GetComponent<MoneyAttack>().direction = 1;
                GameObject money = Instantiate(moneyOb, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);
                
                

            }
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public IEnumerator DmgDuration(float time, float speedMulti,int ogHealth, int ogDmg)
    {

        yield return new WaitForSeconds(time);
        playerHealth.currentHealth = ogHealth;
        playerAttack.damage = ogDmg;


    }

}
