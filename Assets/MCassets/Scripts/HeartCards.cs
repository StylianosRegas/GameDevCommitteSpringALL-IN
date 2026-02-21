using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeartCards : MonoBehaviour
{
    public Health playerHealth;
    public void Regen(Health playerHealth)
    {
        playerHealth.Regen();
    }

    public void InvulAbility(Health playerHealth)
    {
        playerHealth.Invul(10f);
    }

    // Eventually chnage this to the diamonds script
    public void Sheild(Health playerHealth)
    {
        playerHealth.Sheild();
    }
}
