using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCards : MonoBehaviour
{
    public GameObject player;
    public GameObject Revive;

    public Health playerHealth;
    public void Regen(Health playerHealth)
    {
        playerHealth.Regen();
        
    }

    public void InvulAbility(Health playerHealth)
    {
        playerHealth.Invul(10f, Color.blue);
    }

    // Eventually chnage this to the diamonds script
    public void Sheild(Health playerHealth)
    {
        playerHealth.Sheild();
    }

    public void Rez()
    {
            playerHealth.StartCoroutine(playerHealth.rezTimer(10f));
    }
}
